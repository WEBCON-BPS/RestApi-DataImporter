using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Logic
{
    public class MetadataProvider
    {
        private readonly Dictionary<int, MetadataModel> _appsMetadataDic = new Dictionary<int, MetadataModel>();
        private static readonly object _lock = new object();
        private ApiManager _apiManager;

        public MetadataProvider(ApiManager apiManager)
        {
            _apiManager = apiManager;
        }

        public async Task<MetadataModel> GetModel(int appId)
        {
            if (!_appsMetadataDic.ContainsKey(appId))
                await SynchronizeAppData(appId);

            return _appsMetadataDic[appId];
        }

        private async Task SynchronizeAppData(int appId)
        {
            if (_appsMetadataDic.ContainsKey(appId))
                return;

            var processes = await _apiManager.GetProcesses(appId);
            var metadata = new MetadataModel();

            foreach (var process in processes)
                metadata.Append(await GetDataForProcess(process.id));

            await AppendReports(appId, metadata);

            lock (_lock)
            {
                if(!_appsMetadataDic.ContainsKey(appId))
                    _appsMetadataDic.Add(appId, metadata);
            }
        }

        private async Task AppendReports(int appId, MetadataModel model)
        {
            var reports = await _apiManager.GetReportsMetadata(appId);
            var tasks = reports.Select(s => BuildReportAsync(s.id, s.name)).ToArray();
            var reportsData = await Task.WhenAll(tasks);

            model.Reports = reportsData.ToDictionary(r => r.id, r => r);
        }

        private async Task<Report> BuildReportAsync(int id, string name)
        {
            var report = new Report();

            report.id = id;
            report.name = name;
            report.Views = (await _apiManager.GetReportViews(id)).ToDictionary(v => v.id, v => v.name);

            return report;
        }

        private async Task<MetadataModel> GetDataForProcess(int processId)
        {
            var formTypes = await _apiManager.GetFormTypesByProcessId(processId);
            var workflows = await _apiManager.GetWorkflowsByProcessesId(processId);

            var tasks = workflows.Select(workflow => BuildWorkflow(workflow.id, workflow.name)).ToArray();
            var workflowsData = await Task.WhenAll(tasks);

            return new MetadataModel()
            {
                Formtypes = formTypes.ToDictionary(f => f.id, f => f.name),
                Workflows = workflowsData.ToDictionary(w => w.id, w => w)
            };
        }

        private async Task<Workflow> BuildWorkflow(int id, string name)
        {
            var workflow = new Workflow();

            workflow.name = name;
            workflow.id = id;
            workflow.Steps = await GetWorkflowSteps(id);
            workflow.AssociatedFormTypes = (await _apiManager.GetWorkflowsAssosiatedFormTypes(id)).ToDictionary(form => form.id, form => form.name);
            
            return workflow;
        }

        private async Task<Dictionary<int, Step>> GetWorkflowSteps(int workflowId)
        {
            var result = new Dictionary<int, Step>();
            var steps = await _apiManager.GetStepsByWorkflowId(workflowId);

            var tasks = steps.Select(s => BuildStep(s.id, s.name)).ToArray();
            var stepsData = await Task.WhenAll(tasks);

            return stepsData.ToDictionary(s => s.id, s => s);
        }

        private async Task<Step> BuildStep(int id, string name)
        {
            var step = new Step();

            step.id = id;
            step.name = name;
            step.Paths = (await _apiManager.GetStepsPaths(id)).ToDictionary(s => s.id, s => s.name);

            return step;
        }
    }
}
