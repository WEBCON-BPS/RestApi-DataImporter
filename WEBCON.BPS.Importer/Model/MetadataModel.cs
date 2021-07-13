using System.Collections.Generic;

namespace WEBCON.BPS.Importer.Model
{
    public class MetadataModel
    {
        public Dictionary<int, string> Formtypes { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, Workflow> Workflows { get; set; } = new Dictionary<int, Workflow>();
        public Dictionary<int, Report> Reports { get; set; } = new Dictionary<int, Report>();

        public void Append(MetadataModel model)
        {
            foreach(var form in model.Formtypes)
                if (!Formtypes.ContainsKey(form.Key))
                    Formtypes.Add(form.Key, form.Value);

            foreach(var wf in model.Workflows)
                if (!Workflows.ContainsKey(wf.Key))
                    Workflows.Add(wf.Key, wf.Value);
        }
    }

    public class Workflow
    {
        public int id { get; set; }
        public string name { get; set; }
        public Dictionary<int, Step> Steps { get; set; } = new Dictionary<int, Step>();
        public Dictionary<int, string> AssociatedFormTypes { get; set; } = new Dictionary<int, string>();
    }

    public class Step
    {
        public int id { get; set; }
        public string name { get; set; }
        public Dictionary<int, string> Paths { get; set; } = new Dictionary<int, string>();
    }

    public class Report
    {
        public int id { get; set; }
        public string name { get; set; }
        public Dictionary<int, string> Views { get; set; } = new Dictionary<int, string>();
    }
}
