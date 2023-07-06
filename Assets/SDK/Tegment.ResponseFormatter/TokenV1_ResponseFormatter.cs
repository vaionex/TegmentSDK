using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class TokenV1_ResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class TokenV1_ResponseData
    {
        public string status;
        public string msg;
    }
}
