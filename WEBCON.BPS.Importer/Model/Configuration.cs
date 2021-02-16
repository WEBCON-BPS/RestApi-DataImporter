namespace WEBCON.BPS.Importer.Model
{
    public class Configuration
    {
        public string PortalUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ImpersonationLogin { get; set; }
        public int DbId { get; set; }

        public int? ReportId { get; set; }
        public int? ViewId { get; set; }
        public int? Page { get; set; }
        public int? Size { get; set; }
    }
}
