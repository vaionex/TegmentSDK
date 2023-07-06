using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PaymentRequestResponseFormatter
    {
        public int statuscode;
        public PaymentRequestResponseData data;
    }
    [Serializable]
    public class PaymentRequestResponseData
    {
        public string status;
        public string msg;
        public string merchantData;
        public string version;
        public int expirationTimestamp;
        public string network;
        public PaymentRequestResponseOutputs[] outputs;
        public int creationTimestamp;
        public string uri;
        public string mainProtocol;
        public string type;
        public string paymentUrl;
        public string memo;
    }
    [Serializable]
    public class PaymentRequestResponseOutputs
    {
        public string description;
        public string script;
        public int satoshis;
    }
}
