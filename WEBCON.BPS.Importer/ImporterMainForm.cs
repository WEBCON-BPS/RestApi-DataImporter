using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    DbId = Convert.ToInt32(tbDBID.Text)
                };

                if (int.TryParse(tbExportReport.Text, out var report))
                    config.ReportId = report;

                if (int.TryParse(tbExportView.Text, out var view))
                    config.ViewId = view;

                if (int.TryParse(Page_TextBox.Text, out var page))
                    config.Page = page;

                if (int.TryParse(Size_TextBox.Text, out var size))
                    config.Size = size;

                return config;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in prepare config:Message" + ex.Message, ex);
            }
        }

        private async void tbConnect_Click(object sender, EventArgs e)
        {
            var config = PrepareConfig();
            var clientProvider = new AutenticatedClientProvider(config);

            if (config.PortalUrl == "/" || string.IsNullOrEmpty(config.PortalUrl) || string.IsNullOrEmpty(config.ClientId) || string.IsNullOrEmpty(config.ClientSecret))
            {
                MessageBox.Show("Fill connection configuration");
                return;
            }

            await SetApplications(config, clientProvider);

            cbImportMode.SelectedIndex = 0;
        }

        private async Task SetApplications(Configuration config, AutenticatedClientProvider clientProvider)
        {
            using (var client = await clientProvider.GetClientAsync())
            {
                var apiManager = new ApiManager(client, config);
                var apps = (await apiManager.GetApplicationsAsync()).ToDictionary(app => app.id, app => app.name);
                var bindingSource = new BindingSource(apps, null);

                cbApplications.DataSource = bindingSource;
                cbApplications.ValueMember = "Key";
                cbApplications.DisplayMember = "Value";

                cbApplications.Enabled = true;
                tabMain.Enabled = true;
                tabMain.Visible = true;

                tbApp.DataBindings.Clear();
                tbApp.DataBindings.Add("Text", bindingSource, "Key");

                if (int.TryParse(Properties.Settings.Default.ApplicationID, out var id) && id >= 0 && id < bindingSource.Count)
                    cbApplications.SelectedIndex = id;
            }
        }

        private async void btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "Export";
                saveFileDialog1.Filter = "MS ExcelFiles( *.xlsx)|*.xlsx|All files (*.*)|*.*";
                btn_Export.Text = "Exporting";
                btn_Export.Enabled = false;
                tabMain.Enabled = false;

                var builder = new ExcelBuilder(cbSubs.Checked, cbAttachments.Checked, tbExportFilesPath.Text);
                var config = PrepareConfig();
                var clientProvider = new AutenticatedClientProvider(config);

                using (var client = await clientProvider.GetClientAsync())
                {
                    var apiManager = new ApiManager(client, config);
                    var report = await apiManager.GetReportDataAsync(tbApp.Text);
                    var (elements, attachments) = GetElementsAndAttachmentsIfNeeded(report.Rows, apiManager);

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        var workbook = await builder.BuildDataSheetAsync(report, elements, attachments);
                        workbook.Save(saveFileDialog1.FileName);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} .. {ex.StackTrace}");
            }
            finally
            {
                btn_Export.Text = "Export";
                btn_Export.Enabled = true;
                tabMain.Enabled = true;
                StoreLastValue();
            }
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
            if (!int.TryParse(tbTempDocTypeID.Text, out var formType) || !int.TryParse(tbTempStepID.Text, out var stepId))
            {
                MessageBox.Show("Make sure that StepID and DocTypeId have correct numeric values");
                return;
            }

            try
            {
                var builder = new ExcelBuilder(true, true, string.Empty);
                var config = PrepareConfig();
                var clientProvider = new AutenticatedClientProvider(config);

                saveFileDialog1.FileName = "Template.xlsx";
                saveFileDialog1.Filter = "MS ExcelFiles( *.xlsx)|*.xlsx|All files (*.*)|*.*";

                using (var client = await clientProvider.GetClientAsync())
                {
                    var apiManager = new ApiManager(client, config);
                    var data = await apiManager.GetFormTemplateAsync(formType, stepId);

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        var workbook = builder.BuildTemplate(data);
                        workbook.Save(saveFileDialog1.FileName);
                    }
                }

                btn_Export.Text = "Export";
                btn_Export.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} .. {ex.StackTrace}");
            }
            finally
            {
                StoreLastValue();
            }
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            using (var fldrDlg = new FolderBrowserDialog())
            {
                if (fldrDlg.ShowDialog() == DialogResult.OK)
                {
                    tbExportFilesPath.Text = fldrDlg.SelectedPath;
                }
            }
        }

        private void cbAttachments_CheckStateChanged(object sender, EventArgs e)
        {
            tbExportFilesPath.Visible = cbAttachments.Checked;
            btnChooseFolder.Visible = cbAttachments.Checked;
        }

        private async void btn_Import_Click(object sender, EventArgs e)
        {
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
                    var clientProvider = new AutenticatedClientProvider(config);
                    using (var client = await clientProvider.GetClientAsync())
                    {
                        var apiManager = new ApiManager(client, config);
                        var reader = new ExcelReader(tbStartFile.Text);
                        var data = reader.GetImportData(sheetName);
                        var counter = new ProgressCounter(data.Rows.Count());

                        switch ((Enums.ImportMode) cbImportMode.SelectedIndex)
                        {
                            case Enums.ImportMode.StartOnly:
                                {
                                    var max = Math.Min(data.Rows.Count(), (int)MaxImportNum_UpDown.Value);
                                    for (int i = 0; i < max; i++)
                                    {
                                        var result = await apiManager.StartElementAsync(data.Columns, data.Rows.ElementAt(i), tbStartWF.Text, tbStartDocType.Text, tbStartPath.Text);
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
                                        var result = await apiManager.UpdateElementAsync(data.Columns, data.Rows.ElementAt(i), tbStartPath.Text);
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
                                            result = await apiManager.UpdateElementAsync(data.Columns, row, tbStartPath.Text);
                                        else
                                            result = await apiManager.StartElementAsync(data.Columns, row, tbStartWF.Text, tbStartDocType.Text, tbStartPath.Text);

                                        counter.Append(result);
                                        reader.AppendResult(result, i);
                                        SetProgress(i, max, counter);
                                    }
                                    break;
                                }
                        }

                        reader.SaveReport(tbStartFile.Text);
                    }
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message + ".." + ex1.StackTrace);
                }
                finally
                {
                    StoreLastValue();
                    btn_Import.Enabled = true;
                    btn_Import.Text = "Import";
                    tabMain.Enabled = true;
                }
            }
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
            importProgressBar.Value = (int)Math.Round((double)(100 * current) / (max - 1));

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
            tbStartDocType.Text = Properties.Settings.Default.DocTypeID;
            tbStartWF.Text = Properties.Settings.Default.WorkFlowID;
            tbStartPath.Text = Properties.Settings.Default.PathID;
            tbExportFilesPath.Text = Properties.Settings.Default.ExportPath;
            tbUser.Text = Properties.Settings.Default.User;
            tbTempStepID.Text = Properties.Settings.Default.TemplateStepID;
            tbTempDocTypeID.Text = Properties.Settings.Default.TemplateDocTypeID;
            tbDBID.Text = Properties.Settings.Default.DBID;
        }
        private void StoreLastValue()
        {
            Properties.Settings.Default.Server = tbPortal.Text;
            Properties.Settings.Default.clientSecret = tbSecret.Text;
            Properties.Settings.Default.clientID = tbClientID.Text;
            Properties.Settings.Default.Report = tbExportReport.Text;
            Properties.Settings.Default.ViewID = tbExportView.Text;
            Properties.Settings.Default.DocTypeID = tbStartDocType.Text;
            Properties.Settings.Default.WorkFlowID = tbStartWF.Text;
            Properties.Settings.Default.PathID = tbStartPath.Text;
            Properties.Settings.Default.ExportPath = tbExportFilesPath.Text;
            Properties.Settings.Default.User = tbUser.Text;
            Properties.Settings.Default.TemplateStepID = tbTempStepID.Text;
            Properties.Settings.Default.TemplateDocTypeID = tbTempDocTypeID.Text;
            Properties.Settings.Default.DBID = tbDBID.Text;
            Properties.Settings.Default.ApplicationID = cbApplications.SelectedIndex.ToString();
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}