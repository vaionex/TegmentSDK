using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class SignUtilityResponseFormatter 
    {
        public int statusCode;
        public SignUtilityResponseData[] data;
    }
    [Serializable]
    public class SignUtilityResponseData
    {
        public string derivationPath;
        public string address;
        public string signature;
    }
}

