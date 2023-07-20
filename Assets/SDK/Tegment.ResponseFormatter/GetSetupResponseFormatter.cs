using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class GetSetupResponseFormatter
    {
        public string statusCode;
        public GetSetupResponseFormatterData data;
    }
    [Serializable]
    public class GetSetupResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
