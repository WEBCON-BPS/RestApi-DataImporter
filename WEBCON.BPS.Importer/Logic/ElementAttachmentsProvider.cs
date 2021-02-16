using System.Threading.Tasks;

namespace WEBCON.BPS.Importer.Logic
{
    public class ElementAttachmentsProvider
    {
        private readonly ApiManager _apiManager;
        private readonly string _elementId;
        private readonly string _attachmentId;

        public ElementAttachmentsProvider(ApiManager apiManager, string elementId, string attachmentId)
        {
            _apiManager = apiManager;
            _elementId = elementId;
            _attachmentId = attachmentId;
        }

        public async Task<byte[]> GetAttachmentContentAsync()
        {
            return await _apiManager.GetAttachmentContentAsync(_elementId, _attachmentId);
        }
    }
}
