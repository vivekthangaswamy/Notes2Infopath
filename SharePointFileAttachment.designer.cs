namespace Tool
{
    partial class SharePointFileAttachment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxDomainName = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxLists = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxMappingField = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxSharePointSiteName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFolderDialog = new System.Windows.Forms.Button();
            this.tbxFolderPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fileUploadErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileUploadErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxDomainName);
            this.groupBox1.Controls.Add(this.tbxPassword);
            this.groupBox1.Controls.Add(this.tbxUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SharePoint Authentication";
            // 
            // tbxDomainName
            // 
            this.tbxDomainName.BackColor = System.Drawing.SystemColors.Window;
            this.tbxDomainName.Location = new System.Drawing.Point(132, 66);
            this.tbxDomainName.Name = "tbxDomainName";
            this.tbxDomainName.Size = new System.Drawing.Size(170, 20);
            this.tbxDomainName.TabIndex = 5;
            this.tbxDomainName.Text = "cn1dc";
            // 
            // tbxPassword
            // 
            this.tbxPassword.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPassword.Location = new System.Drawing.Point(132, 43);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(170, 20);
            this.tbxPassword.TabIndex = 4;
            this.tbxPassword.Text = "T@miln@du1";
            // 
            // tbxUserName
            // 
            this.tbxUserName.BackColor = System.Drawing.SystemColors.Window;
            this.tbxUserName.Location = new System.Drawing.Point(132, 19);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(170, 20);
            this.tbxUserName.TabIndex = 3;
            this.tbxUserName.Text = "deenu.varghese";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Domain: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxLists);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.tbxMappingField);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbxSharePointSiteName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 130);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SharePoint Site Info";
            // 
            // cbxLists
            // 
            this.cbxLists.FormattingEnabled = true;
            this.cbxLists.Location = new System.Drawing.Point(132, 46);
            this.cbxLists.Name = "cbxLists";
            this.cbxLists.Size = new System.Drawing.Size(170, 21);
            this.cbxLists.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Select List:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxMappingField
            // 
            this.tbxMappingField.BackColor = System.Drawing.SystemColors.Window;
            this.tbxMappingField.Location = new System.Drawing.Point(132, 73);
            this.tbxMappingField.Name = "tbxMappingField";
            this.tbxMappingField.Size = new System.Drawing.Size(170, 20);
            this.tbxMappingField.TabIndex = 3;
            this.tbxMappingField.Text = "UNID";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(132, 99);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Mapping Field:";
            // 
            // tbxSharePointSiteName
            // 
            this.tbxSharePointSiteName.BackColor = System.Drawing.SystemColors.Window;
            this.tbxSharePointSiteName.Location = new System.Drawing.Point(132, 19);
            this.tbxSharePointSiteName.Name = "tbxSharePointSiteName";
            this.tbxSharePointSiteName.Size = new System.Drawing.Size(225, 20);
            this.tbxSharePointSiteName.TabIndex = 1;
            this.tbxSharePointSiteName.Text = "10.230.207.40:2080/param";
            this.tbxSharePointSiteName.Leave += new System.EventHandler(this.tbxSharePointSiteName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Enter SharePoint Site:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFolderDialog);
            this.groupBox3.Controls.Add(this.tbxFolderPath);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 69);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Folder Selection";
            // 
            // btnFolderDialog
            // 
            this.btnFolderDialog.Location = new System.Drawing.Point(132, 40);
            this.btnFolderDialog.Name = "btnFolderDialog";
            this.btnFolderDialog.Size = new System.Drawing.Size(75, 23);
            this.btnFolderDialog.TabIndex = 2;
            this.btnFolderDialog.Text = "Browse...";
            this.btnFolderDialog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFolderDialog.UseVisualStyleBackColor = true;
            this.btnFolderDialog.Click += new System.EventHandler(this.btnFolderDialog_Click);
            // 
            // tbxFolderPath
            // 
            this.tbxFolderPath.BackColor = System.Drawing.SystemColors.Window;
            this.tbxFolderPath.Location = new System.Drawing.Point(132, 18);
            this.tbxFolderPath.Name = "tbxFolderPath";
            this.tbxFolderPath.Size = new System.Drawing.Size(250, 20);
            this.tbxFolderPath.TabIndex = 1;
            this.tbxFolderPath.Text = "E:\\temp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select Folder:";
            // 
            // fileUploadErrorProvider
            // 
            this.fileUploadErrorProvider.ContainerControl = this;
            // 
            // SharePointFileAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 329);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "SharePointFileAttachment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload Files To SharePoint";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileUploadErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxDomainName;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxSharePointSiteName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFolderDialog;
        private System.Windows.Forms.TextBox tbxFolderPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxMappingField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ErrorProvider fileUploadErrorProvider;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxLists;
    }
}

