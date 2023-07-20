using UnityEngine;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using System.Collections;
using System.Threading.Tasks;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class AdminTokenMetrics
    {
        /// <summary>
        /// Create Token Metrics
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_userID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void PostTokenMetrics(string _walletID, string _userID, string _authToken, System.Action<RequestException, ResponseHelper, AdminMetricsResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function PostTokenMetrics");


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
