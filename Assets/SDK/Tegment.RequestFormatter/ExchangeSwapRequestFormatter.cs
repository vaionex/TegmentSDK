using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class ExchangeSwapRequestFormatter
    {
        public ExchangeSwapRequestDataArray[] dataArray;
    }
    [Serializable]
    public class ExchangeSwapRequestDataArray
    {
        public string swapId;
    }
}
