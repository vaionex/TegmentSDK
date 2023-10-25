using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;
using Tegment.RequestFormatter;

namespace Tegment.Paymail
{

    public static partial class Paymail_Put
    {
        /// <summary>
        /// Put Paymail Details
        /// </summary>
        /// <param name="_walletId"></param>
        /// <param name="_newPaymailId"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void PutPaymailDetails(string _walletId,string _newPaymailId, string _authToken, System.Action<RequestException, ResponseHelper, PaymailPutResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function PutPaymailDetails");

            PaymailPutRequestFormatter paymailPutRequestFormatter = new PaymailPutRequestFormatter();
            paymailPutRequestFormatter.newPaymailId = _newPaymailId;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletId;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.paymail_Put;
            TegmentClient.Put<PaymailPutResponseFormatter>(path, paymailPutRequestFormatter,callback);
        }
    }
}
