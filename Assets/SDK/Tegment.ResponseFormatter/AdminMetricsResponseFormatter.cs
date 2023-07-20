using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AdminMetricsResponseFormatter 
    {
        public int statusCode;
        public AdminMetricsResponseFormatterData data;
    }
    [Serializable]
    public class AdminMetricsResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
