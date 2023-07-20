using System;
//Response Checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PayResponseFormatter
    {
        public int statucCode;
        public PayResponseData data;
    }
    [Serializable]
    public class PayResponseData
    {
        public string status;
        public string msg;
        public string txid;
    }
}