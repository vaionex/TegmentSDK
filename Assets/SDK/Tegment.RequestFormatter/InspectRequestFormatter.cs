using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class InspectRequestFormatter
    {
        public InspectRequestDataArray[] dataArray;
    }
    [Serializable]
    public class InspectRequestDataArray
    {
        public string swapHex;
    }
}
