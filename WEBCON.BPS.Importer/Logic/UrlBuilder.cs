using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Logic
{
    public sealed class UrlBuilder
    {
        private readonly Configuration _config;
        private const string Version = "beta";

        public UrlBuilder(Configuration config)
        {
            _config = config;
        }

        public string Applications => $"api/data/{Version}/db/{_config.DbId}/applications";
        public string Processes(int appId) => $"api/data/{Version}/db/{_config.DbId}/applications/{appId}/processes";
        public string Workflows(int processId) => $"api/data/{Version}/db/{_config.DbId}/processes/{processId}/workflows";
        public string Formtypes(int processId) => $"api/data/{Version}/db/{_config.DbId}/processes/{processId}/formtypes";
        public string Steps(int workflowId) => $"api/data/{Version}/db/{_config.DbId}/workflows/{workflowId}/steps";
        public string AssociatedFormTypes(int workflowId) => $"api/data/{Version}/db/{_config.DbId}/workflows/{workflowId}/associatedFormTypes";
        public string Paths(int stepId) => $"api/data/{Version}/db/{_config.DbId}/steps/{stepId}/paths";

        public string ReportsViewParams(string appId)
        {
            var view = _config.ViewId.HasValue ? $"/views/{_config.ViewId}" : string.Empty;
            return $"api/data/{Version}/db/{_config.DbId}/applications/{appId}/reports/{_config.ReportId}{view}?page={_config.Page}&size={_config.Size}";
        }

        public string NewElement(string path) => $"api/data/{Version}/db/{_config.DbId}/elements?path={path}";
        public string MoveElement(string elemId, string path) => $"api/data/{Version}/db/{_config.DbId}/elements/{elemId}?path={path}";
        public string UpdateElement(string elemId) => $"api/data/{Version}/db/{_config.DbId}/elements/{elemId}";
        public string Element(string id) => $"api/data/{Version}/db/{_config.DbId}/elements/{id}";        
        
        public string FormTeplate(int fomrTypeId, int stepId) => $"api/data/{Version}/db/{_config.DbId}/formlayout?step={stepId}&formType={fomrTypeId}";

        public string ElementAttachments(string id) => $"api/data/{Version}/db/{_config.DbId}/elements/{id}/attachments";

        public string AttachmentContent(string elemId, string attId) => $"api/data/{Version}/db/{_config.DbId}/elements/{elemId}/attachments/{attId}/content";

        public string ReportsMetadata(int appId) => $"api/data/{Version}/db/{_config.DbId}/applications/{appId}/reports";
        public string ReportViews(int reportId) => $"api/data/{Version}/db/{_config.DbId}/reports/{reportId}/views";
    }
}
