using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PostUploadResponseFormatter 
    {
        public int statusCode;
        public PostUploadResponseData data;
    }
    [Serializable]
    public class PostUploadResponseData
    {
        public string status;
        public string msg;
        public PostUploadResponse_TxIDs[] txIds;
        public string[] errors;
    }
    [Serializable]
    public class PostUploadResponse_TxIDs
    {
        public string txId;
        public string url;
    }
}