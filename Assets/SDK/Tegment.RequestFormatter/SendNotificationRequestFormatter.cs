using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class SendNotificationRequestFormatter
    {
        public string type;
        public string userAddress;
        public double amount;
        public string transactionType;
    }
}
