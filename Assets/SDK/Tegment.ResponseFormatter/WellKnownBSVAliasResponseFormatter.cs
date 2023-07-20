using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class WellKnownBSVAliasResponseFormatter 
    {
        public string bsvalias;
        public WellKnownBSVAliasResponseFormatterCapabilities capabilities;
    }
    [Serializable]
    public class WellKnownBSVAliasResponseFormatterCapabilities
    {
        public string pki;
        public string paymentDestination;

    }
}