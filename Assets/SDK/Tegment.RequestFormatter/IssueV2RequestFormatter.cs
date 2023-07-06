using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class IssueV2RequestFormatter
    {
        public string name;
        public string symbol;
        public string description;
        public string image;
        public int tokenSupply;
        public int decimals;
        public int satsPerToken;
        public IssueV2RequestProperties properties;
        public object data;
    }
    [Serializable]
    public class IssueV2RequestProperties
    {
        public IssueV2RequestProperties_Legal legal;
        public IssueV2RequestProperties_Issuer issuer;
        public IssueV2RequestProperties_Meta meta;
    }
    [Serializable]
    public class IssueV2RequestProperties_Legal
    {
        public string terms;
        public string licenceId;
    }
    [Serializable]
    public class IssueV2RequestProperties_Issuer
    {
        public string organisation;
        public string legalForm;
        public string governingLaw;
        public string issuerCountry;
        public string jurisdiction;
        public string email;
    }
    [Serializable]
    public class IssueV2RequestProperties_Meta
    {
        public string schemaId;
        public string website;
        public IssueV2RequestProperties_Meta_Legal legal;
        public IssueV2RequestProperties_Media[] media;
    }
    [Serializable]
    public class IssueV2RequestProperties_Meta_Legal
    {
        public string terms;
    }
    [Serializable]
    public class IssueV2RequestProperties_Media
    {
        public string URI;
        public string type;
        public string altURI;
    }
}