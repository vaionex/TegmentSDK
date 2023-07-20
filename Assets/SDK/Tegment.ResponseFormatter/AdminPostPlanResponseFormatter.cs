using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AdminPostPlanResponseFormatter
    {
        public int statusCode;
        public AdminPostPlanResponseFormatterData data;
    }
    [Serializable]
    public class AdminPostPlanResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
