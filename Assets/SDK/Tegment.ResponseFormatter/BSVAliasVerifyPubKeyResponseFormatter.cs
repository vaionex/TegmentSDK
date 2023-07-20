using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class BSVAliasVerifyPubKeyResponseFormatter
    {
        public string bsvalias;
        public string handle;
        public string pubkey;
        public bool match;
    }
}