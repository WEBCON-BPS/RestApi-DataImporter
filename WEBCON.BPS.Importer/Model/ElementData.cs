using System.Collections.Generic;

namespace WEBCON.BPS.Importer.Model
{
    public class ElementData
    {
        public int ElementId { get; set; }
        public List<ItemList> ItemLists { get; set; } = new List<ItemList>();
    }

    public class ItemList : ItemListTemplate
    {
        public IEnumerable<Row> Rows { get; set; }
    }
}
