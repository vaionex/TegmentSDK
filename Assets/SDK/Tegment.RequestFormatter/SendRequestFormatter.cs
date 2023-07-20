using System;


namespace Tegment.RequestFormatter
{
    [Serializable]
    public class SendRequestFormatter
    {
        public bool bundle;
        public SendRequestDataArray[] dataArray;
    }
    [Serializable]
    public class SendRequestDataArray
    {
        public string to;
        public double amount;
        public string tokenId;
        public int sn;
    }
}