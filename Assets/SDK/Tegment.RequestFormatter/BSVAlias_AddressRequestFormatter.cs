using System;
namespace Tegment.RequestFormatter
{
    [Serializable]
    public class BSVAlias_AddressRequestFormatter
    {
        public string senderHandle;
        public string dt;
        public string signature;
        public double amount;
        public string purpose;
        public string senderName;
    }
}