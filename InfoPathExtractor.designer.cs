namespace Tool
{
    /// <summary>
    /// 
    /// </summary>
    partial class InfoPathExtractor
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
            this.fileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectSchema = new System.Windows.Forms.Button();
            this.txtSchemaFile = new System.Windows.Forms.TextBox();
            this.lblSchemaFile = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowFields = new System.Windows.Forms.Button();
            this.lbxSchemaDataTypes = new System.Windows.Forms.ListBox();
            this.btnAutoMap = new System.Windows.Forms.Button();
            this.lbxSchemaFields = new System.Windows.Forms.ListBox();
            this.btnManualMapping = new System.Windows.Forms.Button();
            this.lbxNSFFields = new System.Windows.Forms.ListBox();
            this.lblSchema = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSelectTarget = new System.Windows.Forms.Button();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.lblTargetFolder = new System.Windows.Forms.Label();
            this.txtTempFile = new System.Windows.Forms.TextBox();
            this.lblSelectTempFile = new System.Windows.Forms.Label();
            this.btnSelectTempFile = new System.Windows.Forms.Button();
            this.saveXMLFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbxListForm = new System.Windows.Forms.ComboBox();
            this.btnShowForms = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnLoadJob = new System.Windows.Forms.Button();
            this.btnSaveJob = new System.Windows.Forms.Button();
            this.btnUploadToSharePoint = new System.Windows.Forms.Button();
            this.mappedFieldsView = new System.Windows.Forms.DataGridView();
            this.NsfFields = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XsdFields = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generateDocButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLotusFile = new System.Windows.Forms.TextBox();
            this.btnSelectLotusDb = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappedFieldsView)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileOpenDialog
            // 
            this.fileOpenDialog.FileName = "openFileDialog1";
            // 
            // btnSelectSchema
            // 
            this.btnSelectSchema.Location = new System.Drawing.Point(779, 12);
            this.btnSelectSchema.Name = "btnSelectSchema";
            this.btnSelectSchema.Size = new System.Drawing.Size(110, 24);
            this.btnSelectSchema.TabIndex = 12;
            this.btnSelectSchema.Text = "Browse";
            this.btnSelectSchema.UseVisualStyleBackColor = true;
            this.btnSelectSchema.Click += new System.EventHandler(this.btnSelectSchema_Click);
            // 
            // txtSchemaFile
            // 
            this.txtSchemaFile.Location = new System.Drawing.Point(121, 12);
            this.txtSchemaFile.Name = "txtSchemaFile";
            this.txtSchemaFile.ReadOnly = true;
            this.txtSchemaFile.Size = new System.Drawing.Size(653, 20);
            this.txtSchemaFile.TabIndex = 11;
            // 
            // lblSchemaFile
            // 
            this.lblSchemaFile.AutoSize = true;
            this.lblSchemaFile.Location = new System.Drawing.Point(19, 15);
            this.lblSchemaFile.Name = "lblSchemaFile";
            this.lblSchemaFile.Size = new System.Drawing.Size(98, 13);
            this.lblSchemaFile.TabIndex = 10;
            this.lblSchemaFile.Text = "Select Schema file ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowFields);
            this.groupBox2.Controls.Add(this.lbxSchemaDataTypes);
            this.groupBox2.Controls.Add(this.btnAutoMap);
            this.groupBox2.Controls.Add(this.lbxSchemaFields);
            this.groupBox2.Controls.Add(this.btnManualMapping);
            this.groupBox2.Controls.Add(this.lbxNSFFields);
            this.groupBox2.Controls.Add(this.lblSchema);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(903, 127);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fields Mapping";
            // 
            // btnShowFields
            // 
            this.btnShowFields.Location = new System.Drawing.Point(776, 36);
            this.btnShowFields.Name = "btnShowFields";
            this.btnShowFields.Size = new System.Drawing.Size(111, 24);
            this.btnShowFields.TabIndex = 6;
            this.btnShowFields.Text = "Show Fields";
            this.btnShowFields.UseVisualStyleBackColor = true;
            this.btnShowFields.Click += new System.EventHandler(this.btnShowFields_Click);
            // 
            // lbxSchemaDataTypes
            // 
            this.lbxSchemaDataTypes.FormattingEnabled = true;
            this.lbxSchemaDataTypes.Location = new System.Drawing.Point(373, 30);
            this.lbxSchemaDataTypes.Name = "lbxSchemaDataTypes";
            this.lbxSchemaDataTypes.Size = new System.Drawing.Size(32, 95);
            this.lbxSchemaDataTypes.TabIndex = 6;
            this.lbxSchemaDataTypes.Visible = false;
            // 
            // btnAutoMap
            // 
            this.btnAutoMap.Location = new System.Drawing.Point(776, 62);
            this.btnAutoMap.Name = "btnAutoMap";
            this.btnAutoMap.Size = new System.Drawing.Size(111, 24);
            this.btnAutoMap.TabIndex = 4;
            this.btnAutoMap.Text = "Auto Map";
            this.btnAutoMap.UseVisualStyleBackColor = true;
            this.btnAutoMap.Click += new System.EventHandler(this.btnAutoMap_Click);
            // 
            // lbxSchemaFields
            // 
            this.lbxSchemaFields.FormattingEnabled = true;
            this.lbxSchemaFields.Location = new System.Drawing.Point(391, 30);
            this.lbxSchemaFields.Name = "lbxSchemaFields";
            this.lbxSchemaFields.Size = new System.Drawing.Size(379, 95);
            this.lbxSchemaFields.TabIndex = 5;
            // 
            // btnManualMapping
            // 
            this.btnManualMapping.Location = new System.Drawing.Point(776, 88);
            this.btnManualMapping.Name = "btnManualMapping";
            this.btnManualMapping.Size = new System.Drawing.Size(111, 24);
            this.btnManualMapping.TabIndex = 5;
            this.btnManualMapping.Text = "Map Manual ";
            this.btnManualMapping.UseVisualStyleBackColor = true;
            this.btnManualMapping.Click += new System.EventHandler(this.btnManualMapping_Click);
            // 
            // lbxNSFFields
            // 
            this.lbxNSFFields.FormattingEnabled = true;
            this.lbxNSFFields.Location = new System.Drawing.Point(13, 30);
            this.lbxNSFFields.Name = "lbxNSFFields";
            this.lbxNSFFields.Size = new System.Drawing.Size(372, 95);
            this.lbxNSFFields.TabIndex = 4;
            // 
            // lblSchema
            // 
            this.lblSchema.AutoSize = true;
            this.lblSchema.Location = new System.Drawing.Point(379, 14);
            this.lblSchema.Name = "lblSchema";
            this.lblSchema.Size = new System.Drawing.Size(79, 13);
            this.lblSchema.TabIndex = 3;
            this.lblSchema.Text = "Schema Fields:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NSF Fields:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSelectTarget);
            this.groupBox3.Controls.Add(this.txtTargetFolder);
            this.groupBox3.Controls.Add(this.lblTargetFolder);
            this.groupBox3.Location = new System.Drawing.Point(13, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(903, 46);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Target Folder";
            // 
            // btnSelectTarget
            // 
            this.btnSelectTarget.Location = new System.Drawing.Point(779, 18);
            this.btnSelectTarget.Name = "btnSelectTarget";
            this.btnSelectTarget.Size = new System.Drawing.Size(108, 24);
            this.btnSelectTarget.TabIndex = 18;
            this.btnSelectTarget.Text = "Browse";
            this.btnSelectTarget.UseVisualStyleBackColor = true;
            this.btnSelectTarget.Click += new System.EventHandler(this.btnSelectTarget_Click);
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.Location = new System.Drawing.Point(121, 19);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.ReadOnly = true;
            this.txtTargetFolder.Size = new System.Drawing.Size(653, 20);
            this.txtTargetFolder.TabIndex = 17;
            // 
            // lblTargetFolder
            // 
            this.lblTargetFolder.AutoSize = true;
            this.lblTargetFolder.Location = new System.Drawing.Point(18, 24);
            this.lblTargetFolder.Name = "lblTargetFolder";
            this.lblTargetFolder.Size = new System.Drawing.Size(99, 13);
            this.lblTargetFolder.TabIndex = 16;
            this.lblTargetFolder.Text = "Select target Folder";
            // 
            // txtTempFile
            // 
            this.txtTempFile.Location = new System.Drawing.Point(121, 17);
            this.txtTempFile.Name = "txtTempFile";
            this.txtTempFile.ReadOnly = true;
            this.txtTempFile.Size = new System.Drawing.Size(653, 20);
            this.txtTempFile.TabIndex = 26;
            // 
            // lblSelectTempFile
            // 
            this.lblSelectTempFile.AutoSize = true;
            this.lblSelectTempFile.Location = new System.Drawing.Point(18, 20);
            this.lblSelectTempFile.Name = "lblSelectTempFile";
            this.lblSelectTempFile.Size = new System.Drawing.Size(99, 13);
            this.lblSelectTempFile.TabIndex = 25;
            this.lblSelectTempFile.Text = "Select template file ";
            // 
            // btnSelectTempFile
            // 
            this.btnSelectTempFile.Location = new System.Drawing.Point(781, 13);
            this.btnSelectTempFile.Name = "btnSelectTempFile";
            this.btnSelectTempFile.Size = new System.Drawing.Size(108, 24);
            this.btnSelectTempFile.TabIndex = 27;
            this.btnSelectTempFile.Text = "Browse";
            this.btnSelectTempFile.UseVisualStyleBackColor = true;
            this.btnSelectTempFile.Click += new System.EventHandler(this.btnSelectTempFile_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxListForm);
            this.groupBox4.Controls.Add(this.btnShowForms);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(11, 93);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(905, 45);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Form Selection";
            // 
            // cbxListForm
            // 
            this.cbxListForm.FormattingEnabled = true;
            this.cbxListForm.Location = new System.Drawing.Point(121, 16);
            this.cbxListForm.Name = "cbxListForm";
            this.cbxListForm.Size = new System.Drawing.Size(653, 21);
            this.cbxListForm.TabIndex = 14;
            // 
            // btnShowForms
            // 
            this.btnShowForms.Location = new System.Drawing.Point(779, 12);
            this.btnShowForms.Name = "btnShowForms";
            this.btnShowForms.Size = new System.Drawing.Size(110, 24);
            this.btnShowForms.TabIndex = 13;
            this.btnShowForms.Text = "Show Forms";
            this.btnShowForms.UseVisualStyleBackColor = true;
            this.btnShowForms.Click += new System.EventHandler(this.btnShowForms_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Select Form from DB";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnReset);
            this.groupBox5.Controls.Add(this.btnLoadJob);
            this.groupBox5.Controls.Add(this.btnSaveJob);
            this.groupBox5.Controls.Add(this.btnUploadToSharePoint);
            this.groupBox5.Controls.Add(this.mappedFieldsView);
            this.groupBox5.Controls.Add(this.generateDocButton);
            this.groupBox5.Location = new System.Drawing.Point(13, 361);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(903, 170);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Generate Infopath XML";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(779, 137);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 23);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnLoadJob
            // 
            this.btnLoadJob.Location = new System.Drawing.Point(779, 79);
            this.btnLoadJob.Name = "btnLoadJob";
            this.btnLoadJob.Size = new System.Drawing.Size(108, 23);
            this.btnLoadJob.TabIndex = 28;
            this.btnLoadJob.Text = "Load Job";
            this.btnLoadJob.UseVisualStyleBackColor = true;
            this.btnLoadJob.Click += new System.EventHandler(this.btnLoadJob_Click);
            // 
            // btnSaveJob
            // 
            this.btnSaveJob.Location = new System.Drawing.Point(779, 50);
            this.btnSaveJob.Name = "btnSaveJob";
            this.btnSaveJob.Size = new System.Drawing.Size(108, 23);
            this.btnSaveJob.TabIndex = 27;
            this.btnSaveJob.Text = "Save Job";
            this.btnSaveJob.UseVisualStyleBackColor = true;
            this.btnSaveJob.Click += new System.EventHandler(this.btnSaveJob_Click);
            // 
            // btnUploadToSharePoint
            // 
            this.btnUploadToSharePoint.Location = new System.Drawing.Point(779, 108);
            this.btnUploadToSharePoint.Name = "btnUploadToSharePoint";
            this.btnUploadToSharePoint.Size = new System.Drawing.Size(108, 23);
            this.btnUploadToSharePoint.TabIndex = 25;
            this.btnUploadToSharePoint.Text = "Upload to SP";
            this.btnUploadToSharePoint.UseVisualStyleBackColor = true;
            this.btnUploadToSharePoint.Click += new System.EventHandler(this.btnUploadToSharePoint_Click);
            // 
            // mappedFieldsView
            // 
            this.mappedFieldsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mappedFieldsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NsfFields,
            this.XsdFields,
            this.DataType});
            this.mappedFieldsView.Location = new System.Drawing.Point(12, 21);
            this.mappedFieldsView.Name = "mappedFieldsView";
            this.mappedFieldsView.Size = new System.Drawing.Size(758, 142);
            this.mappedFieldsView.TabIndex = 22;
            // 
            // NsfFields
            // 
            this.NsfFields.HeaderText = "Lotus Fields";
            this.NsfFields.Name = "NsfFields";
            // 
            // XsdFields
            // 
            this.XsdFields.HeaderText = "Schema Fields";
            this.XsdFields.Name = "XsdFields";
            // 
            // DataType
            // 
            this.DataType.HeaderText = "Data Type";
            this.DataType.Name = "DataType";
            // 
            // generateDocButton
            // 
            this.generateDocButton.Location = new System.Drawing.Point(779, 21);
            this.generateDocButton.Name = "generateDocButton";
            this.generateDocButton.Size = new System.Drawing.Size(108, 23);
            this.generateDocButton.TabIndex = 21;
            this.generateDocButton.Text = "Generate";
            this.generateDocButton.UseVisualStyleBackColor = true;
            this.generateDocButton.Click += new System.EventHandler(this.generateDocButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSelectTempFile);
            this.groupBox6.Controls.Add(this.txtTempFile);
            this.groupBox6.Controls.Add(this.lblSelectTempFile);
            this.groupBox6.Location = new System.Drawing.Point(13, 262);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(903, 46);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Select Infopath Template File";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnSelectSchema);
            this.groupBox7.Controls.Add(this.lblSchemaFile);
            this.groupBox7.Controls.Add(this.txtSchemaFile);
            this.groupBox7.Location = new System.Drawing.Point(13, 47);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(903, 40);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Select Infopath Schema File";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.txtLotusFile);
            this.groupBox8.Controls.Add(this.btnSelectLotusDb);
            this.groupBox8.Location = new System.Drawing.Point(12, 7);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(904, 37);
            this.groupBox8.TabIndex = 25;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = ".nsf File Selection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select Lotus Database";
            // 
            // txtLotusFile
            // 
            this.txtLotusFile.Location = new System.Drawing.Point(121, 13);
            this.txtLotusFile.Name = "txtLotusFile";
            this.txtLotusFile.ReadOnly = true;
            this.txtLotusFile.Size = new System.Drawing.Size(653, 20);
            this.txtLotusFile.TabIndex = 8;
            // 
            // btnSelectLotusDb
            // 
            this.btnSelectLotusDb.Location = new System.Drawing.Point(780, 12);
            this.btnSelectLotusDb.Name = "btnSelectLotusDb";
            this.btnSelectLotusDb.Size = new System.Drawing.Size(108, 23);
            this.btnSelectLotusDb.TabIndex = 9;
            this.btnSelectLotusDb.Text = "Browse";
            this.btnSelectLotusDb.UseVisualStyleBackColor = true;
            this.btnSelectLotusDb.Click += new System.EventHandler(this.btnSelectLotusDb_Click);
            // 
            // InfoPathExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 535);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "InfoPathExtractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoPath File Generator";
            this.Load += new System.EventHandler(this.InfoPathExtractor_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mappedFieldsView)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileOpenDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShowFields;
        private System.Windows.Forms.ListBox lbxSchemaDataTypes;
        private System.Windows.Forms.Button btnAutoMap;
        private System.Windows.Forms.ListBox lbxSchemaFields;
        private System.Windows.Forms.Button btnManualMapping;
        private System.Windows.Forms.ListBox lbxNSFFields;
        private System.Windows.Forms.Label lblSchema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSchemaFile;
        private System.Windows.Forms.Label lblSchemaFile;
        private System.Windows.Forms.Button btnSelectSchema;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSelectTarget;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Label lblTargetFolder;
        private System.Windows.Forms.TextBox txtTempFile;
        private System.Windows.Forms.Label lblSelectTempFile;
        private System.Windows.Forms.Button btnSelectTempFile;
        private System.Windows.Forms.SaveFileDialog saveXMLFileDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnShowForms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnUploadToSharePoint;
        private System.Windows.Forms.DataGridView mappedFieldsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NsfFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn XsdFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.Button generateDocButton;
        private System.Windows.Forms.ComboBox cbxListForm;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnLoadJob;
        private System.Windows.Forms.Button btnSaveJob;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtLotusFile;
        private System.Windows.Forms.Button btnSelectLotusDb;
        private System.Windows.Forms.Label label1;
    }
}

