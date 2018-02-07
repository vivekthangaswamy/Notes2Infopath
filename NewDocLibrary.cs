using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tool
{
    public partial class NewDocLibrary : Form
    {
        #region Constructor
        public NewDocLibrary()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbxDocLibraryName.Text.Trim() == "")
            {
                errorList.Clear();
                errorList.SetError(tbxDocLibraryName, "Document Library is required");
                tbxDocLibraryName.Focus();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// This static method is used to get the values of document library name and description 
        /// that are entered by the user.
        /// </summary>
        /// <returns>ArrayList of values</returns>
        public static ArrayList GetDocListValues()
        {
            ArrayList docValues = new ArrayList();
            NewDocLibrary newDocLibrary = new NewDocLibrary();
            newDocLibrary.ShowDialog();
            docValues.Add(newDocLibrary.tbxDocLibraryName.Text.Trim());
            docValues.Add(newDocLibrary.tbxDocLibraryDesc.Text.Trim());
            return docValues;
        }
        #endregion        
    }
}