using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class AddressResponseFormatter
    {
        public int statusCode;
        public AddressResponseData data;
    }
    [Serializable]
    public class AddressResponseData
    {
        public string status;
        public string msg;
        public string address;
        public string paymail;
    }
}