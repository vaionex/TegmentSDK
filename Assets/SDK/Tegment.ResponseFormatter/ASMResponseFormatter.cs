using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class ASMResponseFormatter
    {
        public int statusCode;
        public ASMResponseData data;
    }
    public class ASMResponseData
    {
        public string status;
        public string msg;
        public string txid;
    }
}
