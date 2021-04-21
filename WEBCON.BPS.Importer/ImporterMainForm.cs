using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using WEBCON.BPS.Importer.Helpers;
using WEBCON.BPS.Importer.Logic;
using WEBCON.BPS.Importer.Model;
using License = Aspose.Cells.License;

namespace WEBCON.BPS.Importer.Forms
{
    public partial class ImporterMainForm : Form
    {
        private MetadataProvider _metadataProvider;
        private ExceptionsHandler _exceptionsHandler = new ExceptionsHandler();
        private HttpClient _client;

        public ImporterMainForm()
        {
            InitializeComponent();
            var license = new License();
            //license.SetLicense("Aspose.Total.lic");
            LoadLastValue();
        }

        private Configuration PrepareConfig()
        {
            try
            {
                var config = new Configuration
                {
                    ClientId = tbClientID.Text,
                    ClientSecret = tbSecret.Text,
                    ImpersonationLogin = tbUser.Text,
                    PortalUrl = tbPortal.Text,
                    DbId = Convert.ToInt32(tbDBID.Value)
                };

                if (int.TryParse(tbExportReport.Text, out var report))
                    config.ReportId = report;

                if (int.TryParse(tbExportView.Text, out var view))
                    config.ViewId = view;

                config.Page = Convert.ToInt32(numericPage.Value);
                config.Size = Convert.ToInt32(numericSize.Value);

                return config;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in prepare config:Message" + ex.Message, ex);
            }
        }

        private async void tbConnect_Click(object sender, EventArgs e)
        {
            await _exceptionsHandler.WrapExceptions(async () =>
            {
                var config = PrepareConfig();

                if (config.PortalUrl == "/" || string.IsNullOrEmpty(config.PortalUrl) || string.IsNullOrEmpty(config.ClientId) || string.IsNullOrEmpty(config.ClientSecret))
                {
                    MessageBox.Show("Fill connection configuration");
                    return;
                }

                var clientProvider = new AutenticatedClientProvider(config);
                _client = await clientProvider.GetClientAsync();

                var apiManager = new ApiManager(_client, config);
                _metadataProvider = new MetadataProvider(apiManager);

                await SetApplications(apiManager);
                cbImportMode.SelectedIndex = 0;
            });
        }

        private async Task SetApplications(ApiManager apiManager)
        {
            var apps = (await apiManager.GetApplicationsAsync()).OrderBy(app => app.name).Select(app => new { app.id, app.name }).ToList();
            var bindingSource = new BindingSource(apps, null);

            cbApplications.ValueMember = "id";
            cbApplications.DisplayMember = "name";
            cbApplications.DataSource = bindingSource;

            cbApplications.Enabled = true;
            tabMain.Enabled = true;
            tabMain.Visible = true;

            tbApp.DataBindings.Clear();
            tbApp.DataBindings.Add("Text", bindingSource, "id");

            if (int.TryParse(Properties.Settings.Default.ApplicationID, out var id) && id >= 0 && id < bindingSource.Count)
                cbApplications.SelectedIndex = id;
        }

        private async void btn_Export_Click(object sender, EventArgs e)
        {
            await _exceptionsHandler.WrapExceptions(async () =>
            {
                try
                {
                    var timer = new Stopwatch();
                    timer.Start();

                    saveFileDialog1.FileName = "Export";
                    saveFileDialog1.Filter = "MS ExcelFiles( *.xlsx)|*.xlsx|All files (*.*)|*.*";
                    btn_Export.Text = "Exporting";
                    btn_Export.Enabled = false;
                    tabMain.Enabled = false;

                    var config = PrepareConfig();
                    var apiManager = new ApiManager(_client, config);

                    var report = await apiManager.GetReportDataAsync(tbApp.Text);
                    (ConcurrentBag<ElementData> elements, ConcurrentBag<AttachmentData> attachments) = GetElementsAndAttachmentsIfNeeded(report.Rows, apiManager);

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        var attsPath = Path.Combine(Path.GetDirectoryName(saveFileDialog1.FileName), "attachments");
                        var builder = new ExcelBuilder(cbSubs.Checked, cbAttachments.Checked, attsPath);

                        var workbook = await builder.BuildDataSheetAsync(report, elements, attachments);
                        workbook.Save(saveFileDialog1.FileName);

                        timer.Stop();

                        if (MessageBox.Show($"{report.Rows.Count()} workflow instances have been exported in {timer.Elapsed.TotalSeconds} seconds. Do you want to open the result file?", "Export result", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ProcessStartInfo pi = new ProcessStartInfo(saveFileDialog1.FileName);
                            pi.Arguments = Path.GetFileName(saveFileDialog1.FileName);
                            pi.UseShellExecute = true;
                            pi.WorkingDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);
                            pi.FileName = saveFileDialog1.FileName;
                            pi.Verb = "OPEN";
                            Process.Start(pi);
                        }
                    }
                }
                finally
                {
                    btn_Export.Text = "Export";
                    btn_Export.Enabled = true;
                    tabMain.Enabled = true;
                    StoreLastValue();
                }
            });
        }

        private (ConcurrentBag<ElementData>, ConcurrentBag<AttachmentData>) GetElementsAndAttachmentsIfNeeded(IEnumerable<Row> reportRows, ApiManager apiManager)
        {
            var elements = new ConcurrentBag<ElementData>();
            var attachments = new ConcurrentBag<AttachmentData>();

            if (!cbSubs.Checked && !cbAttachments.Checked)
                return (elements, attachments);

            Parallel.ForEach(reportRows, async (row) =>
            {
                var element = await apiManager.GetElementWithAttachmentsAsync(row.ElementId.ToString());
                elements.Add(element.Element);
                attachments.AddRange(element.Attachments);
            });

            return (elements, attachments);
        }

        private async void btnTemplateGenerate_Click(object sender, EventArgs e)
        {
            await _exceptionsHandler.WrapExceptions(async () =>
            {
                if (!int.TryParse(cbTempFormtypes.SelectedValue?.ToString(), out var formType) || !int.TryParse(cbTempSteps.SelectedValue?.ToString(), out var stepId))
                {
                    MessageBox.Show("Make sure that StepID and DocTypeId have correct numeric values");
                    return;
                }

                try
                {
                    var timer = new Stopwatch();
                    timer.Start();

                    var builder = new ExcelBuilder(true, true, string.Empty);
                    var config = PrepareConfig();

                    saveFileDialog1.FileName = "Template.xlsx";
                    saveFileDialog1.Filter = "MS ExcelFiles( *.xlsx)|*.xlsx|All files (*.*)|*.*";

                    var apiManager = new ApiManager(_client, config);
                    var data = await apiManager.GetFormTemplateAsync(formType, stepId);

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        var workbook = builder.BuildTemplate(data);
                        workbook.Save(saveFileDialog1.FileName);

                        if (MessageBox.Show($"Template has been generated in {timer.Elapsed.TotalSeconds} seconds. Do you want to open the result file?", "Template generation result", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ProcessStartInfo pi = new ProcessStartInfo(saveFileDialog1.FileName);
                            pi.Arguments = Path.GetFileName(saveFileDialog1.FileName);
                            pi.UseShellExecute = true;
                            pi.WorkingDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);
                            pi.FileName = saveFileDialog1.FileName;
                            pi.Verb = "OPEN";
                            Process.Start(pi);
                        }
                    }

                    btn_Export.Text = "Export";
                    btn_Export.Enabled = true;
                }
                finally
                {
                    StoreLastValue();
                }
            });
        }

        private async void btn_Import_Click(object sender, EventArgs e)
        {
            await _exceptionsHandler.WrapExceptions(async () =>
            {
                var timer = new Stopwatch();
                timer.Start();

                ClearProgress();

                if (File.Exists(tbStartFile.Text))
                {
                    try
                    {

                        btn_Import.Enabled = false;
                        btn_Import.Text = "Importing";
                        tabMain.Enabled = false;

                        var import = (Enums.ImportMode)cbImportMode.SelectedIndex;
                        var sheetName = cbImportSheet.SelectedValue.ToString();

                        var config = PrepareConfig();
                        var apiManager = new ApiManager(_client, config);
                        var reader = new ExcelReader(tbStartFile.Text);
                        var data = reader.GetImportData(sheetName);
                        var counter = new ProgressCounter(data.Rows.Count());

                        switch ((Enums.ImportMode)cbImportMode.SelectedIndex)
                        {
                            case Enums.ImportMode.StartOnly:
                                {
                                    var max = Math.Min(data.Rows.Count(), (int)MaxImportNum_UpDown.Value);
                                    for (int i = 0; i < max; i++)
                                    {
                                        var result = await apiManager.StartElementAsync(data.Columns, data.Rows.ElementAt(i), cbImportWorkflows.SelectedValue?.ToString(), cbImportFormtypes.SelectedValue?.ToString(), cbImportPaths.SelectedValue?.ToString());
                                        counter.Append(result);
                                        SetProgress(i, max, counter);
                                        reader.AppendResult(result, i);
                                    }

                                    break;
                                }
                            case Enums.ImportMode.UpdateOnly:
                                {
                                    var max = Math.Min(data.Rows.Count(), (int)MaxImportNum_UpDown.Value);
                                    for (int i = 0; i < max; i++)
                                    {
                                        var result = await apiManager.UpdateElementAsync(data.Columns, data.Rows.ElementAt(i), string.Empty);
                                        counter.Append(result);
                                        SetProgress(i, max, counter);
                                        reader.AppendResult(result, i);
                                    }

                                    break;
                                }
                            case Enums.ImportMode.Dynamic:
                                {
                                    var max = Math.Min(data.Rows.Count(), (int)MaxImportNum_UpDown.Value);
                                    for (int i = 0; i < max; i++)
                                    {
                                        var row = data.Rows.ElementAt(i);
                                        ElementResult result;

                                        if (row.ElementId.HasValue)
                                            result = await apiManager.UpdateElementAsync(data.Columns, row, cbImportPaths.SelectedValue?.ToString());
                                        else
                                            result = await apiManager.StartElementAsync(data.Columns, row, cbImportWorkflows.SelectedValue?.ToString(), cbImportFormtypes.SelectedValue?.ToString(), cbImportPaths.SelectedValue?.ToString());

                                        counter.Append(result);
                                        reader.AppendResult(result, i);
                                        SetProgress(i, max, counter);
                                    }
                                    break;
                                }
                        }

                        reader.SaveReport(tbStartFile.Text);


                        if (MessageBox.Show($"{data.Rows.Count()} workflow instances have been imported in {timer.Elapsed.TotalSeconds} seconds. Do you want to open the result file?", "Import result", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ProcessStartInfo pi = new ProcessStartInfo(saveFileDialog1.FileName);
                            pi.Arguments = Path.GetFileName(saveFileDialog1.FileName);
                            pi.UseShellExecute = true;
                            pi.WorkingDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);
                            pi.FileName = saveFileDialog1.FileName;
                            pi.Verb = "OPEN";
                            Process.Start(pi);
                        }
                    }
                    finally
                    {
                        StoreLastValue();
                        btn_Import.Enabled = true;
                        btn_Import.Text = "Import";
                        tabMain.Enabled = true;
                    }
                }
            });            
        }

        private void btnStartChooseFileToImport_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = Properties.Settings.Default.ImportFile;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbStartFile.Text = openFileDialog1.FileName;
                btn_Import.Enabled = true;
                cbImportSheet.Enabled = true;
                Properties.Settings.Default.ImportFile = tbStartFile.Text;
                Properties.Settings.Default.Save();

                var reader = new ExcelReader(tbStartFile.Text);
                cbImportSheet.DataSource = reader.GetWorksheets().ToList();
                cbImportSheet.SelectedIndex = 0;
            }
        }

        private void SetProgress(int current, int max, ProgressCounter counter)
        {
            importProgressBar.Value = max == 1 ? current/max : (int)Math.Round((double)(100 * current) / (max - 1));

            lElements.Text = counter.Elements.ToString();
            lStarted.Text = counter.Started.ToString();
            lUpdated.Text = counter.Updated.ToString();
            lErrors.Text = counter.Errors.ToString();
        }

        private void ClearProgress()
        {
            importProgressBar.Value = 0;
            lElements.Text = "0";
            lStarted.Text = "0";
            lUpdated.Text = "0";
            lErrors.Text = "0";
        }

        #region Config
        private void LoadLastValue()
        {
            tbPortal.Text = Properties.Settings.Default.Server;
            tbSecret.Text = Properties.Settings.Default.clientSecret;
            tbClientID.Text = Properties.Settings.Default.clientID;
            tbExportReport.Text = Properties.Settings.Default.Report;
            tbExportView.Text = Properties.Settings.Default.ViewID;
            tbUser.Text = Properties.Settings.Default.User;
            tbDBID.Text = Properties.Settings.Default.DBID;
        }
        private void StoreLastValue()
        {
            Properties.Settings.Default.Server = tbPortal.Text;
            Properties.Settings.Default.clientSecret = tbSecret.Text;
            Properties.Settings.Default.clientID = tbClientID.Text;
            Properties.Settings.Default.Report = tbExportReport.Text;
            Properties.Settings.Default.ViewID = tbExportView.Text;
            Properties.Settings.Default.User = tbUser.Text;
            Properties.Settings.Default.DBID = tbDBID.Text;
            Properties.Settings.Default.ApplicationID = cbApplications.SelectedIndex.ToString();
            Properties.Settings.Default.WorkFlowTemp = cbTempWorkflows.SelectedIndex.ToString();
            Properties.Settings.Default.WorkFlowImport = cbImportWorkflows.SelectedIndex.ToString();
            Properties.Settings.Default.Save();
        }
        #endregion

        private async void cbApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(((ComboBox)sender).SelectedValue?.ToString(), out var id) || id < 1)
                return;

            var model = await _metadataProvider.GetModel(id);
            SetWorkflows(model);
        }

        private void SetWorkflows(MetadataModel model)
        {
            cbImportWorkflows.Enabled = cbTempWorkflows.Enabled = false;

            try
            {
                var worfklows = model.Workflows.Select(wf => new { id = wf.Value.id, name = $"{wf.Value.name} ({wf.Value.id})" }).OrderBy(w => w.name).ToList();
                var bindingSource = new BindingSource(worfklows, null);

                cbImportWorkflows.ValueMember = cbTempWorkflows.ValueMember = "id";
                cbImportWorkflows.DisplayMember = cbTempWorkflows.DisplayMember = "name";
                cbImportWorkflows.DataSource = cbTempWorkflows.DataSource = bindingSource;

                if (int.TryParse(Properties.Settings.Default.WorkFlowTemp, out var tid) && tid < bindingSource.Count)
                    cbTempWorkflows.SelectedIndex = tid;

                if (int.TryParse(Properties.Settings.Default.WorkFlowImport, out var iid) && iid < bindingSource.Count)
                    cbTempWorkflows.SelectedIndex = iid;
            }
            finally
            {
                cbImportWorkflows.Enabled = cbTempWorkflows.Enabled = true;
            }
        }

        private async void cbImportWorkflows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(cbApplications.SelectedValue?.ToString(), out var appId) || appId < 1
                || !int.TryParse(((ComboBox)sender).SelectedValue?.ToString(), out var wfId) || wfId < 1)
                return;

            var model = await _metadataProvider.GetModel(appId);
            SetAssosiatedFormTypes(model, wfId, cbImportFormtypes);
            SetPaths(model, wfId);
        }


        private async void cbTempWorkflows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(cbApplications.SelectedValue?.ToString(), out var appId) || appId < 1
                || !int.TryParse(((ComboBox)sender).SelectedValue?.ToString(), out var wfId) || wfId < 1)
                return;

            var model = await _metadataProvider.GetModel(appId);
            SetAssosiatedFormTypes(model, wfId, cbTempFormtypes);
        }

        private void SetAssosiatedFormTypes(MetadataModel model, int workflowId, ComboBox cbFormTypes)
        {
            cbFormTypes.Enabled = false;

            try
            {
                if (!model.Workflows.TryGetValue(workflowId, out var workflow))
                    return;

                var forms = workflow.AssociatedFormTypes.Select(f => new { id = f.Key, name = $"{f.Value} ({f.Key})" }).OrderBy(f => f.name).ToList();
                var bindingSource = new BindingSource(forms, null);

                cbFormTypes.ValueMember = "id";
                cbFormTypes.DisplayMember = "name";
                cbFormTypes.DataSource = bindingSource;

            }
            finally
            {
                cbFormTypes.Enabled = true;
            }
        }

        private void SetPaths(MetadataModel model, int workflowId)
        {
            cbImportPaths.Enabled = false;

            try
            {
                if (!model.Workflows.TryGetValue(workflowId, out var workflow))
                    return;

                var paths = workflow.Steps.SelectMany(s => s.Value.Paths).Select(p => new { id = p.Key, name = $"{p.Value} ({p.Key})" }).ToList();
                var bindingSource = new BindingSource(paths, null);

                cbImportPaths.ValueMember = "id";
                cbImportPaths.DisplayMember = "name";
                cbImportPaths.DataSource = bindingSource;
            }
            finally
            {
                cbImportPaths.Enabled = true;
            }
        }

        private async void cbTempFormytypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(cbApplications.SelectedValue?.ToString(), out var appId) || appId < 1
                || !int.TryParse(((ComboBox)sender).SelectedValue?.ToString(), out var formId) || formId < 1
                || !int.TryParse(cbTempWorkflows.SelectedValue?.ToString(), out var wfId) || formId < 1)
                return;

            var model = await _metadataProvider.GetModel(appId);
            SetSteps(model, formId, wfId);
        }

        private void SetSteps(MetadataModel model, int formId, int wfId)
        {
            cbTempSteps.Enabled = false;

            try
            {
                var steps = model.Workflows
                    .Where(wf => wf.Key == wfId)
                    .Where(wf => wf.Value.AssociatedFormTypes.ContainsKey(formId))
                    .SelectMany(wf => wf.Value.Steps)
                    .Select(s => new { id = s.Value.id, name = $"{s.Value.name} ({s.Value.id})" })
                    .OrderBy(s => s.name).ToList();

                var bindingSource = new BindingSource(steps, null);

                cbTempSteps.ValueMember = "id";
                cbTempSteps.DisplayMember = "name";
                cbTempSteps.DataSource = bindingSource;
            }
            finally
            {
                cbTempSteps.Enabled = true;
            }
        }

        private void cbImportMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = (Enums.ImportMode)(((ComboBox)sender).SelectedIndex);

            if(mode == Enums.ImportMode.UpdateOnly)
            {
                cbImportFormtypes.Enabled = false;
                cbImportWorkflows.Enabled = false;
                cbImportPaths.Enabled = false;
            }
            else
            {
                cbImportFormtypes.Enabled = true;
                cbImportWorkflows.Enabled = true;
                cbImportPaths.Enabled = true;
            }
        }
    }
}