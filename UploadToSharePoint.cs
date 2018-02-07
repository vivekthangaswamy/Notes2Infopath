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
using System.Xml;
using InfoPathCustomMapping;

namespace Tool
{
    public partial class UploadToSharePoint : Form
    {
        private string _InputDataFilePath = string.Empty;
        private string _fileNameFld1 = string.Empty;
        private string _fileNameFld2 = string.Empty;
        private string _fileNameFld3 = string.Empty;
        private string _fileNameFld4 = string.Empty;
        private string _fileNameOption = string.Empty;
        private DataTable _dtFileNameGeneration=new DataTable();

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public UploadToSharePoint()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public DataTable FileNameGeneration
        {
            get
            {
                return _dtFileNameGeneration;
            }
            set
            {
                _dtFileNameGeneration = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileNameOption
        {
            set
            {
                _fileNameOption = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileNameFld1
        {
            set
            {
                _fileNameFld1 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileNameFld2
        {
            set
            {
                _fileNameFld2 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileNameFld3
        {
            set
            {
                _fileNameFld3 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileNameFld4
        {
            set
            {
                _fileNameFld4 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TargetFolder
        {
            set
            {
                tbxTargetFolder.Text = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UniqueField1
        {
            set
            {
                txtUniqueField1.Text = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UniqueField2
        {
            set
            {
                txtUniqueField2.Text = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InputDataFile
        {
            set
            {
                txtInputFile.Text = value;
                //_InputDataFilePath = value;
            }
        }
        #endregion

        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UploadToSharePoint.ActiveForm.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (tbxUserName.Text.Trim() == "")
            {
                errorList.Clear();
                errorList.SetError(tbxUserName, "User Name is required");
                tbxUserName.Focus();
            }
            else if (tbxPassword.Text.Trim() == "")
            {
                errorList.Clear();
                errorList.SetError(tbxPassword, "Password is required");
                tbxPassword.Focus();
            }
            else if (tbxDomain.Text.Trim() == "")
            {
                errorList.Clear();
                errorList.SetError(tbxDomain, "Domain is required");
                tbxDomain.Focus();
            }
            else if (tbxSharePointURL.Text.Trim() == "")
            {
                errorList.Clear();
                errorList.SetError(tbxSharePointURL, "SharePoint Site is required");
                tbxSharePointURL.Focus();
            }
            else if (drpdnlFormLibrary.Text.Trim() == "")
            {
                errorList.Clear();
                errorList.SetError(drpdnlFormLibrary, "Formlibrary is required");
                drpdnlFormLibrary.Focus();
            }
            else
            {
                int highestFolderFileCount = 0;
                //int fileCount = 1;
                string siteUrl = String.Empty;
                byte[] byteArr = null;
                StreamReader streamReader = null;
                FileInfo[] fileCollections = null;
                DirectoryInfo dirInfo = null;
                StringBuilder fileName = new StringBuilder();
                FileStream fileStream = null;

                try
                {
                    WindowsImpersonationContext wic = Utility.CreateIdentity(tbxUserName.Text.Trim(), tbxDomain.Text.Trim(), tbxPassword.Text.Trim()).Impersonate();

                    SPSite site = null;

                    //Check whether user enters full url of the site including "http"
                    if (tbxSharePointURL.Text.StartsWith("http"))
                    {
                        site = new SPSite(tbxSharePointURL.Text.Trim());
                    }
                    else
                    {
                        site = new SPSite("http://" + tbxSharePointURL.Text.Trim());
                    }
                    //MessageBox.Show(site.Url + "/" + drpdnlFormLibrary.Text.Trim());
                    SPWeb web = site.OpenWeb();
                    string weburl = web.Url;
                    SPFileCollection filesInSP = web.Files;
                    
                    site.AllowUnsafeUpdates = true;
                    web.AllowUnsafeUpdates = true;

                    SPFile sharePointFile = null;
                    dirInfo = new DirectoryInfo(tbxTargetFolder.Text.Trim());
                    fileCollections = dirInfo.GetFiles();

                    XmlDocument xmlInputData = new XmlDocument();
                    XmlDataDocument xmlUserMap = new XmlDataDocument();

                    LoadUserMapping(ref xmlUserMap);

                    //DataTable dtInputData = LoadInput2table(xmlInputData);
                    int maxNumber = 0;
                    SPFolder highestFolder = null;
                    string tempSiteUrl = String.Empty;
                    if (cbxFolderStructure.Checked)
                    {
                        highestFolder = FileSplitUtility.GetHighestFolder(web, drpdnlFormLibrary.Text.Trim(), tbxArchiveFolderPrefix.Text, ref maxNumber);
                        highestFolderFileCount = highestFolder.Files.Count;
                        tempSiteUrl = weburl + "/" + drpdnlFormLibrary.SelectedItem.ToString() + "/" + highestFolder.Name;
                    }
                    else
                    {
                        tempSiteUrl = weburl + "/" + drpdnlFormLibrary.SelectedItem.ToString();
                    }
                                        
                    FileUploadParam fileUploadParam = null;
                    string currentUser = tbxDomain.Text + "/" + tbxUserName.Text;

                    foreach (FileInfo file in fileCollections)
                    {
                        fileName.Append(file.FullName.Substring(file.DirectoryName.Length));
                        
                        if (fileName.Length > 128)
                        {
                            fileName.Replace(fileName.ToString(), fileName.ToString().Substring(0, 124));
                            fileName.Append(file.Extension);
                        }
                        fileStream = file.Open(FileMode.Open, FileAccess.Read);
                        siteUrl = tempSiteUrl + "/" + fileName.ToString().Substring(fileName.ToString().LastIndexOf(@"\") + 1);
                        
                        
                        streamReader = new StreamReader(fileStream);
                        
                        byteArr = System.Text.Encoding.ASCII.GetBytes(streamReader.ReadToEnd());

                        string fileNameWithoutExtn = fileName.ToString().Substring(1, fileName.Length - 5);                                   
                        
                        try
                        {
                            //DateTime dtCreatedDate = Convert.ToDateTime("10-10-2006");//drCurrRecord["CreatedDate"]);
                            //DateTime dtModifiedDate = Convert.ToDateTime("10-10-2006");//drCurrRecord["LastModifiedDate"]);

                            //Check whether user needs folder structure to upload the files,
                            //If yes, assign values to file upload parameters
                            if (cbxFolderStructure.Checked)
                            {
                                //Assigning values to the parameters for uploading files.
                                fileUploadParam = new FileUploadParam();
                                //fileUploadParam.CreatedBy = strCreatedWinUser;
                                //fileUploadParam.ModifiedBy =strModifiedWinUser;
                                fileUploadParam.FileContent = byteArr;
                                fileUploadParam.CurrentFileName = fileName.ToString();
                                fileUploadParam.HighestFolderName = highestFolder.Name;
                                fileUploadParam.HighestFolderFileCount = highestFolderFileCount;
                                fileUploadParam.FolderPrefix = tbxArchiveFolderPrefix.Text.Trim();
                                fileUploadParam.SiteUrl = siteUrl;
                                fileUploadParam.TargetList = web.Lists[drpdnlFormLibrary.Text.Trim()];
                                //fileUploadParam.CreatedDate =dtCreatedDate;
                                //fileUploadParam.ModifiedDate = dtModifiedDate;
                                fileUploadParam.AllowedFileLimit = int.Parse(tbxMaxFileLimit.Text);
                                
                                sharePointFile = FileSplitUtility.UploadFilesInSharePoint(fileUploadParam);

                                if (highestFolderFileCount >= int.Parse(tbxMaxFileLimit.Text.Trim()))
                                {
                                    highestFolderFileCount = 0;
                                }
                                ++highestFolderFileCount;
                            }
                            else
                            {
                                try
                                {
                                    //SPUser creator = web.Users[strCreatedWinUser];
                                    //SPUser modifier = web.Users[strModifiedWinUser];

                                    //if (creator.LoginName != "" && modifier.LoginName != "")
                                    //{
                                    //    sharePointFile = filesInSP.Add(siteUrl, byteArr, creator, modifier, dtCreatedDate, dtModifiedDate);
                                    //}
                                    //else
                                    //{
                                        sharePointFile = filesInSP.Add(siteUrl, byteArr, true);
                                    //}
                                }
                                catch (Exception exception)
                                {
                                    LogInfo("ERROR while convertin winuser to SPUser for file:" + fileName.ToString() + "  Error:" + exception.Message);
                                    sharePointFile = filesInSP.Add(siteUrl, byteArr, true);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            if (highestFolderFileCount >= int.Parse(tbxMaxFileLimit.Text.Trim()))
                            {
                                highestFolderFileCount = 0;
                            }
                            ++highestFolderFileCount;
                        }
                        //ends here

                        fileStream.Flush();
                        fileName.Remove(0, fileName.Length);
                    }
                    wic.Undo();
                    MessageBox.Show("Uploaded Successfully", "Upload");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in  uploading the file " + fileName + Environment.NewLine +
                        "Cannot proceed further." + Environment.NewLine +
                        "See log file for more details in root folder", "Upload Error");
                    StreamWriter logWriter = new StreamWriter(dirInfo.Root + "/Log.txt", false);
                    logWriter.Write("Error Message: " + ex.Message + System.Environment.NewLine + "Source of Error: " + fileName);
                    logWriter.Flush();
                    return;
                }
                finally
                {
                    streamReader.Close();
                    fileStream.Close();
                }
            }
        }

        private void LogInfo(string info)
        {
            try
            {
                //string strPath = Application.ExecutablePath;
                //strPath.
                
                StreamWriter logWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory +  @"\Log_UserMapErrors.txt", true);
                logWriter.Write(DateTime.Now.ToString() + " : " + info + System.Environment.NewLine);
                logWriter.Flush();
                logWriter.Close();
            }
            catch (Exception)
            {
            }
        }

        private void DebugLogInfo(string info)
        {
            try
            {
                //string strPath = Application.ExecutablePath;
                //strPath.

                StreamWriter logWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Log_Debug.txt", true);
                logWriter.Write(DateTime.Now.ToString() + " : " + info + System.Environment.NewLine);
                logWriter.Flush();
                logWriter.Close();
            }
            catch (Exception)
            {
            }
        }

        private string GetWindowsUser(XmlDataDocument xmlUserMap, string strLotusUser)
        {
            try
            {
                XmlNode node = xmlUserMap.SelectSingleNode("userMappings/user[@key='" + strLotusUser + "']");
                return node.Attributes["login"].Value.ToString();
            }
            catch (Exception ex)
            {
                LogInfo("ERROR in GetWindowsUser. Could not find matching windows user for:" + strLotusUser + " Error:" + ex.Message);
                //return string.Empty;      //commented to use the current user name as per deenus instruction on 2 Nov
                return tbxDomain.Text + @"\" + tbxUserName.Text;
            }
        }

        private DataRow GetCreatedModifiedVals(string fileName)
        {
            DataRow[] drFileNameFlds = null;
            try
            {
                drFileNameFlds = _dtFileNameGeneration.Select("FileName='" + fileName + "'");
                if (drFileNameFlds.Length > 0)
                {
                    return drFileNameFlds[0];
                }
                else
                {
                    return null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.Source);
                return null;
            }
        }
        
        //private DataRow GetRecordFromInput(DataTable dtInputData, string fileName)
        //{
        //    string fld1 = string.Empty;
        //    string fld2 = string.Empty;
        //    DataRow[] dr = null;

        //    fileName = fileName.Substring(1, fileName.Length - 5);
            
        //    string unformattedFileName = IdentifyFileNameFlds(fileName);

        //    DebugLogInfo("After IdentifyFileNameFlds. Fld1=" + txtUniqueField1.Text + "  fld2=" + txtUniqueField2.Text);
        //    string filterExpr = "";
        //    try
        //    {            
        //        if (txtUniqueField1.Text != "" && txtUniqueField2.Text != "")
        //        {
        //            fld1 = unformattedFileName.Substring(0, unformattedFileName.IndexOf("_"));
        //            fld2 = unformattedFileName.Substring(unformattedFileName.IndexOf("_") + 1);
        //            filterExpr = txtUniqueField1.Text + "='" + fld1.Trim() + "' AND " + txtUniqueField2.Text + "='" + fld2.Trim() + "'";
        //            DebugLogInfo("both fields not empty. Filter expr=" + filterExpr);
        //            dr = dtInputData.Select(filterExpr);
                    
        //            return dr[0];
        //        }
        //        else if (txtUniqueField1.Text != "" && txtUniqueField2.Text == "")
        //        {
        //            fld1 = unformattedFileName;
        //            filterExpr=txtUniqueField1.Text + "='" + fld1.Trim() + "'";
        //            DebugLogInfo("only unique fld 1. Filter expr:" + filterExpr);
        //            dr = dtInputData.Select(filterExpr);
                    
        //            return dr[0];
        //        }
        //        else if (txtUniqueField1.Text == "" && txtUniqueField2.Text != "")
        //        {
        //            fld1 = unformattedFileName;
        //            filterExpr=txtUniqueField2.Text + "='" + fld1.Trim() + "'";
        //            DebugLogInfo("only unique fld 2. Filter expr:" + filterExpr);
        //            dr = dtInputData.Select(filterExpr);

        //            return dr[0];
        //        }
        //        return dr[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + ex.Source);
        //        LogInfo("ERROR in GetRecordFromInput. Could not find matching record for file:" + fileName + "  Error:" + ex.Message);
        //        DataRow dr1 = dtInputData.NewRow();
        //        return dr1;
        //    }

        //}

        //private DataTable LoadInput2table(XmlDocument xmlInputData)
        //{
        //    DataTable tblInputData = new DataTable("InputData");

        //    //add the columns..
        //    tblInputData.Columns.Add("UniqueFld1");
        //    tblInputData.Columns.Add("UniqueFld2");
        //    tblInputData.Columns.Add("CreatedBy");
        //    tblInputData.Columns.Add("ModifiedBy");
        //    tblInputData.Columns.Add("CreatedDate");
        //    tblInputData.Columns.Add("ModifiedDate");
        //    tblInputData.Columns.Add(_fileNameFld1);
        //    tblInputData.Columns.Add(_fileNameFld2);
        //    if (_fileNameFld3 != _fileNameFld1 && _fileNameFld3 != _fileNameFld2)
        //    {
        //        tblInputData.Columns.Add(_fileNameFld3);
        //    }
        //    if (_fileNameFld4 != _fileNameFld1 && _fileNameFld4 != _fileNameFld2)
        //    {
        //        tblInputData.Columns.Add(_fileNameFld4);
        //    }

        //    XmlNodeList nlAllRecords = null;
        //    try
        //    {
        //        //get all the records
        //        nlAllRecords = xmlInputData.SelectNodes(@"descendant::record");
        //    }
        //    catch (Exception e)
        //    {
        //        LogInfo("ERROR in LoadInput2table :" + e.Message);
        //        throw new Exception("Incorrect input file format");
        //    }

        //    //loop through each record
        //    int i = 0;
        //    foreach (XmlNode node in nlAllRecords)
        //    {
        //        i = i + 1;
        //        try
        //        {
        //            DataRow row = tblInputData.NewRow();

        //            XmlNode datanode;
        //            //XmlNode datanode = node.SelectSingleNode("field[@name='" + txtUniqueField1.Text + "']");
        //            //row["UniqueFld1"] = datanode.InnerText.Trim();

        //            //if (txtUniqueField2.Text != "")
        //            //{
        //            //    datanode = node.SelectSingleNode("field[@name='" + txtUniqueField2.Text + "']");
        //            //    row["UniqueFld2"] = datanode.InnerText.Trim();
        //            //}

        //            if (_fileNameFld1 != "")
        //            {
        //                datanode = node.SelectSingleNode("field[@name='" + _fileNameFld1 + "']");
        //                row[_fileNameFld1] = datanode.InnerText.Trim();
        //            }
        //            if (_fileNameFld2 != "")
        //            {
        //                datanode = node.SelectSingleNode("field[@name='" + _fileNameFld2 + "']");
        //                row[_fileNameFld2] = datanode.InnerText.Trim();
        //            }
        //            if (_fileNameFld3 != "" && _fileNameFld3 != _fileNameFld1 && _fileNameFld3 != _fileNameFld2)
        //            {
        //                datanode = node.SelectSingleNode("field[@name='" + _fileNameFld3 + "']");
        //                row[_fileNameFld3] = datanode.InnerText.Trim();
        //            }
        //            if (_fileNameFld4 != "" && _fileNameFld4 != _fileNameFld1 && _fileNameFld4 != _fileNameFld2)
        //            {
        //                datanode = node.SelectSingleNode("field[@name='" + _fileNameFld4 + "']");
        //                row[_fileNameFld4] = datanode.InnerText.Trim();
        //            }

        //            datanode = node.SelectSingleNode("field[@name='doccreated']");
        //            row["CreatedDate"] = datanode.InnerText.Trim();

        //            datanode = node.SelectSingleNode("field[@name='docmodified']");
        //            row["ModifiedDate"] = datanode.InnerText.Trim();

        //            XmlNodeList nlModifiedBy = node.SelectNodes("field[@name='ModifiedBy']/element");

        //            row["CreatedBy"] = nlModifiedBy[0].InnerText.Trim();
        //            row["ModifiedBy"] = nlModifiedBy[nlModifiedBy.Count - 1].InnerText.Trim();

        //            tblInputData.Rows.Add(row);
        //        }
        //        catch (Exception ex)
        //        {
        //            LogInfo("ERROR in LoadInput2table, row:" + i.ToString() + "  " + ex.Message);
        //        }
        //    }

        //    return tblInputData;

        //}

        private void LoadUserMapping(ref XmlDataDocument xmlUserMap)
        {
            try
            {
                xmlUserMap.Load(txtUsermapFilePath.Text.Trim());
            }
            catch (Exception ex)
            {
                LogInfo("Error in LoadUserMapping: " + ex.Message);
                throw new Exception("Could not load the user map file");
            }
        }

        private void LoadInputData(ref XmlDocument xmlInputData)
        {
            try
            {
                //xmlInputData.Load(@"E:\Abdul\Mainframe_small.xml");
                xmlInputData.Load(txtInputFile.Text.Trim());
            }
            catch (Exception ex)
            {
                LogInfo("Error in LoadInputData: " + ex.Message);
                throw new Exception("Could not load the input data file");
            }
        }

        private void btnFormLibraryNew_Click(object sender, EventArgs e)
        {
            if (tbxUserName.Text.Trim() == "" || tbxPassword.Text.Trim() == "" || tbxDomain.Text.Trim() == "")
            {
                MessageBox.Show("You should provide the Credentials before creating SharePoint Library", "Create SharePoint Library");
                return;
            }
            if (drpdnlFormLibrary.Text.Trim() != "")
                drpdnlFormLibrary.Text = "";
            ArrayList docLibValues = new ArrayList();
            SPSite site = null;
            try
            {
                drpdnlFormLibrary.SelectedText = "";
                docLibValues = NewDocLibrary.GetDocListValues();
                WindowsImpersonationContext wic = Utility.CreateIdentity(tbxUserName.Text.Trim(), tbxDomain.Text.Trim(), tbxPassword.Text.Trim()).Impersonate();

                //check whether user has entered full url including "http"
                if (tbxSharePointURL.Text.StartsWith("http"))
                {
                    site = new SPSite(tbxSharePointURL.Text.Trim());
                }
                else
                {
                    site = new SPSite("http://" + tbxSharePointURL.Text.Trim());
                }
                
                SPWeb web = site.OpenWeb();
                SPListTemplate docLibrary = web.ListTemplates["Document Library"];
                drpdnlFormLibrary.Items.Add(docLibValues[0].ToString());
                drpdnlFormLibrary.SelectedText = docLibValues[0].ToString();
                tbxDocLibDesc.Text = docLibValues[1].ToString();
                web.Lists.Add(drpdnlFormLibrary.Text.Trim(), docLibValues[1].ToString(), docLibrary);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void tbxSharePointURL_Leave(object sender, EventArgs e)
        {
            if (drpdnlFormLibrary.Items.Count > 0)
            {
                drpdnlFormLibrary.Items.Clear();
            }
            SPSite site = null;
            try
            {
                WindowsImpersonationContext wic = Utility.CreateIdentity(tbxUserName.Text.Trim(), tbxDomain.Text.Trim(), tbxPassword.Text.Trim()).Impersonate();

                //check whether user has entered full url including "http"
                if (tbxSharePointURL.Text.StartsWith("http"))
                {
                    site = new SPSite(tbxSharePointURL.Text.Trim());
                }
                else
                {
                    site = new SPSite("http://" + tbxSharePointURL.Text.Trim());
                }
                SPWeb web = site.OpenWeb();
                SPListCollection lists = web.Lists;
                foreach (SPList list in lists)
                {
                    if (list.BaseType == SPBaseType.DocumentLibrary)
                    {
                        drpdnlFormLibrary.Items.Add(list.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
                return;
            }
        }
        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "XML Files(*.xml)|*.xml";
                openFileDialog1.ShowDialog();
                txtUsermapFilePath.Text = openFileDialog1.FileName;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem in opening XML file", "Error Opening File");
            }
        }

        private void cbxFolderStructure_CheckedChanged(object sender, EventArgs e)
        {
            tbxArchiveFolderPrefix.Enabled = !tbxArchiveFolderPrefix.Enabled ? true : false;
            tbxMaxFileLimit.Enabled = !tbxMaxFileLimit.Enabled ? true : false;
        }

        private void tbxSharePointURL_TextChanged(object sender, EventArgs e)
        {

        }

    }
}