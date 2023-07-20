using System;
// Response Checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class CreateWalletResponseFormatter
    {
        public int statusCode;
        public CreateWalletResponseData data;
    }
    [Serializable]
    public class CreateWalletResponseData { 
        public string status;
        public string msg;
        public string walletID;
    }
}
