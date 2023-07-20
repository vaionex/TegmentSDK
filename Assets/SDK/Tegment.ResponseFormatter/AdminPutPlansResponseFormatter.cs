using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AdminPutPlansResponseFormatter
    {
        public int statusCode;
        public AdminPutPlansResponseFormatterData data;
    }
    [Serializable]
    public class AdminPutPlansResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
