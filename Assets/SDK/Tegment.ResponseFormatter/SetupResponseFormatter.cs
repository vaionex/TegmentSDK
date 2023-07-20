using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class SetupResponseFormatter
    {
        public int statusCode;
        public SetupResponseFormatterData data;
    }
    [Serializable]
    public class SetupResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
