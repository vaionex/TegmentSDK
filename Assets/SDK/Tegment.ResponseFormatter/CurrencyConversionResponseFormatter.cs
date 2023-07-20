using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class CurrencyConversionResponseFormatter
    {
        public int statusCode;
        public CurrencyConversionResponseData data;
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