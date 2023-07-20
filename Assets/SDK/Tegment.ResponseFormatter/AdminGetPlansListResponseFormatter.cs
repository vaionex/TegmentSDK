using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AdminGetPlansListResponseFormatter
    {
        public int statusCode;
        public AdminGetPlansListResponseFormatterData data;
    }
    [Serializable]
    public class AdminGetPlansListResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
