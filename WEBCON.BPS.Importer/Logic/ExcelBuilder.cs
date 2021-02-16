using Aspose.Cells;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEBCON.BPS.Importer.Helpers;
using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Logic
{
    public class ExcelBuilder
    {
        private readonly Workbook _workbook = new Workbook();
        private readonly bool _includeLists;
        private readonly bool _includeAttachments;
        private readonly string _attachmentsPath;

        public ExcelBuilder(bool includeLists, bool includeAttachments, string attachmentsPath)
        {
            _includeLists = includeLists;
            _includeAttachments = includeAttachments;
            _attachmentsPath = attachmentsPath;
        }

        public async Task<Workbook> BuildDataSheetAsync(ReportData reportData, ConcurrentBag<ElementData> elements, ConcurrentBag<AttachmentData> attachments)
        {
            var ws = _workbook.Worksheets[0];
            var idCol = new List<Model.Column>() { new Model.Column(string.Empty, "WFDID", "WFDID") };

            BuildHeaders(idCol.Concat(reportData.Columns), ws);
            BuildRows(reportData.Rows, ws);

            if (_includeLists)
            {
                BuildSubelementsHeaders(ws, elements.SelectMany(e => e.ItemLists).DistinctBy(i => i.Guid), out var listColsById);
                BuildSubelementsRows(elements, listColsById);
            }

            if (_includeAttachments)
            {
                BuildAttachmentHeaders(ws, out var attsColId);
                var idPathsDic = await SaveAttachmentFilesAsync(attachments);
                SetAttachmentsPathsToCells(attsColId, idPathsDic, ws);
            }

            ws.AutoFitColumns();
            ws.SelectRange(0, 0, 1, ws.Cells.MaxDataColumn, true);

            return _workbook;
        }

        public Workbook BuildTemplate(TemplateData data)
        {
            var ws = _workbook.Worksheets[0];

            BuildHeaders(data.Fields, ws);
            BuildAttachmentHeaders(ws, out _);
            BuildSubelementsHeaders(ws, data.ItemLists, out _);

            ws.AutoFitColumns();
            ws.SelectRange(0, 0, 1, ws.Cells.MaxDataColumn, true);

            return _workbook;
        }

        private void BuildHeaders(IEnumerable<Model.Column> columns, Worksheet ws)
        {
            var offset = ws.Cells.MaxDataColumn + 1;

            for (int i = 0; i < columns.Count(); i++)
            {
                var col = columns.ElementAt(i);
                var id = i + offset;

                ws.Cells[0, id].Value = col.Name;
                ws.Cells[1, id].Value = col.Guid;
                ws.Cells[2, id].Value = col.Type;

                SetStyleOnHeaders(ws, id);
            }
        }

        private void BuildAttachmentHeaders(Worksheet ws,  out int attsColId)
        {
            const string name = "Attachments";
            attsColId = ws.Cells.MaxDataColumn + 1;
            var style =  _workbook.CreateBuiltinStyle(BuiltinStyleType.Note);

            ws.Cells[0, attsColId].Value = ws.Cells[2, attsColId].Value = name;

            SetStyleOnHeaders(ws, attsColId, style);
        }
        
        private async Task<Dictionary<int, List<string>>> SaveAttachmentFilesAsync(ConcurrentBag<AttachmentData> attachments)
        {
            var idPathsDic = new Dictionary<int, List<string>>();

            foreach (var att in attachments)
            {
                var path = Path.Combine(_attachmentsPath, $"{att.Id}__{att.Name}");
                File.WriteAllBytes(path, await att.AttachmentProvider.GetAttachmentContentAsync());

                if (idPathsDic.ContainsKey(att.ElementId))
                    idPathsDic[att.ElementId].Add(path);
                else
                    idPathsDic[att.ElementId] = new List<string>() { path };
            }

            return idPathsDic;
        }

        private void SetAttachmentsPathsToCells(int attsColId, Dictionary<int, List<string>> idPathsDic, Worksheet ws)
        {
            for(int i = 1; i <= ws.Cells.MaxDataRow; i++)
            {
                if(int.TryParse(ws.Cells[i, 0].Value?.ToString(), out var elemId) && idPathsDic.ContainsKey(elemId))
                {
                    ws.Cells[i, attsColId].Value = string.Join(";", idPathsDic[elemId]);
                }
            }
        }

        private void BuildRows(IEnumerable<Model.Row> rows, Worksheet ws, bool itemList = false)
        {
            var rowId = ws.Cells.MaxDataRow + 1;

            foreach (var row in rows)
            {
                var colId = 0;
                ws.Cells[rowId, colId++].Value = row.ElementId;

                if (itemList)
                    ws.Cells[rowId, colId++].Value = row.RowId;

                foreach (var value in row.Values)
                    ws.Cells[rowId, colId++].Value = value;

                rowId++;
            }
        }

        private void BuildSubelementsHeaders(Worksheet ws, IEnumerable<ItemListTemplate> lists, out Dictionary<int, int> listColsById)
        {
            listColsById = new Dictionary<int, int>();

            foreach (var list in lists)
            {
                listColsById.Add(list.Id, ws.Cells.MaxDataColumn + 1);
                BuildHeaders(new Model.Column[] { new Model.Column($"{list.Guid}#{list.Id}", list.Name, list.Type) }, ws);

                var listSheet = _workbook.Worksheets.Add(list.Id.ToString());
                var staticHeaders = new Model.Column[] { new Model.Column(string.Empty, "RelationKey", "RelationKey"), new Model.Column(string.Empty, "SubRowID", "SubRowID") };

                BuildHeaders(staticHeaders.AsEnumerable().Concat(list.Columns), listSheet);

                listSheet.AutoFitColumns();
            }
        }

        private void BuildSubelementsRows(ConcurrentBag<ElementData> elements, Dictionary<int, int> listColsById)
        {
            foreach(var element in elements)
                foreach(var list in element.ItemLists)
                {
                    if (list.Rows.Any())
                    {
                        var ws = _workbook.Worksheets[list.Id.ToString()];
                        BuildRows(list.Rows, ws, true);
                        SetListRelId(listColsById, element.ElementId, list.Id);
                    }
                }
        }

        private void SetListRelId(Dictionary<int, int> listColsById, int elemId, int listId)
        {
            var elementRow = _workbook.Worksheets[0].Cells.Find(elemId.ToString(), null, new FindOptions() { LookAtType = LookAtType.EntireContent, LookInType = LookInType.Values, SeachOrderByRows = true, ConvertNumericData = true }).Row;
            _workbook.Worksheets[0].Cells[elementRow, listColsById[listId]].Value = elemId;
        }

        public void SetStyleOnHeaders(Worksheet ws, int columnId, Style style = null)
        {
            style = style ?? CreateDefaultStyle(ws, columnId);

            style.SetBorder(BorderType.BottomBorder, CellBorderType.Thin, System.Drawing.Color.Black);
            style.SetBorder(BorderType.TopBorder, CellBorderType.Thin, System.Drawing.Color.Black);
            style.SetBorder(BorderType.LeftBorder, CellBorderType.Thin, System.Drawing.Color.Black);
            style.SetBorder(BorderType.RightBorder, CellBorderType.Thin, System.Drawing.Color.Black);

            ws.Cells[0, columnId].SetStyle(style);
            ws.Cells[1, columnId].SetStyle(style);
            ws.Cells[2, columnId].SetStyle(style);

            style = ws.Cells[1, columnId].GetStyle();
            style.Font.Size = 4;
            ws.Cells[1, columnId].SetStyle(style);
        }

        private Style CreateDefaultStyle(Worksheet ws, int columnId)
        {
            var style = ws.Cells[0, columnId].GetStyle();
            style.ForegroundColor = System.Drawing.Color.LightGray;
            style.Pattern = BackgroundType.Solid;

            return style;
        }
    }
}
