using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class GetSetupListResponseFormatter
    {
        public int statusCode;
        public GetSetupListResponseFormatterData data;
    }
    [Serializable]
    public class GetSetupListResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
