using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class PutSetupResponseFormatter
    {
        public int statusCode;
        public PutSetupResponseFormatterData data;
    }
    [Serializable]
    public class PutSetupResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
