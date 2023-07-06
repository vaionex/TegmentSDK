using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class RedeemRequestFormatter
    {
        public RedeemRequestDataArray[] dataArray;
    }
    [Serializable]
    public class RedeemRequestDataArray
    {
        public double amount;
        public string tokenId;
        public int sn;
    }
}
