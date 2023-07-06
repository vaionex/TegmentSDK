using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class SwapRequestFormatter
    {
        public SwapRequestDataArray[] dataArray;
    }
    [Serializable]
    public class SwapRequestDataArray
    {
        public string swapHex;
    }
}