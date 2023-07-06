using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class InvoiceRequestFormatter
    {
        public string type;
        public double amount;
        public string address;
        public string description;
        public int expirationTimeInMinuts;
        public string memo;
        public string merchantData;
        public InvoiceRequestPaymentOptions[] paymentOptions;
        public string modeId;
        public InvoiceRequestBenificiary beneficiary;
    }
    [Serializable]
    public class InvoiceRequestPaymentOptions
    {
        public InvoiceRequestTransactions[] transactions;
    }
    [Serializable]
    public class InvoiceRequestTransactions
    {
        public InvoiceRequestNativeTransactions native;
        public InvoiceRequestStasTransactions stas;
    }
    [Serializable]
    public class InvoiceRequestNativeTransactions
    {
        public double amount;
        public string to;
    }
    [Serializable]
    public class InvoiceRequestStasTransactions
    {
        public double tokenAmount;
        public string tokenRecipient;
        public string tokenId;
    }
    [Serializable]
    public class InvoiceRequestBenificiary
    {
        public string name;
        public string email;
        public string address;
        public string paymentReference;
    }
}