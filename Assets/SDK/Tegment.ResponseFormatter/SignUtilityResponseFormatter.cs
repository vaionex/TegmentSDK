using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class SignUtilityResponseFormatter 
    {
        public int statusCode;
        public SignUtilityResponseData data;
    }
    [Serializable]
    public class SignUtilityResponseData
    {
        public string status;
        public string msg;
        public SignUtilityData[] data;
    }
    [Serializable]
    public class SignUtilityData
    {
        public string derivationPath;
        public string address;
        public string signature;
    }
}
