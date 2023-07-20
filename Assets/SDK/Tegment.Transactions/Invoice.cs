using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class Invoice
    {
        /// <summary>
        /// Create an Invoice
        /// Create an invoice to receive payments for a merchant product.
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_amount"></param>
        /// <param name="_address"></param>
        /// <param name="_description"></param>
        /// <param name="_expirationTimeInMinuts"></param>
        /// <param name="_memo"></param>
        /// <param name="_merchantData"></param>
        /// <param name="_paymentOptions"></param>
        /// <param name="_modeId"></param>
        /// <param name="_beneficiary"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void CreateInvoice(string _type, double _amount,string _address, string _description,
            int _expirationTimeInMinuts, string _memo, string _merchantData, InvoiceRequestPaymentOptions[] _paymentOptions, string _modeId,
            InvoiceRequestBenificiary _beneficiary, string _authToken, System.Action<RequestException, ResponseHelper, InvoiceResponseFormatter> callback, bool enableLog=false)
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function CreateInvoice");


            InvoiceRequestFormatter invoiceRequestFormatter = new InvoiceRequestFormatter();
            invoiceRequestFormatter.type = _type;
            invoiceRequestFormatter.amount = _amount;
            invoiceRequestFormatter.address = _address;
            invoiceRequestFormatter.description = _description;
            invoiceRequestFormatter.expirationTimeInMinuts = _expirationTimeInMinuts;
            invoiceRequestFormatter.memo = _memo;
            invoiceRequestFormatter.merchantData = _merchantData;
            invoiceRequestFormatter.paymentOptions = _paymentOptions;
            invoiceRequestFormatter.modeId = _modeId;
            invoiceRequestFormatter.beneficiary = _beneficiary;

            TegmentClient.EnableLog = enableLog;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            string path = PathConstants.baseURL + PathConstants.invoice;
            TegmentClient.Post<InvoiceResponseFormatter>(path, invoiceRequestFormatter, callback);
        }
    }
}
