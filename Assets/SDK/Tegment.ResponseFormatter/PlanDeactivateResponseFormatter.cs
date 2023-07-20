using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PlanDeactivateResponseFormatter
    {
        public string statusCode;
        public PlanDeactivateResponseFormatterData data;
    }
    [Serializable]
    public class PlanDeactivateResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
