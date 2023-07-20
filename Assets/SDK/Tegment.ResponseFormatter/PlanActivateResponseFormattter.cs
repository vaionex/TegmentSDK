using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PlanActivateResponseFormattter
    {
        public string statusCode;
        public PlanActivateResponseFormattterData data;

    }
    [Serializable]
    public class PlanActivateResponseFormattterData
    {
        public string status;
        public string msg;
    }
}
