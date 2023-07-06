using System;
namespace Tegment.RequestFormatter
{
    [Serializable]
    public class RawTXRequestFormatter
    {
        public RawTXRequestDataArray[] dataArray;
    }
    [Serializable]
    public class RawTXRequestDataArray
    {
        public string to;
        public double amount;
    }
}
