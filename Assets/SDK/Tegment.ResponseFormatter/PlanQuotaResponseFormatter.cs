using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PlanQuotaResponseFormatter
    {
        public int statusCode;
        public PlanQuotaResponseFormatterData data;
    }
    [Serializable]
    public class PlanQuotaResponseFormatterData
    {
        public string status;
        public string msg;
    }

}
