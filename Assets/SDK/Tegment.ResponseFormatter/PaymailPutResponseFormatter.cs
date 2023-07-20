using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PaymailPutResponseFormatter
    {
        public int statusCode;
        public PaymailPutResponseFormatterData data;
    }
    [Serializable]
    public class PaymailPutResponseFormatterData
    {
        public string status;
        public string msg;
        public string paymail;
    }
}