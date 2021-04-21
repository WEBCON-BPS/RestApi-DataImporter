using System.Collections.Generic;

namespace WEBCON.BPS.Importer.Model
{
    public class ImportModel
    {
        public List<Column> Columns { get; set; }
        public List<ImportRow> Rows { get; set; }
    }

    public class ImportRow : Row
    {
        public List<ItemList> ItemLists { get; set; } = new List<ItemList>();
        public List<string> AttachmentsPaths { get; set; } = new List<string>();
        public string Path { get; set; }
    }
}
