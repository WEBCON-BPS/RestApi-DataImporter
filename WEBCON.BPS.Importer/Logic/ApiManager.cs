using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Logic
{
    public class ApiManager
    {
        private readonly HttpClient _client;
        private readonly Configuration _config;
        private readonly UrlBuilder _urlBuilder;

        public ApiManager(HttpClient client, Configuration config)
        {
            _client = client;
            _config = config;
            _urlBuilder = new UrlBuilder(config);
        }

        #region Applications

        public async Task<IEnumerable<(int id, string name)>> GetApplicationsAsync()
        {
            dynamic result = await SendRequestDynamicAsync(_urlBuilder.Applications, HttpMethod.Get);

            return ParseApplicationsData(result);
        }

        private IEnumerable<(int id, string name)> ParseApplicationsData(dynamic result)
        {
            var apps = ((IEnumerable<dynamic>)result.applications);

            foreach (var app in apps)
                yield return (app.id, app.name);
        }

        #endregion

        #region Reports

        public async Task<ReportData> GetReportDataAsync(string appId)
        {
            dynamic result = await SendRequestDynamicAsync(_urlBuilder.ReportsViewParams(appId), HttpMethod.Get);
            var cols = ParseColumns(result);

            return new ReportData()
            {
                Columns = cols,
                Rows = ParseReportRows(result, cols)
            };
        }

        private IEnumerable<Column> ParseColumns(dynamic result)
        {
            var cols = (IEnumerable<dynamic>)result.columns;

            foreach (var col in cols)
                yield return new Column(col.guid?.ToString(), col.name?.ToString(), col.type?.ToString());
        }

        private IEnumerable<Row> ParseReportRows(dynamic result, IEnumerable<Column> columns)
        {
            var rows = (IEnumerable<dynamic>)result.rows;

            foreach (var row in rows)
            {
                var cells = (IEnumerable<dynamic>)row.cells;
                var id = row.id;
                yield return new Row() { ElementId = id, Values = GetCellsStringValues(cells, columns).ToArray() };
            }
        }

        private IEnumerable<string> GetCellsStringValues(IEnumerable<dynamic> cells, IEnumerable<Column> columns)
        {
            for(int i = 0; i < columns.Count(); i++)
            {
                switch (columns.ElementAt(i).Type)
                {
                    case "ChoicePicker":
                    case "Autocomplete":
                    case "ChoiceList":
                    case "People":
                        {
                            var value = cells.ElementAt(i).value;

                            if(value is JValue jVal)
                            {
                                yield return jVal.ToString();
                                break;
                            }

                            if (value is JArray jArray)
                            {
                                yield return string.Join(";", jArray.Select(x => (dynamic)x).Select(x => $"{x.id}#{x.name}"));
                                break;
                            }
                            break;
                        }

                    case "LocalAttachments":
                    case "RelativeAttachments":
                        {
                            //unsupported in api update
                            yield return string.Empty;
                            break;
                        }

                    default:
                        {
                            yield return (string)Convert.ToString(cells.ElementAt(i).value);
                            break;
                        }
                }
            }
        }

        #endregion

        #region Elements

        public async Task<ElementWithAttachment> GetElementWithAttachmentsAsync(string id)
        {
            dynamic result = await SendRequestDynamicAsync(_urlBuilder.Element(id), HttpMethod.Get);

            var data = new ElementWithAttachment();
            int.TryParse(id, out var elemId);

            data.Element.ElementId = elemId;

            var lists = (IEnumerable<dynamic>)result.itemLists;
            foreach (var list in lists)
            {
                var cols = ParseColumns(list);

                data.Element.ItemLists.Add(new ItemList()
                {
                    Id = list.id,
                    Guid = list.guid,
                    Name = list.name,
                    Type = "ItemList",
                    Columns = cols,
                    Rows = ParseRows(list, elemId, cols)
                });
            }

            var atts = (IEnumerable<dynamic>)result.attachments;
            foreach (var att in atts)
            {
                data.Attachments.Add(new AttachmentData()
                {
                    Id = att.id,
                    ElementId = elemId,
                    Name = att.name,
                    AttachmentProvider = new ElementAttachmentsProvider(this, elemId.ToString(), (string)att.id)
                });
            }

            return data;
        }

        private IEnumerable<Row> ParseRows(dynamic result, int? elementId, IEnumerable<Column> columns)
        {
            var rows = (IEnumerable<dynamic>)result.rows;

            foreach (var row in rows)
            {
                var cells = (IEnumerable<dynamic>)row.cells;
                yield return new Row() { ElementId = elementId, RowId = row.id, Values = GetCellsStringValues(cells, columns).ToArray() };
            }
        }

        public async Task<byte[]> GetAttachmentContentAsync(string elemId, string attId)
        {
            dynamic result = await SendRequestDynamicAsync(_urlBuilder.AttachmentContent(elemId, attId), HttpMethod.Get);
            return (byte[])result.content;
        }

        public async Task<ElementResult> StartElementAsync(IEnumerable<Column> columns, ImportRow row, string wfId, string ftId, string path)
        {
            var content = new StringContent(PrepStartModel(columns, row, wfId, ftId), Encoding.UTF8, "application/json");
            path = !string.IsNullOrEmpty(path) ? path : (!string.IsNullOrEmpty(row.Path) ? row.Path : "default");
            var result = await SendRequestAsync(_urlBuilder.NewElement(path), HttpMethod.Post, content);

            if (result.ok)
                return new ElementResult()
                {
                    Success = JsonConvert.DeserializeObject<Success>(result.response)
                };

            return new ElementResult()
            {
                Error = JsonConvert.DeserializeObject<Error>(result.response)
            };
        }

        public async Task<ElementResult> UpdateElementAsync(IEnumerable<Column> columns, ImportRow row, string path)
        {
            var model = PrepUpdateModel(columns, row);
            var content = new StringContent(model, Encoding.UTF8, "application/json");
            var url = !string.IsNullOrEmpty(path) ? _urlBuilder.MoveElement(row.ElementId.ToString(), path) : (!string.IsNullOrEmpty(row.Path) ? _urlBuilder.MoveElement(row.ElementId.ToString(), row.Path) : _urlBuilder.UpdateElement(row.ElementId.ToString()));
            var result = await SendRequestAsync(url, new HttpMethod("PATCH"), content);

            if (result.ok)
                return new ElementResult()
                {
                    Success = JsonConvert.DeserializeObject<Success>(result.response)
                };

            return new ElementResult()
            {
                Error = JsonConvert.DeserializeObject<Error>(result.response)
            };
        }

        private string PrepUpdateModel(IEnumerable<Column> columns, ImportRow row)
        {
            dynamic model = new
            {
                formFields = GenerateFields(columns, row),
                itemLists = GenerateItemLists(row.ItemLists),
                attachments = GenerateAttachments(row)
            };

            return JsonConvert.SerializeObject(model);
        }

        private string PrepStartModel(IEnumerable<Column> columns, ImportRow row, string wfId, string ftId)
        {
            dynamic model = new
            {
                workflow = new { id = wfId },
                formType = new { id = ftId },
                formFields = GenerateFields(columns, row),
                itemLists = GenerateItemLists(row.ItemLists),
                attachments = GenerateAttachments(row)
            };

            return JsonConvert.SerializeObject(model);
        }

        private List<object> GenerateFields(IEnumerable<Column> columns, ImportRow row)
        {
            var fields = new List<object>();

            for (int i = 0; i < columns.Count(); i++)
            {
                if (string.IsNullOrEmpty(columns.ElementAtOrDefault(i)?.Guid))
                    continue;

                fields.Add(new { guid = columns.ElementAtOrDefault(i).Guid, svalue = row.Values.ElementAtOrDefault(i) });
            }

            return fields;
        }

        private List<object> GenerateItemLists(List<ItemList> lists)
        {
            if (!lists.Any())
                return null;

            var result = new List<object>();

            foreach(var list in lists)
            {
                result.Add(new { guid = list.Guid, rows = GetRows(list) });
            }

            return result;
        }

        private List<object> GetRows(ItemList list)
        {
            var rows = new List<object>();

            foreach (var row in list.Rows)
            {
                rows.Add(new { id = row.RowId, cells = GetCells(list, row) });
            }

            return rows;
        }

        private List<object> GetCells(ItemList list, Row row)
        {
            var cells = new List<object>();

            for (int i = 0; i < list.Columns.Count(); i++)
            {
                if (string.IsNullOrEmpty(list.Columns.ElementAtOrDefault(i)?.Guid))
                    continue;

                cells.Add(new { guid = list.Columns.ElementAtOrDefault(i).Guid, svalue = row.Values.ElementAt(i) });
            }

            return cells;
        }

        private List<object> GenerateAttachments(ImportRow row)
        {
            if (!row.AttachmentsPaths.Any())
                return null;

            var atts = new List<object>();

            foreach (var path in row.AttachmentsPaths)
            {
                if (!File.Exists(path))
                    throw new Exception($"File {path} not found");

                var name = Path.GetFileName(path).Split(new string[] { "__" }, StringSplitOptions.RemoveEmptyEntries).Last();

                atts.Add(new { name = name, content = Convert.ToBase64String(File.ReadAllBytes(path))});
            }

            return atts;
        }

        #endregion

        #region Templates

        public async Task<TemplateData> GetFormTemplateAsync(int formTypeId, int stepId)
        {
            dynamic result = await SendRequestDynamicAsync(_urlBuilder.FormTeplate(formTypeId, stepId), HttpMethod.Get);

            return new TemplateData()
            {
                Fields = ParseFields(result),
                ItemLists = ParseList(result)
            };
        }

        private IEnumerable<Column> ParseFields(dynamic result)
        {
            var cols = (IEnumerable<dynamic>)result.fields;

            foreach (var col in cols)
                yield return new Column(col.guid?.ToString(), col.name?.ToString(), col.type?.ToString());
        }

        private IEnumerable<ItemListTemplate> ParseList(dynamic result)
        {
            var lists = (IEnumerable<dynamic>)result.itemLists;

            foreach(var list in lists)
            {
                yield return new ItemListTemplate()
                {
                    Id = list.id,
                    Guid = list.guid,
                    Name = list.name,
                    Type = list.type,
                    Columns = ParseTemplateColumns(list)
                };
            }
        }

        private IEnumerable<Column> ParseTemplateColumns(dynamic result)
        {
            var cols = (IEnumerable<dynamic>)result.Columns;

            foreach (var col in cols)
                yield return new Column(col.guid?.ToString(), col.name?.ToString(), col.type?.ToString());
        }

        #endregion

        private async Task<dynamic> SendRequestDynamicAsync(string link, HttpMethod method, HttpContent content = null)
        {
            var request = await _client.SendAsync(new HttpRequestMessage(method, link) { Content = content });
            var response = await request.Content.ReadAsStringAsync();

            if (!request.IsSuccessStatusCode)
            {
                throw new Exception($"{request.StatusCode}: {response}");
            }

            dynamic result = JsonConvert.DeserializeObject(response);
            return result;
        }

        private async Task<(bool ok, string response)> SendRequestAsync(string link, HttpMethod method, HttpContent content = null)
        {
            var request = await _client.SendAsync(new HttpRequestMessage(method, link) { Content = content });
            var response = await request.Content.ReadAsStringAsync();

            return (request.IsSuccessStatusCode, response);
        }
    }
}
