using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class Paymail_Get
    {
        /// <summary>
        /// Get Paymail Details
        /// </summary>
        /// <param name="_paymailID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void GetPaymailDetails(string _paymailID, string _authToken, System.Action<RequestException, ResponseHelper, PaymailGetResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetPaymailDetails");
        
            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.paymail_Get.Replace("{paymailId}", _paymailID);
            TegmentClient.Get<PaymailGetResponseFormatter>(path, callback);
        }
    }
}
