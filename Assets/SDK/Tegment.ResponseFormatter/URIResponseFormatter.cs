using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class URIResponseFormatter
    {
        public int statusCode;
        public URIResponseData data;
    }
    [Serializable]
    public class URIResponseData
    {
        public string status;
        public string msg;
        public URIData data;
    }
    [Serializable]
    public class URIData
    {
        public string uri;
        public string type;
        public string mainProtocol;
        public URIDataOutput[] outputs;
        public URIDataInput[] inputs;
        public string memo;
        public bool isBSV;
        public string peer;
        public string peerData;
        public string peerProtocol;
    }

    [Serializable]
    public class URIDataOutput
    {
        public string script;
        public int satoshis;
    }

    [Serializable]
    public class URIDataInput
    {
        public string script;
        public int satoshis;
    }
}
