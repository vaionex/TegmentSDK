using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class RawTxResponseFormatter
    {
        public int statusCode;
        public RawTxResponseData data;
    }
    [Serializable]
    public class RawTxResponseData { 
        public string status;
        public string msg;
    }
}
