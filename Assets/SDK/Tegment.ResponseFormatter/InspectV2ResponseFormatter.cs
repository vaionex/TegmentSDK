using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class InspectV2ResponseFormatter
    {
        public int statusCode;
        public InspectV2ResponseFormatterData data;
    }
    [Serializable]
    public class InspectV2ResponseFormatterData
    {
        public string status;
        public string msg;
        public InspectV2OfferDeatils[] offerDetails;
    }
    [Serializable]
    public class InspectV2OfferDeatils
    {
        public string address;
        public string protocol;
        public int amount;
        public bool verified;
        public bool spent;
        public string tokenId;
        public string image;
        public string tokenSymbol;
        public string contractTxid;
        public string name;
        public int tokenSupply;
        public string redeemAddress;
        public bool splittable;
        public int satsPerToken;
        public string wantedProtocol;
        public int wantedAmount;
    }
}