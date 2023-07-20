using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class Paymail_BSVAlias
    {
        public static void GetPaymailBSVAlias(string _paymail, System.Action<RequestException, ResponseHelper, PaymailBSVAliasResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetPaymailBSVAlias");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.bsvalias_Get.Replace("{paymailId}",_paymail);
            TegmentClient.Get<PaymailBSVAliasResponseFormatter>(path, callback);
        }
    }
}
