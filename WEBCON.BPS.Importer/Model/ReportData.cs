using System.Collections.Generic;

namespace WEBCON.BPS.Importer.Model
{
    public class ReportData
    {
        public IEnumerable<Column> Columns { get; set; }
        public IEnumerable<Row> Rows { get; set; }
    }

    public class Row
    {
        public int? ElementId { get; set; }
        public int? RowId { get; set; }
        public object[] Values { get; set; }
    }
    public class Column
    {
        public Column(string guid, string name, string type)
        {
            Guid = guid;
            Name = name;
            Type = type;
        }

        public string Guid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
