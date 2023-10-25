using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;

namespace Tegment.Utility
{
    public static partial class Metrics
    {

        /// <summary>
        /// Get the latest wallet UTXO state
        /// UTXOs are the base unit of transactions in the Bitcoin network. The metrics endpoint first updates the last UTXO state, and then shows a detailled output of each UTXO in the wallet.
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void MetricsDetails(string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, MetricsResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function MetricsDetails");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.metrics;
            TegmentClient.Get<MetricsResponseFormatter>(path, callback);
        }
    }
}