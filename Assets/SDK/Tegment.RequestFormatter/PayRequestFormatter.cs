using System;
namespace Tegment.RequestFormatter
{
    [Serializable]
    public class PayRequestFormatter
    {
        public string uri;
        public string type;
        public string mainProtocol;
        public PayOutputRequest[] outputs;
        public PayInputRequest[] inputs;
        public string network;
        public string paymentUrl;
        public int creationTimeStamp;
        public int expirationTimeStamp;
        public string memo;
        public string isBSV;
        public string peer;
        public string peerData;
        public string peerProtocol;
    }
    public class PayOutputRequest
    {
        public string script;
        public int sathoshis;
    }
    public class PayInputRequest
    {
        public string txid;
        public int vout;
        public int satoshis;
        public string scriptPubKey;
        public string scriptType;
        public string scriptSig;
    }
}
