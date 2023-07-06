using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class DropRequestFormatter
    {
        public DropRequestDataArray[] dataArray;
    }
    [Serializable]
    public class DropRequestDataArray
    {
        public string to;
        public double amount;
        public string notes;
        public string tokenId;
        public int sn;
    }
}