namespace Tool
{
    /// <summary>
    /// 
    /// </summary>
    partial class UploadToSharePoint
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxDomain = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drpdnlFormLibrary = new System.Windows.Forms.ComboBox();
            this.tbxSharePointURL = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFormLibraryNew = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorList = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtUsermapFilePath = new System.Windows.Forms.TextBox();
            this.group3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtUniqueField1 = new System.Windows.Forms.TextBox();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.cbxFolderStructure = new System.Windows.Forms.CheckBox();
            this.txtUniqueField2 = new System.Windows.Forms.TextBox();
            this.tbxArchiveFolderPrefix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxMaxFileLimit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxDocLibDesc = new System.Windows.Forms.TextBox();
            this.tbxTargetFolder = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorList)).BeginInit();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter SharePoint Site URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Form Library:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "UserName:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Domain:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(155, 45);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(200, 20);
            this.tbxPassword.TabIndex = 2;
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(155, 19);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(200, 20);
            this.tbxUserName.TabIndex = 1;
            // 
            // tbxDomain
            // 
            this.tbxDomain.Location = new System.Drawing.Point(155, 71);
            this.tbxDomain.Name = "tbxDomain";
            this.tbxDomain.Size = new System.Drawing.Size(200, 20);
            this.tbxDomain.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drpdnlFormLibrary);
            this.groupBox1.Controls.Add(this.tbxSharePointURL);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnFormLibraryNew);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 119);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SharePoint Site Info";
            // 
            // drpdnlFormLibrary
            // 
            this.drpdnlFormLibrary.FormattingEnabled = true;
            this.drpdnlFormLibrary.Location = new System.Drawing.Point(155, 48);
            this.drpdnlFormLibrary.Name = "drpdnlFormLibrary";
            this.drpdnlFormLibrary.Size = new System.Drawing.Size(200, 21);
            this.drpdnlFormLibrary.TabIndex = 7;
            // 
            // tbxSharePointURL
            // 
            this.tbxSharePointURL.Location = new System.Drawing.Point(155, 22);
            this.tbxSharePointURL.Name = "tbxSharePointURL";
            this.tbxSharePointURL.Size = new System.Drawing.Size(200, 20);
            this.tbxSharePointURL.TabIndex = 6;
            this.tbxSharePointURL.Leave += new System.EventHandler(this.tbxSharePointURL_Leave);
            this.tbxSharePointURL.TextChanged += new System.EventHandler(this.tbxSharePointURL_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(226, 85);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFormLibraryNew
            // 
            this.btnFormLibraryNew.Location = new System.Drawing.Point(361, 48);
            this.btnFormLibraryNew.Name = "btnFormLibraryNew";
            this.btnFormLibraryNew.Size = new System.Drawing.Size(50, 22);
            this.btnFormLibraryNew.TabIndex = 7;
            this.btnFormLibraryNew.Text = "Create";
            this.btnFormLibraryNew.UseVisualStyleBackColor = true;
            this.btnFormLibraryNew.Click += new System.EventHandler(this.btnFormLibraryNew_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(144, 85);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 24);
            this.btnUpload.TabIndex = 8;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxDomain);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbxPassword);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbxUserName);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 106);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authentication";
            // 
            // errorList
            // 
            this.errorList.ContainerControl = this;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(361, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(50, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtUsermapFilePath
            // 
            this.txtUsermapFilePath.Location = new System.Drawing.Point(155, 20);
            this.txtUsermapFilePath.Name = "txtUsermapFilePath";
            this.txtUsermapFilePath.Size = new System.Drawing.Size(200, 20);
            this.txtUsermapFilePath.TabIndex = 4;
            // 
            // group3
            // 
            this.group3.Controls.Add(this.btnBrowse);
            this.group3.Controls.Add(this.txtUsermapFilePath);
            this.group3.Controls.Add(this.label6);
            this.group3.Location = new System.Drawing.Point(14, 124);
            this.group3.Name = "group3";
            this.group3.Size = new System.Drawing.Size(425, 58);
            this.group3.TabIndex = 13;
            this.group3.TabStop = false;
            this.group3.Text = "User Mapping";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Select User mapping xml file:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtUniqueField1
            // 
            this.txtUniqueField1.Location = new System.Drawing.Point(46, 355);
            this.txtUniqueField1.Name = "txtUniqueField1";
            this.txtUniqueField1.Size = new System.Drawing.Size(100, 20);
            this.txtUniqueField1.TabIndex = 22;
            this.txtUniqueField1.Visible = false;
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(53, 315);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(100, 20);
            this.txtInputFile.TabIndex = 26;
            this.txtInputFile.Visible = false;
            // 
            // cbxFolderStructure
            // 
            this.cbxFolderStructure.AutoSize = true;
            this.cbxFolderStructure.Location = new System.Drawing.Point(192, 318);
            this.cbxFolderStructure.Name = "cbxFolderStructure";
            this.cbxFolderStructure.Size = new System.Drawing.Size(141, 17);
            this.cbxFolderStructure.TabIndex = 27;
            this.cbxFolderStructure.Text = "Require Folder Structure";
            this.cbxFolderStructure.UseVisualStyleBackColor = true;
            this.cbxFolderStructure.Visible = false;
            // 
            // txtUniqueField2
            // 
            this.txtUniqueField2.Location = new System.Drawing.Point(339, 319);
            this.txtUniqueField2.Name = "txtUniqueField2";
            this.txtUniqueField2.Size = new System.Drawing.Size(100, 20);
            this.txtUniqueField2.TabIndex = 24;
            this.txtUniqueField2.Visible = false;
            // 
            // tbxArchiveFolderPrefix
            // 
            this.tbxArchiveFolderPrefix.Enabled = false;
            this.tbxArchiveFolderPrefix.Location = new System.Drawing.Point(192, 355);
            this.tbxArchiveFolderPrefix.Name = "tbxArchiveFolderPrefix";
            this.tbxArchiveFolderPrefix.Size = new System.Drawing.Size(125, 20);
            this.tbxArchiveFolderPrefix.TabIndex = 25;
            this.tbxArchiveFolderPrefix.Text = "Archive Folder";
            this.tbxArchiveFolderPrefix.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Folder Prefix:";
            this.label8.Visible = false;
            // 
            // tbxMaxFileLimit
            // 
            this.tbxMaxFileLimit.Enabled = false;
            this.tbxMaxFileLimit.Location = new System.Drawing.Point(192, 334);
            this.tbxMaxFileLimit.Name = "tbxMaxFileLimit";
            this.tbxMaxFileLimit.Size = new System.Drawing.Size(125, 20);
            this.tbxMaxFileLimit.TabIndex = 21;
            this.tbxMaxFileLimit.Text = "50";
            this.tbxMaxFileLimit.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "File Max Limit:";
            this.label7.Visible = false;
            // 
            // tbxDocLibDesc
            // 
            this.tbxDocLibDesc.Location = new System.Drawing.Point(52, 344);
            this.tbxDocLibDesc.Name = "tbxDocLibDesc";
            this.tbxDocLibDesc.Size = new System.Drawing.Size(100, 20);
            this.tbxDocLibDesc.TabIndex = 19;
            this.tbxDocLibDesc.Visible = false;
            // 
            // tbxTargetFolder
            // 
            this.tbxTargetFolder.Location = new System.Drawing.Point(339, 351);
            this.tbxTargetFolder.Name = "tbxTargetFolder";
            this.tbxTargetFolder.Size = new System.Drawing.Size(100, 20);
            this.tbxTargetFolder.TabIndex = 18;
            this.tbxTargetFolder.Visible = false;
            // 
            // UploadToSharePoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 314);
            this.Controls.Add(this.txtUniqueField1);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.cbxFolderStructure);
            this.Controls.Add(this.txtUniqueField2);
            this.Controls.Add(this.tbxArchiveFolderPrefix);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxMaxFileLimit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxDocLibDesc);
            this.Controls.Add(this.tbxTargetFolder);
            this.Controls.Add(this.group3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UploadToSharePoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharePoint Upload";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorList)).EndInit();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxDomain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFormLibraryNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox tbxSharePointURL;
        private System.Windows.Forms.ComboBox drpdnlFormLibrary;
        private System.Windows.Forms.ErrorProvider errorList;
        private System.Windows.Forms.GroupBox group3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtUsermapFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtUniqueField1;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.CheckBox cbxFolderStructure;
        private System.Windows.Forms.TextBox txtUniqueField2;
        private System.Windows.Forms.TextBox tbxArchiveFolderPrefix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxMaxFileLimit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxDocLibDesc;
        private System.Windows.Forms.TextBox tbxTargetFolder;



    }
}