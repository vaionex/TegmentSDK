using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class InitBetaResponseFormatter
    {
        public int statusCode;
        public InitBetaResponseFormatterData data;
    }

    [Serializable]
    public class InitBetaResponseFormatterData
    {
        public string status;
        public string msg;
    }

}