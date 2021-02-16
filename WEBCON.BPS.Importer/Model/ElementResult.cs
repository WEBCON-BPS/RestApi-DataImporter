namespace WEBCON.BPS.Importer.Model
{
    public class ElementResult
    {
        public Success Success { get; set; }
        public Error Error { get; set; }
    }

    public class Success
    {
        public int id { get; set; }
        public string instanceNumber { get; set; }
        public string status { get; set; }
    }

    public class Error
    {
        public string type { get; set; }
        public string description { get; set; }
        public string errorGuid { get; set; }
    }
}
