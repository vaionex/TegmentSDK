using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class FeeMetricsBetaResponseFormatter
    {
        public int statusCode;
        public FeeMetricsBetaResponseFormatterData data;
    }

    [Serializable]
    public class FeeMetricsBetaResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
