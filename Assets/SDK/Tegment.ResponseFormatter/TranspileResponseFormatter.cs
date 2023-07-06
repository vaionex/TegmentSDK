using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class TranspileResponseFormatter 
    {
        public int statusCode;
    }
    [Serializable]
    public class TranspileResponseData
    {
        public string status;
        public string msg;
    }
}