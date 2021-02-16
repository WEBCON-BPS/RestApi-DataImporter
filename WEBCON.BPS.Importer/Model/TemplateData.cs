using System.Collections.Generic;
using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Model
{
    public class TemplateData
    {
        public IEnumerable<Column> Fields { get; set; }
        public IEnumerable<ItemListTemplate> ItemLists { get; set; }
    }

    public class ItemListTemplate
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<Column> Columns { get; set; }
    }
}
