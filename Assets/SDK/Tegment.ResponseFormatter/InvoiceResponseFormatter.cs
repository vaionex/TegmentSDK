using System;
//Response checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class InvoiceResponseFormatter
    {
        public int statusCode;
        public InvoiceResponseData data;
    }
    [Serializable]
    public class InvoiceResponseData
    {
        public string status;
        public string msg;
        public string reqUrl;
    }
}