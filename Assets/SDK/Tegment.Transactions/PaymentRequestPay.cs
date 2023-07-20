using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

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
        /// <param name="enableLog"></param>
        public static void SettleInvoice(string _invoiceId, string _merchantData, string _transaction, string _refundTo, string _memo, System.Action<RequestException, ResponseHelper, PaymentRequestPayResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SettleInvoice");


            PaymentRequestPayRequestFormatter paymentRequestPayRequestFormatter = new PaymentRequestPayRequestFormatter();
            paymentRequestPayRequestFormatter.merchantData = _merchantData;
            paymentRequestPayRequestFormatter.transaction = _transaction;
            paymentRequestPayRequestFormatter.refundTo = _refundTo;
            paymentRequestPayRequestFormatter.memo = _memo;

            TegmentClient.EnableLog = enableLog;

            string path = PathConstants.baseURL + PathConstants.paymentRequest_Pay.Replace("{invoiceId}",_invoiceId);
            TegmentClient.Post<PaymentRequestPayResponseFormatter>(path, paymentRequestPayRequestFormatter, callback);
        }
    }
}
