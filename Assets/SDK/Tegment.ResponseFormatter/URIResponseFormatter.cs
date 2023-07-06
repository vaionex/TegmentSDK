using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class URIResponseFormatter
    {
        public int statusCode;
        public URIResponseData data;
    }
    [Serializable]
    public class URIResponseData
    {
        public string status;
        public string msg;
    }
}