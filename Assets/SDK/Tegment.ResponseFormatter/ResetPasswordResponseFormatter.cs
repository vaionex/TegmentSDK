using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class ResetPasswordResponseFormatter
    {
        public int statusCode;
        public ResetPasswordResponseData data;
    }
    [Serializable]
    public class ResetPasswordResponseData { 
        public string status;
        public string msg;
        public string token;
        public string userId;
    }
}