using System;

namespace Tegment.ResponseFormatter {
    [Serializable]
    public class BalanceResponseFormatter
    {
        public int statusCode;
        public BalanceResponseData data;
    }
    [Serializable]
    public class BalanceResponseData { 
        public string status;
        public string msg;
        public TotalBalanceData totalBalance;
        public coinsData[] coins;
        public metaData meta;
    }
    [Serializable]
    public class TotalBalanceData
    {
        public string currency;
        public double balance;
    }
    [Serializable]
    public class coinsData
    {
        public string Id;
        public string protocol;
        public string tokenId;
        public bool splittable;
        public bool splitable;
        public bool verified;
        public string name;
        public string address;
        public int satsPerToken;
        public string symbol;
        public string redeemAddr;
        public string image;
        public int amount;
        public int supply;
        public int decimals;
        public int[] sn;
        public int balance;
    }
    [Serializable]
    public class metaData
    {
        public string nextPageToken;
    }
}
