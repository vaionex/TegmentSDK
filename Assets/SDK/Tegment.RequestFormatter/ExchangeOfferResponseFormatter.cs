using System;
//Response  Checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class ExchangeOfferResponseFormatter
    {
        public int statusCode;
        public ExchangeOfferResponseData data;
    }
    [Serializable]
    public class ExchangeOfferResponseData
    {
        public string status;
        public string msg;
        public ExchangeOfferContent[] contents;
    }
    [Serializable]
    public class ExchangeOfferContent
    {
        public string swapId;
        public string swapOfferHex;
        public int tokenSatoshis;
        public string tokenContractTxid;
        public string payment;
        public string prevTxid;
        public string tokenId;
        public string tokenOwnerAddress;
        public int totalOutputSatoshis;
        public string makerPublicKeyHash;
    }
}