using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class InspectResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class InspectResponseData
    {
        public string status;
        public string msg;
    }
}