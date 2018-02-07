using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;

namespace Tool
{
    public class FileUploadParam
    {
        //sharePointFile = filcoll.Add(strUrl, byteArr, creator, modifier, dtCreatedDate, dtModifiedDate);
        string siteUrl;
        byte[] fileContent;
        string createdBy;
        string modifiedBy;
        DateTime createdDate;
        DateTime modifiedDate;
        int highestFolderFileCount;
        int allowedFileLimit;
        SPList targetList;
        string highestFolderName;
        string currentFileName;
        string folderPrefix;

        public string FolderPrefix
        {
            get { return folderPrefix; }
            set { folderPrefix = value; }
        }

        public string HighestFolderName
        {
            get { return highestFolderName; }
            set { highestFolderName = value; }
        }

        public string CurrentFileName
        {
            get { return currentFileName; }
            set { currentFileName = value; }
        }

        public int AllowedFileLimit
        {
            get { return allowedFileLimit; }
            set { allowedFileLimit = value; }
        }
        public string SiteUrl
        {
            get { return siteUrl; }
            set { siteUrl = value; }
        }

        public byte[] FileContent
        {
            get { return fileContent; }
            set { fileContent = value; }
        }
        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        public string ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }
     
        public int HighestFolderFileCount
        {
            get { return highestFolderFileCount; }
            set { highestFolderFileCount = value; }
        }
     
        public SPList TargetList
        {
            get { return targetList; }
            set { targetList = value; }
        }
    }
}
