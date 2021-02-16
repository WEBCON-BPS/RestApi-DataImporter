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
            this.tbExportReport = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbStartPath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbStartDocType = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbStartWF = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Size_TextBox = new System.Windows.Forms.TextBox();
            this.Size_Label = new System.Windows.Forms.Label();
            this.Page_TextBox = new System.Windows.Forms.TextBox();
            this.Page_Lable = new System.Windows.Forms.Label();
            this.tbExportView = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lExportElapsed = new System.Windows.Forms.Label();
            this.exportProgressBar = new System.Windows.Forms.ProgressBar();
            this.lexportReport = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.tbExportFilesPath = new System.Windows.Forms.TextBox();
            this.cbAttachments = new System.Windows.Forms.CheckBox();
            this.cbSubs = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbTempStepID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTempDocTypeID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTemplateGenerate = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MaxImportNum_Label = new System.Windows.Forms.Label();
            this.MaxImportNum_UpDown = new System.Windows.Forms.NumericUpDown();
            this.lErrors = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lImportElapsed = new System.Windows.Forms.Label();
            this.lUpdated = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lStarted = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbImportSheet = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.importProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.cbImportMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartChooseFileToImport = new System.Windows.Forms.Button();
            this.tbStartFile = new System.Windows.Forms.TextBox();
            this.bgExporter = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDBID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSecret = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPortal = new System.Windows.Forms.TextBox();
            this.chbDebugMode = new System.Windows.Forms.CheckBox();
            this.cbApplications = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbApp = new System.Windows.Forms.TextBox();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxImportNum_UpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Import
            // 
            this.btn_Import.Enabled = false;
            this.btn_Import.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Import.ForeColor = System.Drawing.Color.Green;
            this.btn_Import.Location = new System.Drawing.Point(383, 127);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(136, 35);
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
            this.btn_Export.Location = new System.Drawing.Point(383, 157);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(136, 30);
            this.btn_Export.TabIndex = 6;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Processing";
            // 
            // lElements
            // 
            this.lElements.AutoSize = true;
            this.lElements.Location = new System.Drawing.Point(444, 164);
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
            // tbExportReport
            // 
            this.tbExportReport.Location = new System.Drawing.Point(139, 16);
            this.tbExportReport.Name = "tbExportReport";
            this.tbExportReport.Size = new System.Drawing.Size(239, 20);
            this.tbExportReport.TabIndex = 0;
            this.tbExportReport.Text = "99";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Path Id (optional)";
            // 
            // tbStartPath
            // 
            this.tbStartPath.Location = new System.Drawing.Point(137, 79);
            this.tbStartPath.Name = "tbStartPath";
            this.tbStartPath.Size = new System.Drawing.Size(243, 20);
            this.tbStartPath.TabIndex = 3;
            this.tbStartPath.Text = "3459";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Form type Id";
            // 
            // tbStartDocType
            // 
            this.tbStartDocType.Location = new System.Drawing.Point(137, 37);
            this.tbStartDocType.Name = "tbStartDocType";
            this.tbStartDocType.Size = new System.Drawing.Size(243, 20);
            this.tbStartDocType.TabIndex = 1;
            this.tbStartDocType.Text = "308";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Workflow Id";
            // 
            // tbStartWF
            // 
            this.tbStartWF.Location = new System.Drawing.Point(137, 58);
            this.tbStartWF.Name = "tbStartWF";
            this.tbStartWF.Size = new System.Drawing.Size(243, 20);
            this.tbStartWF.TabIndex = 2;
            this.tbStartWF.Text = "254";
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
            this.tabMain.Size = new System.Drawing.Size(528, 248);
            this.tabMain.TabIndex = 10;
            this.tabMain.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Size_TextBox);
            this.tabPage1.Controls.Add(this.Size_Label);
            this.tabPage1.Controls.Add(this.Page_TextBox);
            this.tabPage1.Controls.Add(this.Page_Lable);
            this.tabPage1.Controls.Add(this.tbExportView);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.lExportElapsed);
            this.tabPage1.Controls.Add(this.exportProgressBar);
            this.tabPage1.Controls.Add(this.lexportReport);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.btnChooseFolder);
            this.tabPage1.Controls.Add(this.tbExportFilesPath);
            this.tabPage1.Controls.Add(this.cbAttachments);
            this.tabPage1.Controls.Add(this.cbSubs);
            this.tabPage1.Controls.Add(this.btn_Export);
            this.tabPage1.Controls.Add(this.tbExportReport);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(520, 222);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Export";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Size_TextBox
            // 
            this.Size_TextBox.Location = new System.Drawing.Point(139, 92);
            this.Size_TextBox.Name = "Size_TextBox";
            this.Size_TextBox.Size = new System.Drawing.Size(239, 20);
            this.Size_TextBox.TabIndex = 3;
            this.Size_TextBox.Text = "1000";
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
            // Page_TextBox
            // 
            this.Page_TextBox.Location = new System.Drawing.Point(139, 66);
            this.Page_TextBox.Name = "Page_TextBox";
            this.Page_TextBox.Size = new System.Drawing.Size(239, 20);
            this.Page_TextBox.TabIndex = 2;
            this.Page_TextBox.Text = "1";
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
            // tbExportView
            // 
            this.tbExportView.Location = new System.Drawing.Point(139, 40);
            this.tbExportView.Name = "tbExportView";
            this.tbExportView.Size = new System.Drawing.Size(239, 20);
            this.tbExportView.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 49;
            this.label18.Text = "View Id (optional)";
            // 
            // lExportElapsed
            // 
            this.lExportElapsed.AutoSize = true;
            this.lExportElapsed.Location = new System.Drawing.Point(299, 194);
            this.lExportElapsed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lExportElapsed.Name = "lExportElapsed";
            this.lExportElapsed.Size = new System.Drawing.Size(0, 13);
            this.lExportElapsed.TabIndex = 47;
            // 
            // exportProgressBar
            // 
            this.exportProgressBar.Location = new System.Drawing.Point(4, 209);
            this.exportProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.exportProgressBar.Name = "exportProgressBar";
            this.exportProgressBar.Size = new System.Drawing.Size(374, 13);
            this.exportProgressBar.TabIndex = 46;
            // 
            // lexportReport
            // 
            this.lexportReport.AutoSize = true;
            this.lexportReport.Location = new System.Drawing.Point(437, 209);
            this.lexportReport.Name = "lexportReport";
            this.lexportReport.Size = new System.Drawing.Size(13, 13);
            this.lexportReport.TabIndex = 45;
            this.lexportReport.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(381, 209);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Elements";
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChooseFolder.Location = new System.Drawing.Point(135, 176);
            this.btnChooseFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(136, 23);
            this.btnChooseFolder.TabIndex = 5;
            this.btnChooseFolder.Text = "Folder";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Visible = false;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // tbExportFilesPath
            // 
            this.tbExportFilesPath.Location = new System.Drawing.Point(7, 179);
            this.tbExportFilesPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbExportFilesPath.Name = "tbExportFilesPath";
            this.tbExportFilesPath.Size = new System.Drawing.Size(124, 20);
            this.tbExportFilesPath.TabIndex = 4;
            this.tbExportFilesPath.Tag = "";
            this.tbExportFilesPath.Text = "c:\\Temp\\Export";
            this.tbExportFilesPath.Visible = false;
            // 
            // cbAttachments
            // 
            this.cbAttachments.AutoSize = true;
            this.cbAttachments.Location = new System.Drawing.Point(7, 158);
            this.cbAttachments.Margin = new System.Windows.Forms.Padding(2);
            this.cbAttachments.Name = "cbAttachments";
            this.cbAttachments.Size = new System.Drawing.Size(124, 17);
            this.cbAttachments.TabIndex = 41;
            this.cbAttachments.Text = "Attachments (slower)";
            this.cbAttachments.UseVisualStyleBackColor = true;
            this.cbAttachments.CheckStateChanged += new System.EventHandler(this.cbAttachments_CheckStateChanged);
            // 
            // cbSubs
            // 
            this.cbSubs.AutoSize = true;
            this.cbSubs.Location = new System.Drawing.Point(7, 137);
            this.cbSubs.Margin = new System.Windows.Forms.Padding(2);
            this.cbSubs.Name = "cbSubs";
            this.cbSubs.Size = new System.Drawing.Size(126, 17);
            this.cbSubs.TabIndex = 40;
            this.cbSubs.Text = "Subelements (slower)";
            this.cbSubs.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbTempStepID);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.tbTempDocTypeID);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.btnTemplateGenerate);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(520, 222);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Generate template";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbTempStepID
            // 
            this.tbTempStepID.Location = new System.Drawing.Point(137, 45);
            this.tbTempStepID.Name = "tbTempStepID";
            this.tbTempStepID.Size = new System.Drawing.Size(243, 20);
            this.tbTempStepID.TabIndex = 1;
            this.tbTempStepID.Text = "254";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Step Id";
            // 
            // tbTempDocTypeID
            // 
            this.tbTempDocTypeID.Location = new System.Drawing.Point(137, 24);
            this.tbTempDocTypeID.Name = "tbTempDocTypeID";
            this.tbTempDocTypeID.Size = new System.Drawing.Size(243, 20);
            this.tbTempDocTypeID.TabIndex = 0;
            this.tbTempDocTypeID.Text = "308";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Form  type Id";
            // 
            // btnTemplateGenerate
            // 
            this.btnTemplateGenerate.Location = new System.Drawing.Point(366, 171);
            this.btnTemplateGenerate.Name = "btnTemplateGenerate";
            this.btnTemplateGenerate.Size = new System.Drawing.Size(136, 30);
            this.btnTemplateGenerate.TabIndex = 2;
            this.btnTemplateGenerate.Text = "Generate";
            this.btnTemplateGenerate.UseVisualStyleBackColor = true;
            this.btnTemplateGenerate.Click += new System.EventHandler(this.btnTemplateGenerate_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.MaxImportNum_Label);
            this.tabPage2.Controls.Add(this.MaxImportNum_UpDown);
            this.tabPage2.Controls.Add(this.lErrors);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.lImportElapsed);
            this.tabPage2.Controls.Add(this.lUpdated);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.lStarted);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.cbImportSheet);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.importProgressBar);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbImportMode);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnStartChooseFileToImport);
            this.tabPage2.Controls.Add(this.tbStartFile);
            this.tabPage2.Controls.Add(this.tbStartWF);
            this.tabPage2.Controls.Add(this.tbStartPath);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbStartDocType);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.lElements);
            this.tabPage2.Controls.Add(this.btn_Import);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(520, 222);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MaxImportNum_Label
            // 
            this.MaxImportNum_Label.AutoSize = true;
            this.MaxImportNum_Label.Location = new System.Drawing.Point(395, 0);
            this.MaxImportNum_Label.Name = "MaxImportNum_Label";
            this.MaxImportNum_Label.Size = new System.Drawing.Size(122, 13);
            this.MaxImportNum_Label.TabIndex = 63;
            this.MaxImportNum_Label.Text = "Maximum import element";
            // 
            // MaxImportNum_UpDown
            // 
            this.MaxImportNum_UpDown.Location = new System.Drawing.Point(397, 16);
            this.MaxImportNum_UpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MaxImportNum_UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxImportNum_UpDown.Name = "MaxImportNum_UpDown";
            this.MaxImportNum_UpDown.Size = new System.Drawing.Size(120, 20);
            this.MaxImportNum_UpDown.TabIndex = 62;
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
            this.lErrors.Location = new System.Drawing.Point(444, 210);
            this.lErrors.Name = "lErrors";
            this.lErrors.Size = new System.Drawing.Size(13, 13);
            this.lErrors.TabIndex = 61;
            this.lErrors.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(382, 210);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 60;
            this.label20.Text = "Erros";
            // 
            // lImportElapsed
            // 
            this.lImportElapsed.AutoSize = true;
            this.lImportElapsed.Location = new System.Drawing.Point(290, 193);
            this.lImportElapsed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lImportElapsed.Name = "lImportElapsed";
            this.lImportElapsed.Size = new System.Drawing.Size(0, 13);
            this.lImportElapsed.TabIndex = 59;
            // 
            // lUpdated
            // 
            this.lUpdated.AutoSize = true;
            this.lUpdated.Location = new System.Drawing.Point(444, 194);
            this.lUpdated.Name = "lUpdated";
            this.lUpdated.Size = new System.Drawing.Size(13, 13);
            this.lUpdated.TabIndex = 58;
            this.lUpdated.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(381, 194);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 57;
            this.label21.Text = "Updates";
            // 
            // lStarted
            // 
            this.lStarted.AutoSize = true;
            this.lStarted.Location = new System.Drawing.Point(444, 179);
            this.lStarted.Name = "lStarted";
            this.lStarted.Size = new System.Drawing.Size(13, 13);
            this.lStarted.TabIndex = 56;
            this.lStarted.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(381, 179);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 55;
            this.label19.Text = "Started";
            // 
            // cbImportSheet
            // 
            this.cbImportSheet.Enabled = false;
            this.cbImportSheet.FormattingEnabled = true;
            this.cbImportSheet.Items.AddRange(new object[] {
            "First"});
            this.cbImportSheet.Location = new System.Drawing.Point(137, 125);
            this.cbImportSheet.Margin = new System.Windows.Forms.Padding(2);
            this.cbImportSheet.Name = "cbImportSheet";
            this.cbImportSheet.Size = new System.Drawing.Size(243, 21);
            this.cbImportSheet.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 131);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "Excel Sheet";
            // 
            // importProgressBar
            // 
            this.importProgressBar.Location = new System.Drawing.Point(3, 209);
            this.importProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.importProgressBar.Name = "importProgressBar";
            this.importProgressBar.Size = new System.Drawing.Size(374, 13);
            this.importProgressBar.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 53);
            this.label2.TabIndex = 51;
            this.label2.Text = "Excel columns:\r\n  WFDID    (for update/dynamic)\r\n  PATHID   (for dynamic) \r\n  Att" +
    "achments";
            // 
            // cbImportMode
            // 
            this.cbImportMode.FormattingEnabled = true;
            this.cbImportMode.Items.AddRange(new object[] {
            "Only Start",
            "Only Update",
            "Dynamic (Start / Update / Move)"});
            this.cbImportMode.Location = new System.Drawing.Point(137, 14);
            this.cbImportMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbImportMode.Name = "cbImportMode";
            this.cbImportMode.Size = new System.Drawing.Size(243, 21);
            this.cbImportMode.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "ImportFile";
            // 
            // btnStartChooseFileToImport
            // 
            this.btnStartChooseFileToImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartChooseFileToImport.Location = new System.Drawing.Point(383, 99);
            this.btnStartChooseFileToImport.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartChooseFileToImport.Name = "btnStartChooseFileToImport";
            this.btnStartChooseFileToImport.Size = new System.Drawing.Size(136, 23);
            this.btnStartChooseFileToImport.TabIndex = 6;
            this.btnStartChooseFileToImport.Text = "Choose file";
            this.btnStartChooseFileToImport.UseVisualStyleBackColor = true;
            this.btnStartChooseFileToImport.Click += new System.EventHandler(this.btnStartChooseFileToImport_Click);
            // 
            // tbStartFile
            // 
            this.tbStartFile.Enabled = false;
            this.tbStartFile.Location = new System.Drawing.Point(137, 101);
            this.tbStartFile.Margin = new System.Windows.Forms.Padding(2);
            this.tbStartFile.Name = "tbStartFile";
            this.tbStartFile.Size = new System.Drawing.Size(243, 20);
            this.tbStartFile.TabIndex = 4;
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
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.tbUser);
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
            this.tbDBID.Location = new System.Drawing.Point(458, 14);
            this.tbDBID.Margin = new System.Windows.Forms.Padding(2);
            this.tbDBID.Name = "tbDBID";
            this.tbDBID.Size = new System.Drawing.Size(63, 20);
            this.tbDBID.TabIndex = 58;
            this.tbDBID.Text = "1";
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
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 13);
            this.label17.TabIndex = 69;
            this.label17.Text = "User to impersonate";
            // 
            // tbUser
            // 
            this.tbUser.AccessibleDescription = "3e7392e9-906c-42a4-8402-e9abca07af65";
            this.tbUser.Location = new System.Drawing.Point(132, 84);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(243, 20);
            this.tbUser.TabIndex = 61;
            this.tbUser.Tag = "";
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
            this.tbSecret.TabIndex = 60;
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
            this.tbClientID.TabIndex = 59;
            this.tbClientID.Tag = "87a70b12-6eb9-4135-bd0e-7971911f2737";
            this.tbClientID.Text = "admin";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConnect.Location = new System.Drawing.Point(385, 62);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(136, 38);
            this.btnConnect.TabIndex = 62;
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
            this.tbPortal.TabIndex = 57;
            this.tbPortal.Text = "https://dev20.webcon.pl:48439/";
            // 
            // chbDebugMode
            // 
            this.chbDebugMode.AutoSize = true;
            this.chbDebugMode.Location = new System.Drawing.Point(441, 134);
            this.chbDebugMode.Margin = new System.Windows.Forms.Padding(2);
            this.chbDebugMode.Name = "chbDebugMode";
            this.chbDebugMode.Size = new System.Drawing.Size(85, 17);
            this.chbDebugMode.TabIndex = 74;
            this.chbDebugMode.Text = "DebugMode";
            this.chbDebugMode.UseVisualStyleBackColor = true;
            this.chbDebugMode.Visible = false;
            // 
            // cbApplications
            // 
            this.cbApplications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApplications.Enabled = false;
            this.cbApplications.FormattingEnabled = true;
            this.cbApplications.Location = new System.Drawing.Point(136, 124);
            this.cbApplications.Margin = new System.Windows.Forms.Padding(2);
            this.cbApplications.Name = "cbApplications";
            this.cbApplications.Size = new System.Drawing.Size(207, 21);
            this.cbApplications.TabIndex = 71;
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
            this.tbApp.Location = new System.Drawing.Point(346, 124);
            this.tbApp.Name = "tbApp";
            this.tbApp.Size = new System.Drawing.Size(33, 20);
            this.tbApp.TabIndex = 72;
            // 
            // ImporterMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(537, 411);
            this.Controls.Add(this.chbDebugMode);
            this.Controls.Add(this.cbApplications);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbApp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(553, 450);
            this.MinimumSize = new System.Drawing.Size(553, 450);
            this.Name = "ImporterMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WEBCON BPS Importer";
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxImportNum_UpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox tbExportReport;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbStartPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbStartDocType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbStartWF;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.TextBox tbExportFilesPath;
        private System.Windows.Forms.CheckBox cbAttachments;
        private System.Windows.Forms.CheckBox cbSubs;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbTempStepID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTempDocTypeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTemplateGenerate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbImportMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartChooseFileToImport;
        private System.Windows.Forms.TextBox tbStartFile;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgExporter;
        private System.Windows.Forms.Label lexportReport;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ProgressBar exportProgressBar;
        private System.Windows.Forms.ProgressBar importProgressBar;
        private System.Windows.Forms.ComboBox cbImportSheet;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lUpdated;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lStarted;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lExportElapsed;
        private System.Windows.Forms.Label lImportElapsed;
        private System.Windows.Forms.Label lErrors;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbExportView;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label MaxImportNum_Label;
        private System.Windows.Forms.NumericUpDown MaxImportNum_UpDown;
        private System.Windows.Forms.Label Page_Lable;
        private System.Windows.Forms.TextBox Size_TextBox;
        private System.Windows.Forms.Label Size_Label;
        private System.Windows.Forms.TextBox Page_TextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDBID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbSecret;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPortal;
        private System.Windows.Forms.CheckBox chbDebugMode;
        private System.Windows.Forms.ComboBox cbApplications;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbApp;
    }
}

