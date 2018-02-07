using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tool
{
    public partial class frmFileNameSelection : Form
    {
        #region Default Constructor
        public frmFileNameSelection()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Properties

        private IEnumerator schemaFields;
        private bool isDateTimeRequired;
        private string fileNameOption;
        private string fileName1;
        private string fileName2;
        private string addlFileName1;
        private string addlFileName2;

        public bool IsDateTimeRequired
        {
            get { return isDateTimeRequired; }
            set { isDateTimeRequired = value; }
        }
        public string FileNameOption
        {
            get { return fileNameOption; }
            set { fileNameOption = value; }
        }

        public string FileName1
        {
            get { return fileName1; }
            set { fileName1 = value; }
        }

        public string FileName2
        {
            get { return fileName2; }
            set { fileName2 = value; }
            
        }

        public string AddlFileName1
        {
            get { return addlFileName1; }
            set { addlFileName1 = value; }
        }

        public string AddlFileName2
        {
            get { return addlFileName2; }
            set { addlFileName2 = value; }
            
        }

        public IEnumerator SchemaFields
        {
            get { return schemaFields; }
            set { schemaFields = value; }
        }

        #endregion

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmFileNameSelection.ActiveForm.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValidate())
                {
                    FileNameOption = cbxFileNameOptions.Text;
                    FileName1 = cbxFileName1.Text;
                    FileName2 = cbxFileName2.Text;
                    AddlFileName1 = cbxAddlFileName1.Text;
                    AddlFileName2 = cbxAddlFileName2.Text;
                    IsDateTimeRequired = cbxDateTime.Checked;

                    frmFileNameSelection.ActiveForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error :" + ex.Message);
            }
        }

        private void frmFileNameSelection_Load(object sender, EventArgs e)
        {
            cbxDateTime.Checked = IsDateTimeRequired;
            cbxFileNameOptions.SelectedText = FileNameOption;
            cbxFileName1.SelectedText = FileName1;
            cbxFileName2.SelectedText = FileName2;
            cbxAddlFileName1.SelectedText = AddlFileName1;
            cbxAddlFileName2.SelectedText = AddlFileName2;
            if (AddlFileName1 != null && AddlFileName2 != null)
            {
                cbxAddlFileName1.Enabled = AddlFileName1.Length > 0 ? true : false;
                cbxAddlFileName2.Enabled = AddlFileName2.Length > 0 ? true : false;
            }

            while (SchemaFields.MoveNext())
            {
                cbxFileName1.Items.Add(schemaFields.Current);
                cbxFileName2.Items.Add(schemaFields.Current);
                cbxAddlFileName1.Items.Add(schemaFields.Current);
                cbxAddlFileName2.Items.Add(schemaFields.Current);
            }
        }

        private void ShowError(Control errorControl, string errorMessage)
        {
            fileNameSelectionErrorProvider.SetError(errorControl, errorMessage);
            errorControl.Focus();
        }

        private bool IsFormValidate()
        {
            try
            {
                switch (cbxFileNameOptions.Text)
                {
                    case "Both Fields":
                        {
                            fileNameSelectionErrorProvider.Clear();
                            if (cbxFileName1.Text.Trim().Length == 0 || cbxFileName2.Text.Trim().Length == 0)
                            {
                                ShowError(cbxFileName1.Text.Trim().Length > 1 ? cbxFileName2 : cbxFileName1, "You should select both fields");
                                return false;
                            }
                            break;
                        }
                    case "Either One":
                        {
                            fileNameSelectionErrorProvider.Clear();
                            if (cbxFileName1.Text.Trim().Length == 0 && cbxFileName2.Text.Trim().Length == 0)
                            {
                                ShowError(cbxFileName1.Text.Trim().Length > 1 ? cbxFileName2 : cbxFileName1, "You should select at least one field");
                                return false;
                            }
                            break;
                        }
                    case "Either Rows":
                        {
                            fileNameSelectionErrorProvider.Clear();
                            if (cbxFileName1.Text.Trim().Length == 0 || cbxFileName2.Text.Trim().Length == 0 || cbxAddlFileName1.Text.Trim().Length == 0 || cbxAddlFileName2.Text.Trim().Length == 0)
                            {
                                ShowError(cbxFileName1.SelectedIndex != -1 ? (cbxFileName2.SelectedIndex != -1 ? (cbxAddlFileName1.SelectedIndex != -1 ? cbxAddlFileName2 : cbxAddlFileName1) : cbxFileName2 ) : cbxFileName1 , "You should select either rows with at least one field.");
                                return false;
                            }
                            break;
                        }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cbxFileNameOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxFileNameOptions.Text)
            {
                case "Both Fields":
                    {
                        lblFileNameOptionHint.Text = "Name of the file contains both selected field values." + System.Environment.NewLine + 
                            "Any one of the selected fields should have unique values.";
                        cbxAddlFileName1.Enabled = false;
                        cbxAddlFileName2.Enabled = false;
                        break;
                    }
                case "Either One":
                    {
                        lblFileNameOptionHint.Text = "Name of the file contains any one of the selected field values." + System.Environment.NewLine +  
                        "Make sure the selected fields should contain unique values.";
                        cbxAddlFileName1.Enabled = false;
                        cbxAddlFileName2.Enabled = false;
                        break;
                    }
                case "Either Rows":
                    {
                        lblFileNameOptionHint.Text = "Name of the file contains any one of the rows selected field values.";
                        cbxAddlFileName1.Enabled = true;
                        cbxAddlFileName2.Enabled = true;
                        break;
                    }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            frmFileNameSelection.ActiveForm.Close();
        }
    }
}