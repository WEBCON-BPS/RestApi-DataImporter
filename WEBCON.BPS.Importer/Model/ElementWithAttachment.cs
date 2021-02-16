using System.Collections.Generic;

namespace WEBCON.BPS.Importer.Model
{
    public class ElementWithAttachment
    {
        public ElementData Element { get; set; } = new ElementData();
        public List<AttachmentData> Attachments { get; set; } = new List<AttachmentData>();
    }
}
