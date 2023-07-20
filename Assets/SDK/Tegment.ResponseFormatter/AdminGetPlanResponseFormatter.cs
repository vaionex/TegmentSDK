using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AdminGetPlanResponseFormatter
    {
        public int statusCode;
        public AdminGetPlanResponseFormatterData data;
    }
    [Serializable]
    public class AdminGetPlanResponseFormatterData
    {
        public string status;
        public string msg;
    }
}