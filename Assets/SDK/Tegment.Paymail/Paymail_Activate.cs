using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;
using Tegment.RequestFormatter;

namespace Tegment.Paymail
{
    public static partial class Paymail_Activate
    {
        public static void PaymailActivate_DeActivate (bool _activate, string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, PaymailActivateResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function PaymailActivate_DeActivate");

            PaymailActivateRequestFormatter paymailActivateRequestFormatter = new PaymailActivateRequestFormatter();
            paymailActivateRequestFormatter.activate = _activate.ToString().ToLower();

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.paymail_Activate;
            TegmentClient.Post<PaymailActivateResponseFormatter>(path, paymailActivateRequestFormatter, callback);
        }
    }
}
