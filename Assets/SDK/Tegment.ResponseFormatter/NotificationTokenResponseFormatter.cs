using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class NotificationTokenResponseFormatter
    {
        public int statusCode;
        public NotificationTokenResponseFormatterData data;
    }

    [Serializable]
    public class NotificationTokenResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
