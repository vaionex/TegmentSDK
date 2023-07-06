using System;

namespace Tegment.RequestFormatter
{
    public class ExchangeOfferRequestFormatter
    {
        public ExchangeOfferRequestDataArray[] dataArray;
    }
    [Serializable]
    public class ExchangeOfferRequestDataArray
    {
        public string tokenId;
        public int sn;
        public double amount;
        public string type;
        public ExchangeOfferRequestPayment[] payment;
    }
    public class ExchangeOfferRequestPayment
    {
        public string to;
        public double amount;
    }
}
