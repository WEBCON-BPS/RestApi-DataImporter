using WEBCON.BPS.Importer.Logic;

namespace WEBCON.BPS.Importer.Model
{
    public class AttachmentData
    {
        public int ElementId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public ElementAttachmentsProvider AttachmentProvider { get; set; }
    }
}
