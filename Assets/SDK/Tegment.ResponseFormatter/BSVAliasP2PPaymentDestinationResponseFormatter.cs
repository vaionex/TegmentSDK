using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class BSVAliasP2PPaymentDestinationResponseFormatter
    {
        public BSVAliasP2PPaymentDestinationResponseFormatterOutputs[] outputs;
        public string reference;
    }
    [Serializable]
    public class BSVAliasP2PPaymentDestinationResponseFormatterOutputs
    {
        public string script;
        public int satoshis;
    }
}