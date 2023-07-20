using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class TokenV1_ResponseFormatter
    {
        public int statusCode;
        public TokenV1_ResponseData data;
    }
    [Serializable]
    public class TokenV1_ResponseData
    {
        public string status;
        public string msg;
        public string token_id;
  
        public string symbol;
        public string name;
        public string description;
        public string image;
        public int total_supply;
        public int sats_per_token;
        public bool splitable;

        public TokenV1ResponseProperties properties;
        public string[] contract_txs;
        public string[] issuance_txs;
    }
    [Serializable]
    public class TokenV1ResponseProperties
    {
        public TokenV1ResponseProperties_Legal legal;
        public TokenV1ResponseProperties_issuer issuer;
        public TokenV1ResponseProperties_Meta meta;
    }
    [Serializable]
    public class TokenV1ResponseProperties_Legal
    {
        public string terms;
        public string licenceId;
    }

    [Serializable]
    public class TokenV1ResponseProperties_issuer
    {
        public string organisation;
        public string legal_form;
        public string governing_law;
        public string issuer_country;
        public string jurisdiction;
        public string email;
    }

    [Serializable]
    public class TokenV1ResponseProperties_Meta
    {
        public string schemaId;
        public string website;
        public TokenV1ResponseProperties_Meta_Legal legal;
        public TokenV1ResponseProperties_Meta_media[] media;
    }

    [Serializable]
    public class TokenV1ResponseProperties_Meta_Legal
    {
        public string terms;
    }
    [Serializable]
    public class TokenV1ResponseProperties_Meta_media
    {
        public string URI;
        public string type;
        public string altURI;
    }
}

