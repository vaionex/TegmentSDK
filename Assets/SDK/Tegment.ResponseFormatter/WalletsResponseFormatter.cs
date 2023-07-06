using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class WalletsResponseFormatter
    {
        public int statusCode;
        public WalletResponseData data;
    }
    [Serializable]
    public class WalletResponseData
    {
        public string status;
        public string msg;
        public WalletData[] wallets;
    }
    [Serializable]
    public class WalletData
    {
        public string walletID;
        public string walletTitle;
        public string walletLogo;
    }
}
