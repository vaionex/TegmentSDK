using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PaymentRequestPayResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class PaymentRequestPayResponseData
    {
        public string status;
        public string msg;
    }
}
