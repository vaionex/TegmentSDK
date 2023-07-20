using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class MetricsResponseFormatter 
    {
        public int statusCode;
        public MetricsResponseData data;
    }
    [Serializable]
    public class MetricsResponseData
    {
        public string status;
        public string msg;
        public MetricsResponseData_data data;
    }
    [Serializable]
    public class MetricsResponseData_data
    {
        public int balance;
        public MetricsResponseData_UserUtxos[] userUtxos;
    }
    [Serializable]
    public class MetricsResponseData_UserUtxos
    {
        public string userId;
        public string walletId;
        public string script;
        public int tx_pos;
        public string address;
        public string path;
        public string tx_hash;
        public int value;
    }
}