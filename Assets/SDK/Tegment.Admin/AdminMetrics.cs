using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class AdminMetrics
    {
        /// <summary>
        /// Create Metrics from admin
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_userID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void PostMetrics(string _walletID, string _userID, string _authToken, System.Action<RequestException, ResponseHelper, AdminMetricsResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function AdminMetrics");


            MetricsRequestFormatter metricsRequestFormatter = new MetricsRequestFormatter();
            metricsRequestFormatter.walletId = _walletID;
            metricsRequestFormatter.userId = _userID;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Metrics;

            TegmentClient.Post<AdminMetricsResponseFormatter>(path, metricsRequestFormatter, callback);
        }
    }
}
