using System;

namespace Tegment.ResponseFormatter
{
    public class CompileResponseFormatter
    {
        public int statusCode;
        public CompileResponseFormatterData data;
    }
    [Serializable]
    public class CompileResponseFormatterData
    {
        public string status;
        public string msg;
        public string scrypt;
    }
}