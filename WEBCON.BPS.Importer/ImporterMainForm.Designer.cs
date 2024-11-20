namespace WEBCON.BPS.Importer.Forms
{
    partial class ImporterMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImporterMainForm));
            this.btn_Import = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lElements = new System.Windows.Forms.Label();
            this.bgImporter = new System.ComponentModel.BackgroundWorker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbExportView = new System.Windows.Forms.ComboBox();
            this.cbExportReport = new System.Windows.Forms.ComboBox();
            this.numericPage = new System.Windows.Forms.NumericUpDown();
            this.numericSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.lExportElapsed = new System.Windows.Forms.Label();
            this.cbAttachments = new System.Windows.Forms.CheckBox();
            this.cbSubs = new System.Windows.Forms.CheckBox();
            this.Size_Label = new System.Windows.Forms.Label();
            this.Page_Lable = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.exportProgressBar = new System.Windows.Forms.ProgressBar();
            this.lexportReport = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbTempWorkflows = new System.Windows.Forms.ComboBox();
            this.labelTempWorkflows = new System.Windows.Forms.Label();
            this.cbTempSteps = new System.Windows.Forms.ComboBox();
            this.cbTempFormtypes = new System.Windows.Forms.ComboBox();
            this.labelTempSteps = new System.Windows.Forms.Label();
            this.labelTempFormtypes = new System.Windows.Forms.Label();
            this.btnTemplateGenerate = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbImportSheet = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartChooseFileToImport = new System.Windows.Forms.Button();
            this.tbStartFile = new System.Windows.Forms.TextBox();
            this.cbImportPaths = new System.Windows.Forms.ComboBox();
            this.cbImportWorkflows = new System.Windows.Forms.ComboBox();
            this.cbImportFormtypes = new System.Windows.Forms.ComboBox();
            this.MaxImportNum_Label = new System.Windows.Forms.Label();
            this.MaxImportNum_UpDown = new System.Windows.Forms.NumericUpDown();
            this.lErrors = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lImportElapsed = new System.Windows.Forms.Label();
            this.lUpdated = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lStarted = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.importProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.cbImportMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bgExporter = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDBID = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSecret = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPortal = new System.Windows.Forms.TextBox();
            this.cbApplications = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbApp = new System.Windows.Forms.TextBox();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxImportNum_UpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDBID)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Import
            // 
            this.btn_Import.Enabled = false;
            this.btn_Import.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Import.ForeColor = System.Drawing.Color.Green;
            this.btn_Import.Location = new System.Drawing.Point(377, 220);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(136, 43);
            this.btn_Import.TabIndex = 7;
            this.btn_Import.Text = "Import";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "export.xlsx";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.FileName = "export.xlsx";
            this.saveFileDialog1.InitialDirectory = "c:\\";
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Export.ForeColor = System.Drawing.Color.Green;
            this.btn_Export.Location = new System.Drawing.Point(377, 190);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(136, 43);
            this.btn_Export.TabIndex = 4;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Processing";
            // 
            // lElements
            // 
            this.lElements.AutoSize = true;
            this.lElements.Location = new System.Drawing.Point(357, 188);
            this.lElements.Name = "lElements";
            this.lElements.Size = new System.Drawing.Size(13, 13);
            this.lElements.TabIndex = 33;
            this.lElements.Text = "0";
            // 
            // bgImporter
            // 
            this.bgImporter.WorkerReportsProgress = true;
            this.bgImporter.WorkerSupportsCancellation = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Report Id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Path (optional)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Form type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Workflow";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Enabled = false;
            this.tabMain.Location = new System.Drawing.Point(4, 152);
            this.tabMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(528, 292);
            this.tabMain.TabIndex = 0;
            this.tabMain.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbExportView);
            this.tabPage1.Controls.Add(this.cbExportReport);
            this.tabPage1.Controls.Add(this.numericPage);
            this.tabPage1.Controls.Add(this.numericSize);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.Size_Label);
            this.tabPage1.Controls.Add(this.Page_Lable);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.exportProgressBar);
            this.tabPage1.Controls.Add(this.lexportReport);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.btn_Export);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(520, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Export";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbExportView
            // 
            this.cbExportView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportView.Enabled = false;
            this.cbExportView.FormattingEnabled = true;
            this.cbExportView.Location = new System.Drawing.Point(128, 39);
            this.cbExportView.Margin = new System.Windows.Forms.Padding(2);
            this.cbExportView.Name = "cbExportView";
            this.cbExportView.Size = new System.Drawing.Size(385, 21);
            this.cbExportView.TabIndex = 57;
            // 
            // cbExportReport
            // 
            this.cbExportReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportReport.Enabled = false;
            this.cbExportReport.FormattingEnabled = true;
            this.cbExportReport.Location = new System.Drawing.Point(128, 15);
            this.cbExportReport.Margin = new System.Windows.Forms.Padding(2);
            this.cbExportReport.Name = "cbExportReport";
            this.cbExportReport.Size = new System.Drawing.Size(385, 21);
            this.cbExportReport.TabIndex = 56;
            this.cbExportReport.SelectedIndexChanged += new System.EventHandler(this.cbExportReport_SelectedIndexChanged);
            // 
            // numericPage
            // 
            this.numericPage.Location = new System.Drawing.Point(128, 66);
            this.numericPage.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPage.Name = "numericPage";
            this.numericPage.Size = new System.Drawing.Size(385, 20);
            this.numericPage.TabIndex = 55;
            this.numericPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericSize
            // 
            this.numericSize.Location = new System.Drawing.Point(128, 92);
            this.numericSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSize.Name = "numericSize";
            this.numericSize.Size = new System.Drawing.Size(385, 20);
            this.numericSize.TabIndex = 54;
            this.numericSize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lExportElapsed);
            this.groupBox2.Controls.Add(this.cbAttachments);
            this.groupBox2.Controls.Add(this.cbSubs);
            this.groupBox2.Location = new System.Drawing.Point(7, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 97);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional data";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(221, 13);
            this.label23.TabIndex = 48;
            this.label23.Text = "Exporting additional data will take longer time.";
            // 
            // lExportElapsed
            // 
            this.lExportElapsed.AutoSize = true;
            this.lExportElapsed.Location = new System.Drawing.Point(292, 65);
            this.lExportElapsed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lExportElapsed.Name = "lExportElapsed";
            this.lExportElapsed.Size = new System.Drawing.Size(0, 13);
            this.lExportElapsed.TabIndex = 47;
            // 
            // cbAttachments
            // 
            this.cbAttachments.AutoSize = true;
            this.cbAttachments.Location = new System.Drawing.Point(9, 66);
            this.cbAttachments.Margin = new System.Windows.Forms.Padding(2);
            this.cbAttachments.Name = "cbAttachments";
            this.cbAttachments.Size = new System.Drawing.Size(122, 17);
            this.cbAttachments.TabIndex = 1;
            this.cbAttachments.Text = "Include attachments";
            this.cbAttachments.UseVisualStyleBackColor = true;
            // 
            // cbSubs
            // 
            this.cbSubs.AutoSize = true;
            this.cbSubs.Location = new System.Drawing.Point(9, 41);
            this.cbSubs.Margin = new System.Windows.Forms.Padding(2);
            this.cbSubs.Name = "cbSubs";
            this.cbSubs.Size = new System.Drawing.Size(123, 17);
            this.cbSubs.TabIndex = 0;
            this.cbSubs.Text = "Include subelements";
            this.cbSubs.UseVisualStyleBackColor = true;
            // 
            // Size_Label
            // 
            this.Size_Label.AutoSize = true;
            this.Size_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Size_Label.Location = new System.Drawing.Point(11, 89);
            this.Size_Label.Name = "Size_Label";
            this.Size_Label.Size = new System.Drawing.Size(27, 13);
            this.Size_Label.TabIndex = 52;
            this.Size_Label.Text = "Size";
            // 
            // Page_Lable
            // 
            this.Page_Lable.AutoSize = true;
            this.Page_Lable.Location = new System.Drawing.Point(11, 66);
            this.Page_Lable.Name = "Page_Lable";
            this.Page_Lable.Size = new System.Drawing.Size(32, 13);
            this.Page_Lable.TabIndex = 50;
            this.Page_Lable.Text = "Page";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 49;
            this.label18.Text = "View Id";
            // 
            // exportProgressBar
            // 
            this.exportProgressBar.Location = new System.Drawing.Point(6, 238);
            this.exportProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.exportProgressBar.Name = "exportProgressBar";
            this.exportProgressBar.Size = new System.Drawing.Size(365, 13);
            this.exportProgressBar.TabIndex = 46;
            // 
            // lexportReport
            // 
            this.lexportReport.AutoSize = true;
            this.lexportReport.Location = new System.Drawing.Point(438, 238);
            this.lexportReport.Name = "lexportReport";
            this.lexportReport.Size = new System.Drawing.Size(13, 13);
            this.lexportReport.TabIndex = 45;
            this.lexportReport.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(382, 238);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Elements";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbTempWorkflows);
            this.tabPage4.Controls.Add(this.labelTempWorkflows);
            this.tabPage4.Controls.Add(this.cbTempSteps);
            this.tabPage4.Controls.Add(this.cbTempFormtypes);
            this.tabPage4.Controls.Add(this.labelTempSteps);
            this.tabPage4.Controls.Add(this.labelTempFormtypes);
            this.tabPage4.Controls.Add(this.btnTemplateGenerate);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(520, 266);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Generate template";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbTempWorkflows
            // 
            this.cbTempWorkflows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTempWorkflows.Enabled = false;
            this.cbTempWorkflows.FormattingEnabled = true;
            this.cbTempWorkflows.Location = new System.Drawing.Point(128, 16);
            this.cbTempWorkflows.Margin = new System.Windows.Forms.Padding(2);
            this.cbTempWorkflows.Name = "cbTempWorkflows";
            this.cbTempWorkflows.Size = new System.Drawing.Size(385, 21);
            this.cbTempWorkflows.TabIndex = 50;
            this.cbTempWorkflows.SelectedIndexChanged += new System.EventHandler(this.cbTempWorkflows_SelectedIndexChanged);
            // 
            // labelTempWorkflows
            // 
            this.labelTempWorkflows.AutoSize = true;
            this.labelTempWorkflows.Location = new System.Drawing.Point(10, 18);
            this.labelTempWorkflows.Name = "labelTempWorkflows";
            this.labelTempWorkflows.Size = new System.Drawing.Size(52, 13);
            this.labelTempWorkflows.TabIndex = 51;
            this.labelTempWorkflows.Text = "Workflow";
            // 
            // cbTempSteps
            // 
            this.cbTempSteps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTempSteps.Enabled = false;
            this.cbTempSteps.FormattingEnabled = true;
            this.cbTempSteps.Location = new System.Drawing.Point(128, 63);
            this.cbTempSteps.Margin = new System.Windows.Forms.Padding(2);
            this.cbTempSteps.Name = "cbTempSteps";
            this.cbTempSteps.Size = new System.Drawing.Size(385, 21);
            this.cbTempSteps.TabIndex = 1;
            // 
            // cbTempFormtypes
            // 
            this.cbTempFormtypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTempFormtypes.Enabled = false;
            this.cbTempFormtypes.FormattingEnabled = true;
            this.cbTempFormtypes.Location = new System.Drawing.Point(128, 39);
            this.cbTempFormtypes.Margin = new System.Windows.Forms.Padding(2);
            this.cbTempFormtypes.Name = "cbTempFormtypes";
            this.cbTempFormtypes.Size = new System.Drawing.Size(385, 21);
            this.cbTempFormtypes.TabIndex = 0;
            this.cbTempFormtypes.SelectedIndexChanged += new System.EventHandler(this.cbTempFormytypes_SelectedIndexChanged);
            // 
            // labelTempSteps
            // 
            this.labelTempSteps.AutoSize = true;
            this.labelTempSteps.Location = new System.Drawing.Point(10, 66);
            this.labelTempSteps.Name = "labelTempSteps";
            this.labelTempSteps.Size = new System.Drawing.Size(29, 13);
            this.labelTempSteps.TabIndex = 49;
            this.labelTempSteps.Text = "Step";
            // 
            // labelTempFormtypes
            // 
            this.labelTempFormtypes.AutoSize = true;
            this.labelTempFormtypes.Location = new System.Drawing.Point(10, 42);
            this.labelTempFormtypes.Name = "labelTempFormtypes";
            this.labelTempFormtypes.Size = new System.Drawing.Size(56, 13);
            this.labelTempFormtypes.TabIndex = 47;
            this.labelTempFormtypes.Text = "Form  type";
            // 
            // btnTemplateGenerate
            // 
            this.btnTemplateGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTemplateGenerate.ForeColor = System.Drawing.Color.Green;
            this.btnTemplateGenerate.Location = new System.Drawing.Point(377, 220);
            this.btnTemplateGenerate.Name = "btnTemplateGenerate";
            this.btnTemplateGenerate.Size = new System.Drawing.Size(136, 43);
            this.btnTemplateGenerate.TabIndex = 2;
            this.btnTemplateGenerate.Text = "Generate";
            this.btnTemplateGenerate.UseVisualStyleBackColor = true;
            this.btnTemplateGenerate.Click += new System.EventHandler(this.btnTemplateGenerate_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbImportSheet);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnStartChooseFileToImport);
            this.tabPage2.Controls.Add(this.tbStartFile);
            this.tabPage2.Controls.Add(this.cbImportPaths);
            this.tabPage2.Controls.Add(this.cbImportWorkflows);
            this.tabPage2.Controls.Add(this.cbImportFormtypes);
            this.tabPage2.Controls.Add(this.MaxImportNum_Label);
            this.tabPage2.Controls.Add(this.MaxImportNum_UpDown);
            this.tabPage2.Controls.Add(this.lErrors);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.lImportElapsed);
            this.tabPage2.Controls.Add(this.lUpdated);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.lStarted);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.importProgressBar);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbImportMode);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.lElements);
            this.tabPage2.Controls.Add(this.btn_Import);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(520, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbImportSheet
            // 
            this.cbImportSheet.Enabled = false;
            this.cbImportSheet.FormattingEnabled = true;
            this.cbImportSheet.Items.AddRange(new object[] {
            "First"});
            this.cbImportSheet.Location = new System.Drawing.Point(128, 37);
            this.cbImportSheet.Margin = new System.Windows.Forms.Padding(2);
            this.cbImportSheet.Name = "cbImportSheet";
            this.cbImportSheet.Size = new System.Drawing.Size(385, 21);
            this.cbImportSheet.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 83;
            this.label15.Text = "Excel Sheet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "ImportFile";
            // 
            // btnStartChooseFileToImport
            // 
            this.btnStartChooseFileToImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartChooseFileToImport.Location = new System.Drawing.Point(381, 8);
            this.btnStartChooseFileToImport.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartChooseFileToImport.Name = "btnStartChooseFileToImport";
            this.btnStartChooseFileToImport.Size = new System.Drawing.Size(132, 23);
            this.btnStartChooseFileToImport.TabIndex = 0;
            this.btnStartChooseFileToImport.Text = "Choose file";
            this.btnStartChooseFileToImport.UseVisualStyleBackColor = true;
            this.btnStartChooseFileToImport.Click += new System.EventHandler(this.btnStartChooseFileToImport_Click);
            // 
            // tbStartFile
            // 
            this.tbStartFile.Enabled = false;
            this.tbStartFile.Location = new System.Drawing.Point(128, 10);
            this.tbStartFile.Margin = new System.Windows.Forms.Padding(2);
            this.tbStartFile.Name = "tbStartFile";
            this.tbStartFile.Size = new System.Drawing.Size(243, 20);
            this.tbStartFile.TabIndex = 2;
            // 
            // cbImportPaths
            // 
            this.cbImportPaths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImportPaths.Enabled = false;
            this.cbImportPaths.FormattingEnabled = true;
            this.cbImportPaths.Location = new System.Drawing.Point(128, 137);
            this.cbImportPaths.Margin = new System.Windows.Forms.Padding(2);
            this.cbImportPaths.Name = "cbImportPaths";
            this.cbImportPaths.Size = new System.Drawing.Size(385, 21);
            this.cbImportPaths.TabIndex = 5;
            // 
            // cbImportWorkflows
            // 
            this.cbImportWorkflows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImportWorkflows.Enabled = false;
            this.cbImportWorkflows.FormattingEnabled = true;
            this.cbImportWorkflows.Location = new System.Drawing.Point(128, 87);
            this.cbImportWorkflows.Margin = new System.Windows.Forms.Padding(2);
            this.cbImportWorkflows.Name = "cbImportWorkflows";
            this.cbImportWorkflows.Size = new System.Drawing.Size(385, 21);
            this.cbImportWorkflows.TabIndex = 3;
            this.cbImportWorkflows.SelectedIndexChanged += new System.EventHandler(this.cbImportWorkflows_SelectedIndexChanged);
            // 
            // cbImportFormtypes
            // 
            this.cbImportFormtypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImportFormtypes.Enabled = false;
            this.cbImportFormtypes.FormattingEnabled = true;
            this.cbImportFormtypes.Location = new System.Drawing.Point(128, 112);
            this.cbImportFormtypes.Margin = new System.Windows.Forms.Padding(2);
            this.cbImportFormtypes.Name = "cbImportFormtypes";
            this.cbImportFormtypes.Size = new System.Drawing.Size(385, 21);
            this.cbImportFormtypes.TabIndex = 4;
            // 
            // MaxImportNum_Label
            // 
            this.MaxImportNum_Label.AutoSize = true;
            this.MaxImportNum_Label.Location = new System.Drawing.Point(10, 163);
            this.MaxImportNum_Label.Name = "MaxImportNum_Label";
            this.MaxImportNum_Label.Size = new System.Drawing.Size(95, 13);
            this.MaxImportNum_Label.TabIndex = 63;
            this.MaxImportNum_Label.Text = "Max rows to import";
            // 
            // MaxImportNum_UpDown
            // 
            this.MaxImportNum_UpDown.Location = new System.Drawing.Point(128, 163);
            this.MaxImportNum_UpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.MaxImportNum_UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxImportNum_UpDown.Name = "MaxImportNum_UpDown";
            this.MaxImportNum_UpDown.Size = new System.Drawing.Size(385, 20);
            this.MaxImportNum_UpDown.TabIndex = 6;
            this.MaxImportNum_UpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lErrors
            // 
            this.lErrors.AutoSize = true;
            this.lErrors.ForeColor = System.Drawing.Color.Red;
            this.lErrors.Location = new System.Drawing.Point(357, 234);
            this.lErrors.Name = "lErrors";
            this.lErrors.Size = new System.Drawing.Size(13, 13);
            this.lErrors.TabIndex = 61;
            this.lErrors.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(295, 234);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 60;
            this.label20.Text = "Erros";
            // 
            // lImportElapsed
            // 
            this.lImportElapsed.AutoSize = true;
            this.lImportElapsed.Location = new System.Drawing.Point(282, 193);
            this.lImportElapsed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lImportElapsed.Name = "lImportElapsed";
            this.lImportElapsed.Size = new System.Drawing.Size(0, 13);
            this.lImportElapsed.TabIndex = 59;
            // 
            // lUpdated
            // 
            this.lUpdated.AutoSize = true;
            this.lUpdated.Location = new System.Drawing.Point(357, 218);
            this.lUpdated.Name = "lUpdated";
            this.lUpdated.Size = new System.Drawing.Size(13, 13);
            this.lUpdated.TabIndex = 58;
            this.lUpdated.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(295, 218);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 57;
            this.label21.Text = "Updates";
            // 
            // lStarted
            // 
            this.lStarted.AutoSize = true;
            this.lStarted.Location = new System.Drawing.Point(357, 203);
            this.lStarted.Name = "lStarted";
            this.lStarted.Size = new System.Drawing.Size(13, 13);
            this.lStarted.TabIndex = 56;
            this.lStarted.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(294, 203);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 55;
            this.label19.Text = "Started";
            // 
            // importProgressBar
            // 
            this.importProgressBar.Location = new System.Drawing.Point(7, 249);
            this.importProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.importProgressBar.Name = "importProgressBar";
            this.importProgressBar.Size = new System.Drawing.Size(364, 13);
            this.importProgressBar.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 60);
            this.label2.TabIndex = 51;
            this.label2.Text = "Excel columns:\r\n  WFDID    (for update/dynamic)\r\n  PATHID   (for dynamic) \r\n  Att" +
    "achments";
            // 
            // cbImportMode
            // 
            this.cbImportMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImportMode.FormattingEnabled = true;
            this.cbImportMode.Items.AddRange(new object[] {
            "Only Start",
            "Only Update",
            "Dynamic (Start / Update / Move)"});
            this.cbImportMode.Location = new System.Drawing.Point(128, 62);
            this.cbImportMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbImportMode.Name = "cbImportMode";
            this.cbImportMode.Size = new System.Drawing.Size(385, 21);
            this.cbImportMode.TabIndex = 2;
            this.cbImportMode.SelectedIndexChanged += new System.EventHandler(this.cbImportMode_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Mode";
            // 
            // bgExporter
            // 
            this.bgExporter.WorkerReportsProgress = true;
            this.bgExporter.WorkerSupportsCancellation = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDBID);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbSecret);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tbClientID);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbPortal);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 110);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication";
            // 
            // tbDBID
            // 
            this.tbDBID.Location = new System.Drawing.Point(454, 14);
            this.tbDBID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbDBID.Name = "tbDBID";
            this.tbDBID.Size = new System.Drawing.Size(63, 20);
            this.tbDBID.TabIndex = 1;
            this.tbDBID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(386, 17);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 13);
            this.label22.TabIndex = 71;
            this.label22.Text = "Database Id:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 68;
            this.label14.Text = "Secret";
            // 
            // tbSecret
            // 
            this.tbSecret.AccessibleDescription = "3e7392e9-906c-42a4-8402-e9abca07af65";
            this.tbSecret.Location = new System.Drawing.Point(132, 61);
            this.tbSecret.Name = "tbSecret";
            this.tbSecret.Size = new System.Drawing.Size(243, 20);
            this.tbSecret.TabIndex = 3;
            this.tbSecret.Tag = "6b90eb4d-e956-40d6-b1b9-27ba81104f55";
            this.tbSecret.Text = "admin";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 67;
            this.label13.Text = "ClientID";
            // 
            // tbClientID
            // 
            this.tbClientID.AccessibleDescription = "59649175-84ab-4419-8dd3-669255c3b01c";
            this.tbClientID.Location = new System.Drawing.Point(132, 37);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(243, 20);
            this.tbClientID.TabIndex = 2;
            this.tbClientID.Tag = "87a70b12-6eb9-4135-bd0e-7971911f2737";
            this.tbClientID.Text = "admin";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConnect.Location = new System.Drawing.Point(381, 43);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(136, 38);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.tbConnect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Portal Url";
            // 
            // tbPortal
            // 
            this.tbPortal.Location = new System.Drawing.Point(132, 14);
            this.tbPortal.Name = "tbPortal";
            this.tbPortal.Size = new System.Drawing.Size(243, 20);
            this.tbPortal.TabIndex = 0;
            this.tbPortal.Text = "https://dev20.webcon.pl:48439/";
            // 
            // cbApplications
            // 
            this.cbApplications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApplications.Enabled = false;
            this.cbApplications.FormattingEnabled = true;
            this.cbApplications.Location = new System.Drawing.Point(136, 124);
            this.cbApplications.Margin = new System.Windows.Forms.Padding(2);
            this.cbApplications.Name = "cbApplications";
            this.cbApplications.Size = new System.Drawing.Size(347, 21);
            this.cbApplications.TabIndex = 0;
            this.cbApplications.SelectedIndexChanged += new System.EventHandler(this.cbApplications_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Application";
            // 
            // tbApp
            // 
            this.tbApp.Enabled = false;
            this.tbApp.Location = new System.Drawing.Point(488, 125);
            this.tbApp.Name = "tbApp";
            this.tbApp.Size = new System.Drawing.Size(33, 20);
            this.tbApp.TabIndex = 72;
            // 
            // ImporterMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(537, 446);
            this.Controls.Add(this.cbApplications);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbApp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(553, 485);
            this.MinimumSize = new System.Drawing.Size(553, 485);
            this.Name = "ImporterMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WEBCON BPS Importer";
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxImportNum_UpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDBID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lElements;
        private System.ComponentModel.BackgroundWorker bgImporter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cbAttachments;
        private System.Windows.Forms.CheckBox cbSubs;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label labelTempSteps;
        private System.Windows.Forms.Label labelTempFormtypes;
        private System.Windows.Forms.Button btnTemplateGenerate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbImportMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgExporter;
        private System.Windows.Forms.Label lexportReport;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ProgressBar exportProgressBar;
        private System.Windows.Forms.ProgressBar importProgressBar;
        private System.Windows.Forms.Label lUpdated;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lStarted;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lExportElapsed;
        private System.Windows.Forms.Label lImportElapsed;
        private System.Windows.Forms.Label lErrors;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label MaxImportNum_Label;
        private System.Windows.Forms.NumericUpDown MaxImportNum_UpDown;
        private System.Windows.Forms.Label Page_Lable;
        private System.Windows.Forms.Label Size_Label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbSecret;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPortal;
        private System.Windows.Forms.ComboBox cbApplications;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbApp;
        private System.Windows.Forms.ComboBox cbTempFormtypes;
        private System.Windows.Forms.ComboBox cbTempSteps;
        private System.Windows.Forms.ComboBox cbImportFormtypes;
        private System.Windows.Forms.ComboBox cbImportWorkflows;
        private System.Windows.Forms.ComboBox cbImportPaths;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbImportSheet;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartChooseFileToImport;
        private System.Windows.Forms.TextBox tbStartFile;
        private System.Windows.Forms.NumericUpDown tbDBID;
        private System.Windows.Forms.NumericUpDown numericPage;
        private System.Windows.Forms.NumericUpDown numericSize;
        private System.Windows.Forms.ComboBox cbTempWorkflows;
        private System.Windows.Forms.Label labelTempWorkflows;
        private System.Windows.Forms.ComboBox cbExportReport;
        private System.Windows.Forms.ComboBox cbExportView;
    }
}

