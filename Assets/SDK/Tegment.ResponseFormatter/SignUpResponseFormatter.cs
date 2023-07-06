using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class SignUpResponseFormatter
    {
        public int statusCode;
        public SignUpResponseData data;
    }
    [Serializable]
    public class SignUpResponseData
    { 
        public string status;
        public string msg;
        public string token;
        public string userId;
    }
}