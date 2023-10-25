using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;


namespace Tegment.Utility
{
    public static partial class TokenMetrics 
    {
        /// <summary>
        /// Sync tokem from blockchain
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void TokenMetricsSync(string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, TokenMetricsResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function TokenMetricsSync");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.tokenMetrics;
            TegmentClient.Get<TokenMetricsResponseFormatter>(path, callback);
        }
    }
}
