using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PaymailGetResponseFormatter
    {
        public int statusCode;
        public PaymailGetResponseFormatterData data;
    }

    [Serializable]
    public class PaymailGetResponseFormatterData
    {
        public string status;
        public string msg;
        public PaymailGetResponseFormatterPaymailDetails paymailDetails;
    }

    [Serializable]
    public class PaymailGetResponseFormatterPaymailDetails
    {
        public string walletID;
        public string paymailId;
    }
}