using System;
//Response checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class DropResponseFormatter
    {
        public int statusCode;
        public DropResponseData data;
    }
    [Serializable]
    public class DropResponseData { 
        public string status;
        public string msg;
        public string[] txIds;
        public string[] errors;
    }
}