using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class ExchangeOfferResponseFormatter
    {
        public int statusCode;
        public ExchangeOfferResponseData data;
    }
    public class ExchangeOfferResponseData
    {
        public string status;
        public string msg;
        public string swapID;
    }
}