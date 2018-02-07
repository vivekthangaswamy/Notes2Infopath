using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;
using System.Web;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using InfoPathCustomMapping;

namespace Tool
{
    public partial class SharePointFileAttachment : Form
    {
        public SharePointFileAttachment()
        {
            InitializeComponent();
        }

        private void btnFolderDialog_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.Description = "Select folder that contains Files to be uploaded in SharePoint";
                folderBrowserDialog1.ShowNewFolderButton = false;
                folderBrowserDialog1.ShowDialog();
                tbxFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in selecting folder", "Select Folder");
                return;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (tbxFolderPath.Text.Trim().Length <= 0)
            {
                RaiseError(tbxFolderPath, "Folder should be selected");
            }
            else if (tbxUserName.Text.Trim().Length <= 0)
            {
                RaiseError(tbxUserName, "Username is required");
            }
            else if (tbxPassword.Text.Trim().Length <= 0)
            {
                RaiseError(tbxPassword, "Password is required");
            }
            else if (tbxDomainName.Text.Trim().Length <= 0)
            {
                RaiseError(tbxDomainName, "Domain Name is required");
            }
            else if (tbxSharePointSiteName.Text.Trim().Length <= 0)
            {
                RaiseError(tbxSharePointSiteName, "SharePoint site name is required");
            }
            else
            {
                fileUploadErrorProvider.Clear();
                if (IsFilesAttachedToSPSite())
                {
                    MessageBox.Show("Files are successfully uploaded to SharePoint site", "Upload Files");
                }
                else
                {
                    MessageBox.Show("Error while uploading files to SharePoint site", "Upload Files");
                    return;
                }
            }

        }

        private void RaiseError(Control controlName, string errorToBeDisplayed)
        {
            fileUploadErrorProvider.Clear();
            fileUploadErrorProvider.SetError(controlName, errorToBeDisplayed);
            controlName.Focus();
            //return;
        }

        private bool IsFilesAttachedToSPSite()
        {
            byte[] fileBuffer = null;
            FileInfo[] fileCollections = null;
            DirectoryInfo dirInfo = null;
            string[] fileNameArray = null;
            FileStream fileStream = null;
            string mappingFieldValue = null;
            string fileName = null;

            try
            {
                WindowsImpersonationContext wic = Utility.CreateIdentity(tbxUserName.Text.Trim(), tbxDomainName.Text.Trim(), tbxPassword.Text.Trim()).Impersonate();

                SPSite site = new SPSite("http://" + tbxSharePointSiteName.Text.Trim());
                SPWeb web = site.OpenWeb();
                string weburl = web.Url;
                SPList list = web.Lists[cbxLists.Text.Trim()];
                dirInfo = new DirectoryInfo(tbxFolderPath.Text.Trim());
                fileCollections = dirInfo.GetFiles();
                
                foreach (FileInfo file in fileCollections)
                {
                    fileNameArray = file.Name.Split('-');
                    mappingFieldValue = fileNameArray[0];
                    fileName = fileNameArray[1];
                    foreach (SPListItem myListItem in list.Items)
                    {
                        //if (String.Compare(myListItem[tbxMappingField.Text.Trim()].ToString(), mappingFieldValue, true) == 0)
                        //{
                        
                            MessageBox.Show(myListItem["Editor"].ToString());
                            MessageBox.Show(myListItem["Subject"].ToString());
                            fileStream = file.Open(FileMode.Open, FileAccess.Read);
                            fileBuffer = new byte[fileStream.Length];
                            int bytesRead = fileStream.Read(fileBuffer, 0, Convert.ToInt32(fileStream.Length));
                            //list.EnableAttachments = true;
                            //myListItem.Attachments.Add("CNC1"+fileName, fileBuffer);
                            //myListItem.Update();
                            myListItem["Editor"] = "Test Name";
                            myListItem.Update();
                        //}
                            site.AllowUnsafeUpdates = true;
                            web.AllowUnsafeUpdates = true;
                    }
                   
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                return false;
            }
            finally
            {
                fileStream.Close();
            }
        }

        private void tbxSharePointSiteName_Leave(object sender, EventArgs e)
        {
            if (cbxLists.Items.Count > 0)
            {
                cbxLists.Items.Clear();
            }

            try
            {
                WindowsImpersonationContext wic = Utility.CreateIdentity(tbxUserName.Text.Trim(), tbxDomainName.Text.Trim(), tbxPassword.Text.Trim()).Impersonate();

                SPSite site = new SPSite("http://" + tbxSharePointSiteName.Text.Trim());
                SPWeb web = site.OpenWeb();
                SPListCollection lists = web.Lists;
                foreach (SPList list in lists)
                {
                    if (list.BaseType == SPBaseType.GenericList || list.BaseType == SPBaseType.DiscussionBoard)
                    {
                        cbxLists.Items.Add(list.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}