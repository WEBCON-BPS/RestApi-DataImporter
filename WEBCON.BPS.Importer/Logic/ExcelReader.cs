using Aspose.Cells;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using WEBCON.BPS.Importer.Helpers;
using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Logic
{
    public class ExcelReader
    {
        private readonly Workbook _workbook;
        private readonly HashSet<int> _colsToSkip = new HashSet<int>();
        private int _lastColumn;
        private readonly string _filePath;

        private const string BadColor = "#ffffc7ce";
        private const string NeutralColor = "#ffffeb9c";
        private const string GoodColor = "#ffc6efce";

        public ExcelReader(string filePath)
        {
            _filePath = filePath;
            _workbook = new Workbook(filePath);
        }

        public ImportModel GetImportData(string sheetName)
        {
            var ws = _workbook.Worksheets[sheetName];
            _lastColumn = _workbook.Worksheets[0].Cells.MaxDataColumn;

            return new ImportModel
            {
                Columns = ReadColumns(ws).ToList(),
                Rows = ReadRows(ws).ToList()
            };
        }

        private IEnumerable<Model.Column> ReadColumns(Worksheet worksheet)
        {
            for(int i = 0; i <= worksheet.Cells.MaxDataColumn; i++)
            {
                var type = worksheet.Cells[2, i].StringValue;
                var guid = worksheet.Cells[1, i].StringValue;

                if (type.Equals("ItemList") || type.Equals("LocalAttachments") || type.Equals("RelativeAttachments") || (string.IsNullOrEmpty(guid) && !type.Equals("WFDID")))
                {
                    _colsToSkip.Add(i);
                    continue;
                }

                yield return new Model.Column(worksheet.Cells[1, i].StringValue, worksheet.Cells[0, i].StringValue, type);
            }
        }

        private IEnumerable<ImportRow> ReadRows(Worksheet worksheet)
        {
            var headers = GetHeaders(worksheet);

            for (int i = 3; i <= worksheet.Cells.MaxDataRow; i++)
            {
                var row = new ImportRow();
                var values = new List<object>();

                for (int j = 0; j <= worksheet.Cells.MaxDataColumn; j++)
                {
                    if (_colsToSkip.Contains(j))
                        continue;

                    if (headers.TryGetValue(j, out var header))
                    {
                        switch (header.type)
                        {
                            case ColumnType.WfdId:
                                {
                                    if(int.TryParse(worksheet.Cells[i, j].Value?.ToString(), out var id))
                                        row.ElementId = id;
                                    break;
                                }
                            case ColumnType.Path:
                                {
                                    row.Path = worksheet.Cells[i, j].StringValue;
                                    break;
                                }
                            case ColumnType.ItemLists:
                                {
                                    var cellValue = worksheet.Cells[i, j].StringValue;

                                    if (!string.IsNullOrEmpty(cellValue))
                                        row.ItemLists.Add(FetchItemListsData(cellValue, header.listGuidId));

                                    break;
                                }
                            case ColumnType.Attachments:
                                {
                                    var cellValue = worksheet.Cells[i, j].StringValue;

                                    if (!string.IsNullOrEmpty(cellValue))
                                    {
                                        var paths = cellValue.Split(';');

                                        foreach (var path in paths)
                                            row.AttachmentsPaths.Add(Path.Combine(Path.GetDirectoryName(_filePath), "attachments", path));
                                    }

                                    break;
                                }
                        }
                    }

                    values.Add(worksheet.Cells[i, j].Value);
                }

                row.Values = values.ToArray();
                yield return row;
            }
        }

        private ItemList FetchItemListsData(string relId, string guidId)
        {
            var pair = guidId.Split('#');
            var id = pair.Last();
            var guid = pair.FirstOrDefault();

            var ws = _workbook.Worksheets[id];

            return new ItemList()
            {
                Id = Convert.ToInt32(id),
                Guid = guid,
                Columns = ReadColumns(ws),
                Rows = ReadRows(ws)
            };
        }

        private Dictionary<int, (ColumnType type, string listGuidId)> GetHeaders(Worksheet worksheet)
        {
            var result = new Dictionary<int, (ColumnType type, string listGuidId)>();

            for(int i = 0; i <= worksheet.Cells.MaxDataColumn; i++)
            {
                var value = worksheet.Cells[2, i].StringValue;

                switch (value)
                {
                    case "WFDID":
                        {
                            result.Add(i, (ColumnType.WfdId, string.Empty));
                            break;
                        }
                    case "PATHID":
                        {
                            result.Add(i, (ColumnType.Path, string.Empty));
                            break;
                        }
                    case "ItemList":
                        {
                            var guidId = worksheet.Cells[1, i].StringValue;
                            
                            result.Add(i, (ColumnType.ItemLists, guidId));
                            break;
                        }
                    case "Attachments":
                        {
                            result.Add(i, (ColumnType.Attachments, string.Empty));
                            break;
                        }
                }
            }

            return result;
        }

        public IEnumerable<string> GetWorksheets()
        {
            return _workbook.Worksheets.Select(ws => ws.Name);
        }

        public void AppendResult(ElementResult result, int rowId)
        {
            var offset = 3;
            var id = rowId + offset;
            _workbook.Worksheets[0].Cells[id, _lastColumn+1].Value = result.Error != null ? "ERROR" : (result.Success.status.Equals("Saved") ? "UPDATE:OK" : "NEW:OK");
            _workbook.Worksheets[0].Cells[id, _lastColumn+2].Value = JsonConvert.SerializeObject((object)result.Error ?? result.Success);
            ApplyRowStyle(result, id);

            _workbook.Worksheets[0].AutoFitColumns();
            _workbook.Worksheets[0].SelectRange(0, 0, 1, _workbook.Worksheets[0].Cells.MaxDataColumn, true);
        }

        private void ApplyRowStyle(ElementResult result, int rowId)
        {
            if (result.Error != null)
                SetBackgroudColorAndPerserveStyle(rowId, ColorTranslator.FromHtml(BadColor));
            else if (result.Success.status.Equals("Saved"))
                SetBackgroudColorAndPerserveStyle(rowId, ColorTranslator.FromHtml(NeutralColor));
            else
                SetBackgroudColorAndPerserveStyle(rowId, ColorTranslator.FromHtml(GoodColor));
        }

        private void SetBackgroudColorAndPerserveStyle(int rowId, Color color)
        {
            for (int i = 0; i <= _workbook.Worksheets[0].Cells.MaxDataColumn; i++)
            {
                var cell = _workbook.Worksheets[0].Cells[rowId, i];
                var style = cell.GetStyle();
                style.ForegroundColor = color;
                style.Pattern = BackgroundType.Solid;
                cell.SetStyle(style);
            }
        }

        public void SaveReport(string ogrinalName)
        {
            try
            {
                _workbook.Save(GetUniqueName(ogrinalName));
            }
            catch (Exception ex)
            {
                throw new Exception("Error while saving report file", ex);
            }
        }

        private string GetUniqueName(string ogrinalName)
        {
            var name = ogrinalName.Replace(".xlsx", "_imported.xlsx");
            int i = 0;

            while (File.Exists(name))
            {
                name = ogrinalName.Replace(".xlsx", $"_imported ({++i}).xlsx");
            }

            return name;
        }
    }
}
