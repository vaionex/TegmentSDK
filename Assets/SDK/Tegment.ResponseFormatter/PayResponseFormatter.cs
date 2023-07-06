using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PayResponseFormatter
    {
        public int statucCode;
    }
    [Serializable]
    public class PayResponseData
    {
        public string status;
        public string msg;
    }
}