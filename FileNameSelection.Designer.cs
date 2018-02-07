namespace Tool
{
    partial class frmFileNameSelection
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
            this.cbxDateTime = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbxAddlFileName2 = new System.Windows.Forms.ComboBox();
            this.cbxAddlFileName1 = new System.Windows.Forms.ComboBox();
            this.cbxFileName2 = new System.Windows.Forms.ComboBox();
            this.cbxFileName1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxFileNameOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileNameOptionHint = new System.Windows.Forms.Label();
            this.fileNameSelectionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileNameSelectionErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxDateTime);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.cbxAddlFileName2);
            this.groupBox1.Controls.Add(this.cbxAddlFileName1);
            this.groupBox1.Controls.Add(this.cbxFileName2);
            this.groupBox1.Controls.Add(this.cbxFileName1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxFileNameOptions);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Name Selection";
            // 
            // cbxDateTime
            // 
            this.cbxDateTime.AutoSize = true;
            this.cbxDateTime.Location = new System.Drawing.Point(129, 125);
            this.cbxDateTime.Name = "cbxDateTime";
            this.cbxDateTime.Size = new System.Drawing.Size(152, 17);
            this.cbxDateTime.TabIndex = 12;
            this.cbxDateTime.Text = "Append Created DateTime";
            this.cbxDateTime.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(185, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(129, 148);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(50, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbxAddlFileName2
            // 
            this.cbxAddlFileName2.Enabled = false;
            this.cbxAddlFileName2.FormattingEnabled = true;
            this.cbxAddlFileName2.Location = new System.Drawing.Point(382, 92);
            this.cbxAddlFileName2.Name = "cbxAddlFileName2";
            this.cbxAddlFileName2.Size = new System.Drawing.Size(150, 21);
            this.cbxAddlFileName2.TabIndex = 9;
            // 
            // cbxAddlFileName1
            // 
            this.cbxAddlFileName1.Enabled = false;
            this.cbxAddlFileName1.FormattingEnabled = true;
            this.cbxAddlFileName1.Location = new System.Drawing.Point(129, 92);
            this.cbxAddlFileName1.Name = "cbxAddlFileName1";
            this.cbxAddlFileName1.Size = new System.Drawing.Size(150, 21);
            this.cbxAddlFileName1.TabIndex = 8;
            // 
            // cbxFileName2
            // 
            this.cbxFileName2.FormattingEnabled = true;
            this.cbxFileName2.Location = new System.Drawing.Point(382, 58);
            this.cbxFileName2.Name = "cbxFileName2";
            this.cbxFileName2.Size = new System.Drawing.Size(150, 21);
            this.cbxFileName2.TabIndex = 7;
            // 
            // cbxFileName1
            // 
            this.cbxFileName1.FormattingEnabled = true;
            this.cbxFileName1.Location = new System.Drawing.Point(129, 58);
            this.cbxFileName1.Name = "cbxFileName1";
            this.cbxFileName1.Size = new System.Drawing.Size(150, 21);
            this.cbxFileName1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Addl File Name2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Addl File Name1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "File Name2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File Name1:";
            // 
            // cbxFileNameOptions
            // 
            this.cbxFileNameOptions.FormattingEnabled = true;
            this.cbxFileNameOptions.Items.AddRange(new object[] {
            "Both Fields",
            "Either One",
            "Either Rows"});
            this.cbxFileNameOptions.Location = new System.Drawing.Point(129, 22);
            this.cbxFileNameOptions.Name = "cbxFileNameOptions";
            this.cbxFileNameOptions.Size = new System.Drawing.Size(150, 21);
            this.cbxFileNameOptions.TabIndex = 1;
            this.cbxFileNameOptions.SelectedIndexChanged += new System.EventHandler(this.cbxFileNameOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name Options:";
            // 
            // lblFileNameOptionHint
            // 
            this.lblFileNameOptionHint.AutoSize = true;
            this.lblFileNameOptionHint.Location = new System.Drawing.Point(12, 196);
            this.lblFileNameOptionHint.Name = "lblFileNameOptionHint";
            this.lblFileNameOptionHint.Size = new System.Drawing.Size(0, 13);
            this.lblFileNameOptionHint.TabIndex = 12;
            // 
            // fileNameSelectionErrorProvider
            // 
            this.fileNameSelectionErrorProvider.ContainerControl = this;
            // 
            // frmFileNameSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 238);
            this.Controls.Add(this.lblFileNameOptionHint);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileNameSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Name Selection";
            this.Load += new System.EventHandler(this.frmFileNameSelection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileNameSelectionErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxFileNameOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxAddlFileName2;
        private System.Windows.Forms.ComboBox cbxAddlFileName1;
        private System.Windows.Forms.ComboBox cbxFileName2;
        private System.Windows.Forms.ComboBox cbxFileName1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblFileNameOptionHint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider fileNameSelectionErrorProvider;
        private System.Windows.Forms.CheckBox cbxDateTime;        
    }
}