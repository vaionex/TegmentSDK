using System;
//Response checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class ExchangeSwapResponseFormatter
    {
        public int statusCode;
        public ExchangeSwapOfferData data;
    }
    [Serializable]
    public class ExchangeSwapOfferData { 
        public string status;
        public string msg;
        public string[] txIds;
    }
}