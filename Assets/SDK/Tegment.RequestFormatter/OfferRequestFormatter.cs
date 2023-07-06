using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class OfferRequestFormatter
    {
        public OfferRequestDataArray[] dataArray;
    }
    [Serializable]
    public class OfferRequestDataArray
    {
        public int sn;
        public string tokenId;
        public double amount;
        public double wantedAmount;
    }
}
