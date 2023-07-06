using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class UploadUtilityResponseFormatter
    {
        public int statusCode;
        public UploadUtilityResponseData data;
    }
    [Serializable]
    public class UploadUtilityResponseData
    {
        public string status;
        public string msg;
        public UploadUtilityResponseData_Upload uploadObj;
    }
    [Serializable]
    public class UploadUtilityResponseData_Upload
    {
        public string fileName;
        public string fileType;
        public string fileSize;
        public string timeStamp;
        public string txid;
        public string address;
        public string addressPath;
        public string url;
    }
}