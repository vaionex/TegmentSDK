using System;

namespace Tegment.ResponseFormatter
{

    public class TokenV2_ResponseFormatter
    {
        public int statusCode;
        public TokenV2_ResponseData data;
    }
    public class TokenV2_ResponseData
    {
        public string status;
        public string msg;

        public string[] contractTxs;
        public string[] issuanceTxs;
        public int utxos;
        public int owners;
        public int transactionsCount;
        public int circulationSupply;

        public string name;
        public string tokenId;

        public string symbol;
        public string description;
        public string image;
        public int totalSupply;
        public int decimals;
        public int satsPerToken;


        public TokenV2ResponseProperties properties;
        public bool splitable;
        public string protocol;
        public int serialNumber;
        public string[] data;

    }
    [Serializable]
    public class TokenV2ResponseProperties
    {
        public TokenV2ResponseProperties_Legal legal;
        public TokenV2ResponseProperties_issuer issuer;
        public TokenV2ResponseProperties_Meta meta;
    }
    [Serializable]
    public class TokenV2ResponseProperties_Legal
    {
        public string terms;
        public string licenceId;
    }

    [Serializable]
    public class TokenV2ResponseProperties_issuer
    {
        public string organisation;
        public string legalForm;
        public string governingLaw;
        public string issuerCountry;
        public string jurisdiction;
        public string email;
    }

    [Serializable]
    public class TokenV2ResponseProperties_Meta
    {
        public string schemaId;
        public string website;
        public TokenV2ResponseProperties_Meta_Legal legal;
        public TokenV2ResponseProperties_Meta_media[] media;
    }

    [Serializable]
    public class TokenV2ResponseProperties_Meta_Legal
    {
        public string terms;
    }
    [Serializable]
    public class TokenV2ResponseProperties_Meta_media
    {
        public string URI;
        public string type;
        public string altURI;
    }
}