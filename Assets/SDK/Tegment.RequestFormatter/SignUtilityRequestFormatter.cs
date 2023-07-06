using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class SignUtilityRequestFormatter
    {
        public SignUtilityRequestDataArray[] dataArray;
    }
    [Serializable]
    public class SignUtilityRequestDataArray
    {
        public string address;
        public string derivationPath;
        public string message;
    }
}
