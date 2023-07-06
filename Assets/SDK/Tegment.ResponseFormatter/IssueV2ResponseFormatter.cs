using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class IssueV2ResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class IssueV2ResponseData
    {
        public string status;
        public string msg;
    }
}
