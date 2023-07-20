using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class GenerateTokenResponseFormatter 
    {
        public int statusCode;
        public GenerateTokenResponseFormatterData data;
    }
    [Serializable]
    public class GenerateTokenResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
