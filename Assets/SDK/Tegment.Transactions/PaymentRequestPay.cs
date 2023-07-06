using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

namespace Tegment.Transaction
{
    public static partial class PaymentRequestPay
    {
        /// <summary>
        /// Settle an invoice request
        /// The function takes invoice and settles it.
        /// </summary>
        /// <param name="_invoiceId"></param>
        /// <param name="_merchantData"></param>
        /// <param name="_transaction"></param>
        /// <param name="_refundTo"></param>
        /// <param name="_memo"></param>
        /// <param name="callback"></param>
        public static void SettleInvoice(string _invoiceId, string _merchantData, string _transaction, string _refundTo, string _memo, System.Action<RequestException, ResponseHelper, PaymentRequestPayResponseFormatter> callback)
        {
            PaymentRequestPayRequestFormatter paymentRequestPayRequestFormatter = new PaymentRequestPayRequestFormatter();
            paymentRequestPayRequestFormatter.merchantData = _merchantData;
            paymentRequestPayRequestFormatter.transaction = _transaction;
            paymentRequestPayRequestFormatter.refundTo = _refundTo;
            paymentRequestPayRequestFormatter.memo = _memo;

            TegmentClient.Post<PaymentRequestPayResponseFormatter>(PathConstants.baseURL + PathConstants.paymentRequest_Pay + _invoiceId, paymentRequestPayRequestFormatter, callback);
        }
    }
}
