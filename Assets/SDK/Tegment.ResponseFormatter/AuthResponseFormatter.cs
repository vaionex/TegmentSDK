using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AuthResponseFormatter
    {
        public int statusCode;
        public AuthResponseData data;
    }
    [Serializable]
    public class AuthResponseData
    {
        public string status;
        public string msg;
        public string token;
    }
}
