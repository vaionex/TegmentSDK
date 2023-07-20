using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class Paymail_Get
    {
        public static void GetPaymailDetails(string _paymailID, string _authToken, System.Action<RequestException, ResponseHelper, PaymailGetResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetPaymailDetails");
        
            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.paymail_Get.Replace("{paymailId}", _paymailID);
            TegmentClient.Get<PaymailGetResponseFormatter>(path, callback);
        }
    }
}
