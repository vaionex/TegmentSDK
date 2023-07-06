using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;


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
        /// <returns></returns>
        public static void GetPaymentRequest(string _invoiceId, System.Action<RequestException, ResponseHelper, PaymentRequestResponseFormatter> callback)
        {

            TegmentClient.Get<PaymentRequestResponseFormatter>(PathConstants.baseURL + PathConstants.paymentRequest + _invoiceId, callback);
        }
    }
}
