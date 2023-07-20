using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class FeeUTxoStateResponseFormatter
    {
        public int statusCode;
        public FeeUTxoStateResponseFormatterData data;
    }
    [Serializable]
    public class FeeUTxoStateResponseFormatterData
    {
        public string status;
        public string msg;
    }
}