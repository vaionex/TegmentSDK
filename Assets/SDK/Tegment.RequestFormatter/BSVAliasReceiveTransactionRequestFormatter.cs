using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class BSVAliasReceiveTransactionRequestFormatter
    {
        public string hex;
        public string reference;
        public BSVAliasReceiveTransactionRequestFormatterMetaData metadata;
    }
    [Serializable]
    public class BSVAliasReceiveTransactionRequestFormatterMetaData
    {
        public string sender;
        public string pubkey;
        public string signature;
        public string note;
    }
}