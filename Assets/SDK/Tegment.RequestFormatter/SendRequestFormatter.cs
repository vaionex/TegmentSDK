using System;


namespace Tegment.RequestFormatter
{
    [Serializable]
    public class SendRequestFormatter
    {
        public SendRequestDataArray[] dataArray;
    }
    [Serializable]
    public class SendRequestDataArray
    {
        public string to;
        public double amount;
    }
}