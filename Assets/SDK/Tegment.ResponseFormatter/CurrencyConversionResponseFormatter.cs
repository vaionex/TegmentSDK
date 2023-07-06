using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class CurrencyConversionResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class CurrencyConversionResponseData
    {
        public string status;
        public string msg;
        public string currency;
        public double balance;
    }
}
