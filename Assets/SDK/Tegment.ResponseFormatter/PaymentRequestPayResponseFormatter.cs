using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PaymentRequestPayResponseFormatter
    {
        public int statusCode;
        public PaymentRequestPayResponseData data;
    }
    [Serializable]
    public class PaymentRequestPayResponseData
    {
        public string status;
        public string msg;
        public string txId;
    }
}