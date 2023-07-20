using System;
//Response checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class InspectResponseFormatter
    {
        public int statusCode;
        public InspectResponseData data;
    }
    [Serializable]
    public class InspectResponseData
    {
        public string status;
        public string msg;
        public InspectOfferDetails[] offerDetails;
    }

    [Serializable]
    public class InspectOfferDetails
    {
        public string tokenOwnerAddress;
        public string tokenCreatorAddress;
        public int tokenSatoshis;
        public int wantedSatoshis;
        public string tokenImage;
        public int serialNumber;
        public bool splittbale;
        public string contractTxid;
        public string tokenId;
        public string symbol;
        public int tokenSupply;
        public bool verified;
        public string tokenName;
        public string tokenDescription;
    }
}