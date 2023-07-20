using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class SendNotificationsResponseFormatter 
    {
        public int statusCode;
        public SendNotificationsResponseFormatterData data;
    }
    [Serializable]
    public class SendNotificationsResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
