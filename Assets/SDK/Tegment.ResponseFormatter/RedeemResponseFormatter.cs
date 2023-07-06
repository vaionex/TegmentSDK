using System;


namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class RedeemResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class RedeemResponseData
    {
        public string status;
        public string msg;
    }
}