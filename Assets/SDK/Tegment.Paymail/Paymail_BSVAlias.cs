using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class Paymail_BSVAlias
    {
        /// <summary>
        /// Get Paymail BSV Alias
        /// </summary>
        /// <param name="_paymail"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void GetPaymailBSVAlias(string _paymail, System.Action<RequestException, ResponseHelper, PaymailBSVAliasResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetPaymailBSVAlias");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.bsvalias_Get.Replace("{paymailId}",_paymail);
            TegmentClient.Get<PaymailBSVAliasResponseFormatter>(path, callback);
        }
    }
}
