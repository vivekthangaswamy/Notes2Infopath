using System;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using Microsoft.SharePoint;

namespace Tool
{
    public class FileSplitUtility
    {
        public static int maxFolderIndex;
        public static string highestFolderName;
        public static string siteUrl;
        
        public static SPFolder GetHighestFolder(SPWeb currentWeb, string targetLibraryName, string archiveFolderPrefix, ref int maxNumber)
        {
            try
            {
                SPListCollection webLists = currentWeb.Lists;
                webLists.IncludeRootFolder = true;

                SPList targetList = currentWeb.Lists[targetLibraryName];

                if (targetList.RootFolder.SubFolders.Count <= 1)
                {
                    targetList.RootFolder.SubFolders.Add(archiveFolderPrefix + "1");
                    ++maxNumber;
                    maxFolderIndex = maxNumber;
                    highestFolderName = targetList.RootFolder.SubFolders[archiveFolderPrefix + maxNumber].Name;
                    
                    return targetList.RootFolder.SubFolders[archiveFolderPrefix + maxNumber.ToString()];
                }
                
                SPFolderCollection folders = targetList.RootFolder.SubFolders;
                //SPFolder rootFolder = targetList.RootFolder;
                //SPFolderCollection folders = rootFolder.SubFolders.Folder.SubFolders;
                //MessageBox.Show(folders.Folder.SubFolders);
                //if (folders.Count == 0)
                //{
                //    targetList.RootFolder.SubFolders.Add(archiveFolderPrefix + "1");
                //    MessageBox.Show(folders[0].Name);
                //    return folders[0];
                //}
                ArrayList folderIndex = new ArrayList();

                foreach (SPFolder folder in folders)
                {
                    if (folder.Name.StartsWith(archiveFolderPrefix))
                    {
                        folderIndex.Add(int.Parse(folder.Name.Substring(archiveFolderPrefix.Length)));
                    }
                }
                maxNumber = GetMaxNumber(folderIndex);
                maxFolderIndex = maxNumber;
                highestFolderName = folders[archiveFolderPrefix + maxNumber.ToString()].Name;
                return folders[archiveFolderPrefix + maxNumber.ToString()];
                
            }
            catch (Exception ex )
            {
                throw new Exception("Problem while retrieving folders from " + currentWeb.Name + ex.Message);
            }
        }

        private static int GetMaxNumber(ArrayList folderIndex)
        {
            int max = 0;
            foreach (int i in folderIndex)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        public static SPFile UploadFilesInSharePoint(FileUploadParam fileUploadParam)
        {
            int fileCount = fileUploadParam.HighestFolderFileCount;
            siteUrl = fileUploadParam.TargetList.ParentWeb.Url + "/" + fileUploadParam.TargetList.Title + "/" + highestFolderName + "/" + fileUploadParam.CurrentFileName;
            try
            {
                if (fileCount >= fileUploadParam.AllowedFileLimit)
                {
                    CreateFolder(fileUploadParam);
                }
                else
                {
                    AddFilesToSP(fileUploadParam.SiteUrl, fileUploadParam.TargetList, highestFolderName, fileUploadParam.FileContent, fileUploadParam.CreatedBy, fileUploadParam.ModifiedBy, fileUploadParam.CreatedDate, fileUploadParam.ModifiedDate);
                }
            }
            catch (Exception)
            {
                throw new Exception("Unable to Archive Files. Please try again.");
            }
            return null;
        }

        private static void AddFilesToSP(string strUrl, SPList targetList, string targetFolderName, byte[] fileContent, string createdBy, string modifiedBy, DateTime createdDate, DateTime modifiedDate)
        {
            try
            {
                SPUser creator = targetList.ParentWeb.Users[createdBy];
                SPUser modifier = targetList.ParentWeb.Users[modifiedBy];
                targetList.RootFolder.SubFolders[highestFolderName].Files.Add(siteUrl, fileContent, creator, modifier, createdDate, modifiedDate);
            }
            catch (SPException ex)
            {
                targetList.RootFolder.SubFolders[highestFolderName].Files.Add(siteUrl, fileContent, true);
                throw ex;
            }            
        }

        private static void CreateFolder(FileUploadParam fileUploadParam)
        {
            try
            {
                string folderName = highestFolderName.Substring(0, fileUploadParam.FolderPrefix.Length) + (++maxFolderIndex).ToString();
                fileUploadParam.TargetList.RootFolder.SubFolders.Add(folderName);
                highestFolderName = folderName;
                siteUrl = fileUploadParam.TargetList.ParentWeb.Url + "/" + fileUploadParam.TargetList.Title + "/" + folderName + "/" + fileUploadParam.CurrentFileName;
                AddFilesToSP(siteUrl, fileUploadParam.TargetList, highestFolderName, fileUploadParam.FileContent, fileUploadParam.CreatedBy, fileUploadParam.ModifiedBy, fileUploadParam.CreatedDate, fileUploadParam.ModifiedDate);
            }
            catch (Exception)
            {
                throw new Exception("Problem while creating folder in " + fileUploadParam.TargetList);
            }
        }
    }

    
}
