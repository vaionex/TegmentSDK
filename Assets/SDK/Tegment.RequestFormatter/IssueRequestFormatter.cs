using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class IssueRequestFormatter
    {
        public string name;
        public string protocolId;
        public string symbol;
        public string description;
        public string image;
        public int tokenSupply;
        public int decimals;
        public int satsPerToken;
        public IssueRequestProperties properties;
        public bool splitable;
        public object data;
    }
    [Serializable]
    public class IssueRequestProperties
    {
        public IssueRequestProperties_Legal legal;
        public IssueRequestProperties_Issuer issuer;
        public IssueRequestProperties_Meta meta;
    }
    [Serializable]
    public class IssueRequestProperties_Legal
    {
        public string terms;
        public string licenceId;
    }
    [Serializable]
    public class IssueRequestProperties_Issuer
    {
        public string organisation;
        public string legalForm;
        public string governingLaw;
        public string issuerCountry;
        public string jurisdiction;
        public string email;
    }
    [Serializable]
    public class IssueRequestProperties_Meta
    {
        public string schemaId;
        public string website;
        public IssueRequestProperties_Meta_Legal legal;
        public IssueRequestProperties_Media[] media;
    }
    [Serializable]
    public class IssueRequestProperties_Meta_Legal
    {
        public string terms;
    }
    [Serializable]
    public class IssueRequestProperties_Media
    {
        public string URI;
        public string type;
        public string altURI;
    }
}