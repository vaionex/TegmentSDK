using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PaymentRequestResponseFormatter
    {
        public int statuscode;
        public string status;
        public string msg;
        public string mainProtocol;
        public string merchantData;
        public int expirationTimestamp;
        public string memo;
        public PaymentRequestResponseOutputs[] outputs;
        public string version;
        public string uri;
        public int creationTimestamp;
        public string type;
        public string network;
        public string paymentUrl;
    }
    [Serializable]
    public class PaymentRequestResponseOutputs
    {
        public string description;
        public string script;
        public int satoshis;
    }
}

