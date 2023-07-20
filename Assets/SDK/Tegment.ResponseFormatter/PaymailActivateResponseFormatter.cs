using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PaymailActivateResponseFormatter
    {
        public int statusCode;
        public PaymailActivateResponseFormatterData data;
    }
    [Serializable]
    public class PaymailActivateResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
