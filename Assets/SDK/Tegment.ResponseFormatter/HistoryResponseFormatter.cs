using System;
// Response checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class HistoryResponseFormatter
    {
        public int statusCode;
        public HistoryResponseData data;
    }
    [Serializable]
    public class HistoryResponseData
    {
        public string status;
        public string msg;
        public HistoryData[] histories;
        public metaData meta;
    }
    [Serializable]
    public class HistoryData
    {
        public HistoryData_TO[] to;
        public string txId;
        public string from;
        public string timestamp;
        public double totalAmount;
        public string type;
    }
    [Serializable]
    public class HistoryData_TO
    {
        public double amount;
        public string image;
        public string protocol;
        public string tokenId;
        public int sn;
        public string to;
        public string name;
        public int decimals;
    }
}