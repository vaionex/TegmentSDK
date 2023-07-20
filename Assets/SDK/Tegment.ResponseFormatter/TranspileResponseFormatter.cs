using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class TranspileResponseFormatter 
    {
        public int statusCode;
        public TranspileResponseData data;
    }
    [Serializable]
    public class TranspileResponseData
    {
        public string status;
        public string msg;
        public string scrypt;
        public string[] errorLogs;
    }
}