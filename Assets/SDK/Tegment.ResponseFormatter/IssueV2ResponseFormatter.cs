using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class IssueV2ResponseFormatter
    {
        public int statusCode;
        public IssueV2ResponseData data;
    }
    [Serializable]
    public class IssueV2ResponseData
    {
        public string status;
        public string msg;

        public string tokenId;
        public IssueV2TokenData tokenObj;
    }

    [Serializable]
    public class IssueV2TokenData
    {
        public string userId;
        public string symbol;


        public string name;
        public string description;
        public string image;
        public int totalSupply;
        public int decimals;
        public int satsPerToken;

        public IssueV2ResponseProperties properties;
        public bool splittable;
        public string protocolId;
        public string contractTxid;
        public string issueTxid;
        public string contractAddress;
        public string contractPublickey;
        public bool splitable;
    }
    [Serializable]
    public class IssueV2ResponseProperties
    {
        public IssueV2ResponseProperties_Legal legal;
        public IssueV2ResponseProperties_issuer issuer;
        public IssueV2ResponseProperties_Meta meta;
    }
    [Serializable]
    public class IssueV2ResponseProperties_Legal
    {
        public string terms;
        public string licenceId;
    }

    [Serializable]
    public class IssueV2ResponseProperties_issuer
    {
        public string organisation;
        public string legalForm;
        public string governingLaw;
        public string issuerCountry;
        public string jurisdiction;
        public string email;
    }

    [Serializable]
    public class IssueV2ResponseProperties_Meta
    {
        public string schemaId;
        public string website;
        public IssueV2ResponseProperties_Meta_Legal legal;
        public IssueV2ResponseProperties_Meta_media[] media;
    }

    [Serializable]
    public class IssueV2ResponseProperties_Meta_Legal
    {
        public string terms;
    }
    [Serializable]
    public class IssueV2ResponseProperties_Meta_media
    {
        public string URI;
        public string type;
        public string altURI;
    }
}