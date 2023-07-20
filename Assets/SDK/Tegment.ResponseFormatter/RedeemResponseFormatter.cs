using System;


namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class RedeemResponseFormatter
    {
        public int statusCode;
        public RedeemResponseData data;
    }
    [Serializable]
    public class RedeemResponseData
    {
        public string status;
        public string msg;
        public string[] txIds;
        public string[] errors;
    }
}