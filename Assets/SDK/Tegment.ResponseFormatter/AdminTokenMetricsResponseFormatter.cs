using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AdminTokenMetricsResponseFormatter 
    {
        public int statusCode;
        public AdminTokenMetricsResponseFormatterData data;
    }
    [Serializable]
    public class AdminTokenMetricsResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
