using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;
using Tegment.RequestFormatter;

namespace Tegment.Paymail
{

    public static partial class Paymail_Put
    {
        public static void PutPaymailDetails(string _walletId,string _newPaymailId, string _authToken, System.Action<RequestException, ResponseHelper, PaymailPutResponseFormatter> callback, bool enableLog = false)
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

            string path = PathConstants.baseURL + PathConstants.paymail_Put;
            TegmentClient.Put<PaymailPutResponseFormatter>(path, paymailPutRequestFormatter,callback);
        }
    }
}
