using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class VerifyTokenResponseFormatter 
    {
        public int statusCode;
        public VerifyTokenResponseFormatterData data;
    }
    [Serializable]
    public class VerifyTokenResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
