using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class PaymentRequest 
    {
        /// <summary>
        /// Create an invoice
        /// Invoices allow merchants to specify the amount of BSV or Tokens they require to complete a value exchange, such as selling a Product.
        /// </summary>
        /// <param name="_invoiceId"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GetPaymentRequest(string _invoiceId, System.Action<RequestException, ResponseHelper, PaymentRequestResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetPaymentRequest");

            TegmentClient.Get<PaymentRequestResponseFormatter>(PathConstants.baseURL + PathConstants.paymentRequest + _invoiceId, callback);
        }
    }
}
