using System;
//Response checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class SendResponseFormatter
    {
        public int statusCode;
        public SendResponseData data;
    }
    [Serializable]
    public class SendResponseData
    {
        public string status;
        public string msg;
        public string[] txIds;
        public string[] errors;
    }
}