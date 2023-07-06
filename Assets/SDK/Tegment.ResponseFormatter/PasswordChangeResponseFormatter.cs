using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PasswordChangeResponseFormatter
    {
        public int statusCode;
        public PasswordChangeResponseData data;
    }
    [Serializable]
    public class PasswordChangeResponseData
    {
        public string status;
        public string msg;
        public string email;
    }
}