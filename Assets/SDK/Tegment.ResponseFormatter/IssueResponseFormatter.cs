using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class IssueResponseFormatter
    {
        public int statusCode;
        public IssueResponseData data;
    }
    [Serializable]
    public class IssueResponseData
    {
        public string status;
        public string msg;
        public string tokenId;
        public IssueResponseToken tokenObj;
    }
    [Serializable]
    public class IssueResponseToken
    {
        public string userId;
        public string symbol;
        public string name;
        public string description;
        public string image;
        public int totalSupply;
        public int satsPerToken;
        public int decimals;
        public IssueResponseProperties properties;
        public bool splittable;
        public string protocolId;
        public string contractTxid;
        public string issueTxid;
        public string contractAddress;
        public string contractPublickey;
        public bool splitable;
    }
    [Serializable]
    public class IssueResponseProperties
    {
        public IssueResponseProperties_Legal legal;
        public IssueResponseProperties_issuer issuer;
        public IssueResponseProperties_Meta meta;
    }
    [Serializable]
    public class IssueResponseProperties_Legal
    {
        public string terms;
        public string licenceId;
    }

    [Serializable]
    public class IssueResponseProperties_issuer
    {
        public string organisation;
        public string legalForm;
        public string governingLaw;
        public string issuerCountry;
        public string jurisdiction;
        public string email;
    }

    [Serializable]
    public class IssueResponseProperties_Meta
    {
        public string schemaId;
        public string website;
        public IssueResponseProperties_Meta_Legal legal;
        public IssueResponseProperties_Meta_media[] media;
    }

    [Serializable]
    public class IssueResponseProperties_Meta_Legal
    {
        public string terms;
    }
    [Serializable]
    public class IssueResponseProperties_Meta_media
    {
        public string URI;
        public string type;
        public string altURI;
    }
}