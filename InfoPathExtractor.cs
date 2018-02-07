using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Domino;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using InfoPathCustomMapping;


namespace Tool
{
    public partial class InfoPathExtractor : Form
    {
        #region InitializeComponent
        /// <summary>
        /// 
        /// </summary>
        public InfoPathExtractor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoPathExtractor_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public bool resetFileSelectionForm = false;
        #endregion              

        #region GenerateLotusXML file
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlDocument GenerateLotusXML()
        {
                Domino.ISession session = new NotesSessionClass();
                //session.Initialize("Ker@l@123");
                session.Initialize("");
               
                
                //Domino.NotesDatabase database = session.GetDatabase("", txtLotusFile.Text.Trim(), false);
                //string strLotusdbName = GetNSFdbName();
                Domino.NotesDatabase database = session.GetDatabase("", txtLotusFile.Text.Trim(), false);
                Domino.NotesNoteCollection noteCollecton = database.CreateNoteCollection(true);

                noteCollecton.SelectAllAdminNotes(true);
                noteCollecton.SelectAllCodeElements(true);
                noteCollecton.SelectAllDataNotes(true);
                noteCollecton.SelectAllDesignElements(true);
                noteCollecton.SelectAllFormatElements(true);
                noteCollecton.SelectAllIndexElements(true);               
                noteCollecton.SelectForms = true;
                noteCollecton.SinceTime = true;   
                noteCollecton.BuildCollection();

                Domino.NotesDXLExporter exporter = (Domino.NotesDXLExporter)session.CreateDXLExporter();

                string strNsfXML = exporter.Export(noteCollecton);

                // removes the <!DOCTYPE database SYSTEM 'xmlschemas/domino_6_5_4.dtd'>
                string strDocrmv = strNsfXML.Replace("<!DOCTYPE database SYSTEM 'xmlschemas/domino_6_5_4.dtd'>", "");
                // removes the xmlns='http://www.lotus.com/dxl'
                strDocrmv = strDocrmv.Replace("xmlns='http://www.lotus.com/dxl'", "");
                                
                XmlDocument xmlLotusDoc = new XmlDocument();
                xmlLotusDoc.LoadXml(strDocrmv);

                return xmlLotusDoc;
            }
        #endregion

        #region Save the lotus data into intermediate XML
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlParamOriginal"></param>
        public void CreateDocinDocNode(XmlDocument xmlParamOriginal)
        {
            try
            {
                XmlDocument loadFirstDoc = new XmlDocument();
                loadFirstDoc.LoadXml(xmlParamOriginal.OuterXml);

                string strNameValue = "";
                string strInfoPathFileName = "";

                XmlNodeList xmlDocTypeList = loadFirstDoc.GetElementsByTagName("document");

                for (int i = 0; i < xmlDocTypeList.Count; i++)
                {
                    XmlDocument xDocTrgtFile = new XmlDocument();

                    foreach (XmlNode node in xmlDocTypeList)
                    {
                        strNameValue = xmlDocTypeList[i].Attributes["form"].Value;
                        strInfoPathFileName = strNameValue;

                        xDocTrgtFile.PreserveWhitespace = true;

                        xDocTrgtFile.LoadXml(xmlDocTypeList[i].OuterXml);
                        string strinfoModFileName = ManipulateFileName(strInfoPathFileName + i);
                        
                        xDocTrgtFile.Save(strinfoModFileName + ".xml");
                        ChangeInfoFormat(strinfoModFileName + ".xml");
                        
                        i++;
                    }
                }
                MessageBox.Show("Files Generated Successfully");  
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
        #endregion

        #region ManipulateFileName
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public string ManipulateFileName(string strFileName)
        {
            string strReString = Regex.Replace(strFileName, @"[^\w\.@-]", "");
            string strReString1 =Regex.Replace(strFileName, " ", "");   
            return strReString1;
        }
        #endregion

        #region Function for Change Lotus Generated XML into infopath format
        /// <summary>
        /// This function is used to generate the infopath xml files
        /// from the lotus notes api generated xml
        /// </summary>
        /// <param name="lotusDocXml"></param>
        public void ChangeInfoFormat(string lotusDocXml)
        {
            // The source Lotus notes api generated XML is loaded to a document
            XmlDocument NotesDoc = new XmlDocument();
            NotesDoc.Load(lotusDocXml);

            //The Infopath document in which the data needs to be inserted
            XmlDocument InfopathDoc = new XmlDocument();
            InfopathDoc.Load(txtTempFile.Text.Trim());

            XmlNamespaceManager nsMgr = new XmlNamespaceManager(InfopathDoc.NameTable);

            //Retrieve the item tag
            XmlNodeList lotusFieldNames = NotesDoc.SelectNodes("//item[@name]");
            string fieldsDataType=String.Empty;

            string prevnodename = string.Empty;

            foreach (XmlAttribute attr in InfopathDoc.DocumentElement.Attributes)
            {
                if (attr.Prefix == "xmlns")
                {
                    nsMgr.AddNamespace(attr.LocalName, attr.Value);
                }
            }
            for (int i = 0; i < lotusFieldNames.Count; i++)
            {
                try
                {
                    if (lotusFieldNames[i].Attributes["name"].Value != "$FILE")
                    {
                        XmlNodeList targetList = null;
                        try
                        {
                            targetList = InfopathDoc.SelectNodes(@"descendant::my:" + lotusFieldNames[i].Attributes[0].Value, nsMgr);
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.ToString());
                        }
                        if (targetList != null && targetList.Count > 0)
                        {
                            for (int j = 0; j < mappedFieldsView.Rows.Count - 1; j++)
                            {
                                if (String.Compare(targetList[0].LocalName, mappedFieldsView.Rows[j].Cells[0].Value.ToString(), false) == 0)
                                {
                                    fieldsDataType = mappedFieldsView.Rows[j].Cells[2].Value.ToString();
                                }
                            }

                            if (fieldsDataType == "base64Binary")
                            {
                                targetList[0].InnerText = "";
                            }
                            else if (fieldsDataType == "date" && lotusFieldNames[i].InnerText.Length > 0)
                            {
                                if (targetList[0].OuterXml.Contains("xsi:nil"))
                                {
                                    targetList[0].Attributes.RemoveNamedItem("xsi:nil");
                                }
                                string dat = lotusFieldNames[i].InnerText.Trim();
                                //targetList[0].InnerText = string.Format("{0:####-##-##}", dat);
                                string a = dat.Substring(0, 4);
                                string b = dat.Substring(4, 2);
                                string c = dat.Substring(6);

                                targetList[0].InnerText = a + "-" + b + "-" + c;
                            }
                            else
                            {
                                targetList[0].InnerText = lotusFieldNames[i].InnerText;
                            }
                            InfopathDoc.Save(txtTargetFolder.Text.Trim() + @"\" + lotusDocXml);
                            prevnodename = lotusFieldNames[i].Attributes[0].Value;
                        }
                    }
                    else
                    {
                        XmlNodeList targetList = InfopathDoc.SelectNodes(@"descendant::my:" + prevnodename, nsMgr);
                        if (targetList[0].OuterXml.Contains("xsi:nil"))
                        {
                            targetList[0].Attributes.RemoveNamedItem("xsi:nil");
                        }
                        string filename = string.Empty;
                        XmlNode xmlname = lotusFieldNames[i].SelectSingleNode("//file");
                        filename = xmlname.Attributes["name"].Value.ToString();
                        XmlNode sourcenode = lotusFieldNames[i].SelectSingleNode("//filedata");
                        FileAttachment.InfoPathFileAttachmentForDataMigration(InfopathDoc, targetList[0], sourcenode, filename);
                        InfopathDoc.Save(txtTargetFolder.Text.Trim() + @"\" + lotusDocXml);
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        #endregion

        #region Buttons Click Events
        /// <summary>
        /// Select Schema File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectSchema_Click(object sender, EventArgs e)
        {
            fileOpenDialog.FileName = "";
            fileOpenDialog.Filter = "XSD Files(*.xsd)|*.xsd";
            fileOpenDialog.FilterIndex = 1;
            fileOpenDialog.RestoreDirectory = true;
            fileOpenDialog.ShowDialog();
            txtSchemaFile.Text = fileOpenDialog.FileName;   
        }

        /// <summary>
        /// Select Lotus Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void btnShowFields_Click(object sender, EventArgs e)
        {
            try
            {
                lbxNSFFields.DataSource = null;
                lbxSchemaFields.DataSource = null;
                lbxSchemaDataTypes.DataSource = null;
                lbxNSFFields.Items.Clear();
                lbxSchemaFields.Items.Clear();
                lbxSchemaDataTypes.Items.Clear();

                string strLotusdbName = txtLotusFile.Text.Trim();

                if (strLotusdbName.Trim().Length <= 0 && txtTempFile.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select Lotus Database & Template XML files", "Select Files");
                    return;
                }
                else if (strLotusdbName.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select Lotus Database file", "Select Files");
                    return;
                }
                else if (cbxListForm.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select the Form Name", "Select Form");
                    return; 
                }
                else
                {
                    string strSeletedItem = cbxListForm.SelectedItem.ToString();

                    DisplayLotusFields(strLotusdbName, strSeletedItem);
                    XmlNodeList schemaFields = DisplaySchemaFields(txtSchemaFile.Text);
                    if (schemaFields != null)
                    {
                        foreach (XmlNode fieldNames in schemaFields)
                        {
                            lbxSchemaFields.Items.Add(fieldNames.Attributes["name"].Value);

                            if (!fieldNames.HasChildNodes)
                            {
                                if (fieldNames.Attributes["type"] != null)
                                {
                                    if (fieldNames.Attributes["type"].Value.LastIndexOf(':') != -1)
                                    {
                                        lbxSchemaDataTypes.Items.Add(fieldNames.Attributes["type"].Value.Substring(fieldNames.Attributes["type"].Value.LastIndexOf(':') + 1));
                                    }
                                    else
                                    {
                                        lbxSchemaDataTypes.Items.Add(fieldNames.Attributes["type"].Value);
                                    }
                                }
                            }
                            else if (fieldNames.ChildNodes[0].Attributes.Count > 0)
                            {
                                lbxSchemaDataTypes.Items.Add(fieldNames.ChildNodes[0].Attributes[0].Name);
                            }
                            else
                                lbxSchemaDataTypes.Items.Add(String.Empty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Auto Map the Lotus and Schema Fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoMap_Click(object sender, EventArgs e)
        {
            if (lbxSchemaFields.Items.Count <= 0 || lbxNSFFields.Items.Count <= 0)
            {
                MessageBox.Show("There are no fields in either XML Fields or Schema Fields", "Auto Map");
                return;
            }
            if (mappedFieldsView.Rows.Count >= 0 && mappedFieldsView.DataSource == null)
            {
                mappedFieldsView.Rows.Clear();
                int rowCount = 0;
                for (int i = 0; i < lbxNSFFields.Items.Count; i++)
                {
                    for (int j = 0; j < lbxSchemaFields.Items.Count; j++)
                    {
                        if (String.Compare(lbxNSFFields.Items[i].ToString(), lbxSchemaFields.Items[j].ToString(), false) == 0)
                        {
                            mappedFieldsView.Rows.Add();
                            mappedFieldsView.Rows[rowCount].Cells[0].Value = lbxNSFFields.Items[i].ToString();
                            mappedFieldsView.Rows[rowCount].Cells[1].Value = lbxSchemaFields.Items[j].ToString();
                            if (lbxSchemaDataTypes.Items[j].ToString() != String.Empty)
                            {
                                mappedFieldsView.Rows[rowCount].Cells[2].Value = lbxSchemaDataTypes.Items[j].ToString();
                            }
                            ++rowCount;
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You cannot Map fields, since the Grid already loaded with data using DataSource", "Auto Map");
                return;
            }
            if (mappedFieldsView.Rows.Count <= 0)
            {
                MessageBox.Show("There are no exact mapping available. Please do manual map", "Auto Map");
            }
        }

        /// <summary>
        /// Manual Mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManualMapping_Click(object sender, EventArgs e)
        {
            try
            {
                int rowCount = 0;
                if (!(lbxNSFFields.SelectedIndex == -1 || lbxSchemaFields.SelectedIndex == -1))
                {
                    if (mappedFieldsView.Rows.Count > 0)
                        rowCount = mappedFieldsView.Rows.Count - 1;
                    mappedFieldsView.Rows.Add();
                    mappedFieldsView.Rows[rowCount].Cells[0].Value = lbxNSFFields.Items[lbxNSFFields.SelectedIndex].ToString();
                    mappedFieldsView.Rows[rowCount].Cells[1].Value = lbxSchemaFields.Items[lbxSchemaFields.SelectedIndex].ToString();
                    if (lbxSchemaDataTypes.Items[lbxSchemaFields.SelectedIndex].ToString() != String.Empty)
                    {
                        mappedFieldsView.Rows[rowCount].Cells[2].Value = lbxSchemaDataTypes.Items[lbxSchemaFields.SelectedIndex].ToString();
                    }
                    lbxNSFFields.Items.RemoveAt(lbxNSFFields.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("You should select both XML and Schema fields to map", "Map Fields");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You cannot add row manually after XML file is loaded", "Error");
            }
        }

        /// <summary>
        /// Select Target Folder for store the XML files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            txtTargetFolder.Text = folderBrowserDialog.SelectedPath;
        }

        /// <summary>
        /// Select Template File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectTempFile_Click(object sender, EventArgs e)
        {
            fileOpenDialog.FileName = "";
            fileOpenDialog.Filter = "XML Files(*.xml)|*.xml";
            fileOpenDialog.FilterIndex = 1;
            fileOpenDialog.RestoreDirectory = true;
            fileOpenDialog.ShowDialog();
            txtTempFile.Text = fileOpenDialog.FileName;
        }
        /// <summary>
        /// Select Lotus Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLotusDb_Click(object sender, EventArgs e)
        {
            fileOpenDialog.FileName = "";
            fileOpenDialog.Filter = "NSF Files(*.nsf)|*.nsf|NS3 Files(*.ns3)|*.ns3";
            fileOpenDialog.FilterIndex = 1;
            fileOpenDialog.RestoreDirectory = true;
            fileOpenDialog.ShowDialog();
            txtLotusFile.Text = fileOpenDialog.FileName;
        }       

        /// <summary>
        /// List all Forms in the Selected Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowForms_Click(object sender, EventArgs e)
        {
            try
            {
                cbxListForm.Items.Clear();
                lbxNSFFields.Items.Clear();
                lbxSchemaDataTypes.Items.Clear();
                lbxSchemaFields.Items.Clear();

                XmlDocument xNSFForms = new XmlDocument();
                xNSFForms = GenerateLotusXML();

                XmlNodeList xFrmNodes = xNSFForms.SelectNodes("database/form");
                for (int i = 0; i < xFrmNodes.Count; i++)
                {
                    cbxListForm.Items.Add(xFrmNodes[i].Attributes["name"].Value);
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// Reset Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetFileSelectionForm = true;
            ResetControls();
        }
        #endregion

        #region Functions
        /// <summary>
        /// Function for list the Lotus Fields in list box
        /// </summary>
        /// <param name="lotusFileName"></param>
        /// <param name="selectValue"></param>
        public void DisplayLotusFields(string lotusFileName, string selectValue)
        {
                XmlDocument xLotusDoc = new XmlDocument();
                xLotusDoc = GenerateLotusXML();
                XmlDocument xLoadLotusDoc = new XmlDocument();
                xLoadLotusDoc.LoadXml(xLotusDoc.OuterXml);

                XmlNodeList xmlLotusDocList = xLoadLotusDoc.SelectNodes("//document[@form ='" + selectValue + "']");

                XmlDocument xmlLotus = new XmlDocument();

                MessageBox.Show("The total Records for the selected Form is " + xmlLotusDocList.Count);    
                if (xmlLotusDocList.Count > 0)
                {
                    xmlLotus.LoadXml(xmlLotusDocList[0].OuterXml);
                    XmlNodeList lotusFields = xmlLotus.SelectNodes("//item[@name]");

                    for (int i = 0; i < lotusFields.Count; i++)
                    {
                        lbxNSFFields.Items.Add(lotusFields[i].Attributes[0].Value);
                    }
                }
                else
                {                    
                    MessageBox.Show("No Data Found");                 
                }
        }
        private void Exit()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        /// <summary>
        /// Function for list the Schema fields in the list box
        /// </summary>
        /// <param name="schemaFileName"></param>
        /// <returns></returns>
        public XmlNodeList DisplaySchemaFields(string schemaFileName)
        {
            try
            {
                if (schemaFileName.Trim().Length > 0)
                {
                    XmlDocument schemaDoc = new XmlDocument();
                    schemaDoc.Load(schemaFileName);
                    XmlNamespaceManager nsMgr = new XmlNamespaceManager(schemaDoc.NameTable);
                    foreach (XmlAttribute attr in schemaDoc.DocumentElement.Attributes)
                    {
                        if (attr.Prefix == "xmlns")
                        {
                            nsMgr.AddNamespace(attr.LocalName, attr.Value);
                        }
                    }
                    return (schemaDoc.SelectNodes("/xsd:schema/xsd:element", nsMgr)) as XmlNodeList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message, "Error");
            }
            return null;
        }
        #endregion

        #region Generate Infopath XML
        /// <summary>
        /// Generate Infopath XML Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateDocButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLotusFile.Text.Trim() == "")
                {
                    MessageBox.Show("You have to select Lotus Database", "Lotus File");
                    return;
                }
                if (txtSchemaFile.Text.Trim() == "")
                {
                    MessageBox.Show("You have to select Schema File", "Schema File");
                    return;
                }
                if (mappedFieldsView.Rows.Count <= 0)
                {
                    MessageBox.Show("You have to map at least one field", "Error");
                    return;
                }
                else if (txtTargetFolder.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select the target folder", "Select Target Folder");
                    return;
                }

                FileInfo fileInfo = new FileInfo(txtLotusFile.Text.Trim());
                string fileName = fileInfo.Name.ToString();

                XmlDocument xDocLoad = GenerateLotusXML();
                CreateDocinDocNode(xDocLoad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Upload to Sharepoint
        /// <summary>
        /// Sharepoint Upload button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadToSharePoint_Click(object sender, EventArgs e)
        {
            if  (txtTargetFolder.Text.Trim() == "")
            {
                MessageBox.Show("You should provide Target Folder", "Select target folder");
                return;
            }
            try
            {
                UploadToSharePoint uploadSP = new UploadToSharePoint();
                uploadSP.TargetFolder = txtTargetFolder.Text.Trim();
                uploadSP.InputDataFile = txtLotusFile.Text.Trim();
                uploadSP.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }
        #endregion

        #region Save Job Details
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveJob_Click(object sender, EventArgs e)
        {
            XmlTextWriter jobWriter = null;
            try
            {
                saveXMLFileDialog.AddExtension = true;
                saveXMLFileDialog.DefaultExt = "*.xml";
                saveXMLFileDialog.Filter = "Job Files|*.xml";
                saveXMLFileDialog.ShowDialog();
                if (saveXMLFileDialog.FileName.Length > 0)
                {
                    jobWriter = new XmlTextWriter(saveXMLFileDialog.FileName, Encoding.UTF8);
                    jobWriter.Formatting = Formatting.Indented;
                    jobWriter.WriteStartDocument(true);
                    jobWriter.WriteStartElement("MigrationJob");
                    //Writing "File Section" to job file
                    jobWriter.WriteStartElement("InputFilesConfigruation");
                    jobWriter.WriteElementString("LotusInputFile", txtLotusFile.Text.Trim());
                    jobWriter.WriteElementString("SchemaInputFile", txtSchemaFile.Text.Trim());                                                            
                    jobWriter.WriteEndElement();

                    jobWriter.WriteStartElement("FormsList");
                    jobWriter.WriteElementString("FormName", cbxListForm.Text.Trim());     
                    
                    //Writing "Fields Mapping" to job file
                    
                    jobWriter.WriteStartElement("NotesFields");
                    for (int index = 0; index < lbxNSFFields.Items.Count; index++)
                    {
                        jobWriter.WriteElementString("NotesField", lbxNSFFields.Items[index].ToString());
                    }
                    jobWriter.WriteEndElement();

                    jobWriter.WriteStartElement("SchemaFields");

                    for (int index = 0; index < lbxSchemaFields.Items.Count; index++)
                    {
                        jobWriter.WriteStartElement("SchemaField");
                        jobWriter.WriteAttributeString("name", lbxSchemaFields.Items[index].ToString());
                        jobWriter.WriteAttributeString("type", lbxSchemaDataTypes.Items[index].ToString());
                        jobWriter.WriteEndElement();
                    }
                    jobWriter.WriteEndElement();

                    //Writing "Mapping Fields" to job file
                    jobWriter.WriteStartElement("MappingConfiguration");
                    
                    //jobWriter.WriteStartElement("FileNameConfiguration");
                    jobWriter.WriteEndElement();


                    jobWriter.WriteStartElement("InfoPathTargetDefinition");
                    jobWriter.WriteElementString("TargetFolderPath", txtTargetFolder.Text.Trim());
                    jobWriter.WriteElementString("TemplateXMLFile", txtTempFile.Text.Trim());
                    jobWriter.WriteEndElement();
                    jobWriter.WriteStartElement("MappingFields");
                    for (int i = 0; i < mappedFieldsView.Rows.Count - 1; i++)
                    {
                        jobWriter.WriteStartElement("Mapping");
                        jobWriter.WriteAttributeString("SourceValue", (mappedFieldsView.Rows[i].Cells[0].Value == null) ? "" : mappedFieldsView.Rows[i].Cells[0].Value.ToString());
                        jobWriter.WriteAttributeString("Destination", (mappedFieldsView.Rows[i].Cells[1].Value == null) ? "" : mappedFieldsView.Rows[i].Cells[1].Value.ToString());
                        jobWriter.WriteAttributeString("DestinationType", (mappedFieldsView.Rows[i].Cells[2].Value == null) ? "" : mappedFieldsView.Rows[i].Cells[2].Value.ToString());
                        jobWriter.WriteEndElement();
                    }
                   
                   //End MigrationJob

                    MessageBox.Show("Job successfully created.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating job. Please try again.", "Save Job Error" + ex.Message);
                return;
            }
            finally
            {
                if (jobWriter != null)
                {
                    jobWriter.Close();
                }
            }
        }
        #endregion Save job details

        #region Load Job Details
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadJob_Click(object sender, EventArgs e)
        {
            string strLoadJobName = "";
            DataSet dsJobDetails = new DataSet("jobdetails");

            fileOpenDialog.FileName = "";
            fileOpenDialog.DefaultExt = "Xml Files(*.xml)";
            fileOpenDialog.Filter = "XML Files(*.xml)|*.xml";
            fileOpenDialog.ShowDialog();
            strLoadJobName = fileOpenDialog.FileName;
            if (strLoadJobName.Trim().Length <= 0)
            {
                return;
            }
            dsJobDetails.ReadXml(strLoadJobName);

            ResetControls();
            txtLotusFile.Text = dsJobDetails.Tables["InputFilesConfigruation"].Rows[0]["LotusInputFile"].ToString();
            txtSchemaFile.Text = dsJobDetails.Tables["InputFilesConfigruation"].Rows[0]["SchemaInputFile"].ToString();

            cbxListForm.Items.Add(dsJobDetails.Tables["FormsList"].Rows[0]["FormName"].ToString());       

            cbxListForm.SelectedText=dsJobDetails.Tables["FormsList"].Rows[0]["FormName"].ToString();         
            //Populate XML fields
            foreach (DataRow row in dsJobDetails.Tables["NotesField"].Rows)
            {
                lbxNSFFields.Items.Add(row[0].ToString());
            }

            //Populate schema fields and data types
            foreach (DataRow row in dsJobDetails.Tables["SchemaField"].Rows)
            {
                lbxSchemaFields.Items.Add(row[0].ToString());
                lbxSchemaDataTypes.Items.Add(row[1].ToString());
            }

            //Populating InfoPath Target Definition Section
            txtTargetFolder.Text = dsJobDetails.Tables["InfoPathTargetDefinition"].Rows[0]["TargetFolderPath"].ToString();
            txtTempFile.Text = dsJobDetails.Tables["InfoPathTargetDefinition"].Rows[0]["TemplateXMLFile"].ToString();          
            
            //Populate mapping grid view
            DataTable dtMapped = dsJobDetails.Tables["Mapping"];
            int rowCount = 0;
            foreach (DataRow dr in dtMapped.Rows)
            {
                mappedFieldsView.Rows.Add();
                mappedFieldsView.Rows[rowCount].Cells[0].Value = dr[0].ToString();
                mappedFieldsView.Rows[rowCount].Cells[1].Value = dr[1].ToString();
                mappedFieldsView.Rows[rowCount].Cells[2].Value = dr[2].ToString();
                rowCount++;
            }
            //findItemStrip.Enabled = false;
            //unMapItemStrip.Enabled = false;  
            MessageBox.Show("Job loaded Successfully");  
        }
        #endregion Load Job Details

        #region ResetControls
        /// <summary>
        /// This private method is used to Reset controls value.
        /// </summary>
        private void ResetControls()
        {
            txtLotusFile.Text = "";
            txtSchemaFile.Text = "";
            txtTargetFolder.Text = "";
            txtTempFile.Text = "";
            cbxListForm.Text = "";
            cbxListForm.DataSource = null;   
            cbxListForm.Items.Clear();
            
            lbxNSFFields.DataSource = null;
            lbxSchemaFields.DataSource = null;
            lbxSchemaDataTypes.DataSource = null;
            lbxNSFFields.Items.Clear();
            lbxSchemaFields.Items.Clear();
            lbxSchemaDataTypes.Items.Clear();

            if (mappedFieldsView.DataSource != null)
            {
                mappedFieldsView.DataSource = null;
            }
            mappedFieldsView.Rows.Clear();

            //findItemStrip.Enabled = false;
            //unMapItemStrip.Enabled = false;
            if (mappedFieldsView.Columns.Count == 0)
            {
                mappedFieldsView.Columns.Add("XMLFields", "XML Fields");
                mappedFieldsView.Columns.Add("SchemaFields", "Schema Fields");
                mappedFieldsView.Columns.Add("DataType", "DataType");                
            }           
        }
        #endregion      
       
    }        
}