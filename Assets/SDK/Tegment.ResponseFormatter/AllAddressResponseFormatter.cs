using System;
//Response Checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AllAddressResponseFormatter
    {
        public int statusCode;
        public AllAddressResponseData data;
    }
    [Serializable]
    public class AllAddressResponseData { 
        public string status;
        public string msg;
        public string[] addressess;
    }
}