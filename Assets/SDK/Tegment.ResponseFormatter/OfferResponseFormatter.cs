
using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class OfferResponseFormatter
    {
        public int statusCode;
        public OfferResponseData data;
    }
    [Serializable]
    public class OfferResponseData
    {
        public string status;
        public string msg;
    }
}