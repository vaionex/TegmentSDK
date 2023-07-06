using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class IssueResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class IssueResponseData
    {
        public string status;
        public string msg;
    }
}
