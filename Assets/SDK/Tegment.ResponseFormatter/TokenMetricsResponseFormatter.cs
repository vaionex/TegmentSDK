using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class TokenMetricsResponseFormatter
    {
        public int statusCode;
        public TokenMetricsReponseData data;
    }
    [Serializable]
    public class TokenMetricsReponseData
    {
        public string status;
        public string msg;
    }
}