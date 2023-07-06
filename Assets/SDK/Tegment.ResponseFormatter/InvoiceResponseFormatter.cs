using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class InvoiceResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class InvoiceResponseData
    {
        public string status;
        public string msg;
        public string reqUrl;
    }
}
