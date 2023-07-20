using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class MnemonicResponseFormatter
    {
        public int statusCode;
        public MnemonicResponseData data;
    }
    [Serializable]
    public class MnemonicResponseData { 
        public string status;
        public string msg;
        public string mnemonic;
    }
}