using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;


namespace Tegment.Admin
{

    public static partial class FeeMetricsBeta
    {
        /// <summary>
        /// Get All Feemanager UTXOs
        /// The endpoint returns all UTXOs and refreshes the UTXO set.
        /// </summary>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void SetupFeeMetricsBeta(string _authToken, System.Action<RequestException, ResponseHelper, FeeMetricsBetaResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SetupFeeMetricsBeta");


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.auth;
            TegmentClient.Get<FeeMetricsBetaResponseFormatter>(path, callback);
        }
    }
}