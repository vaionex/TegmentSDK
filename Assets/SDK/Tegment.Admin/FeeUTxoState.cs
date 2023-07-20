using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;


namespace Tegment.Admin
{
    public static partial class FeeUTxoState
    {
        /// <summary>
        /// Get Current state of fee manager UTXOs
        /// The function returns all UTXOs that are stored in Redis DB
        /// </summary>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void FeeUTxoStateAdmin(string _authToken, System.Action<RequestException, ResponseHelper, FeeUTxoStateResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function FeeUTxoStateAdmin");


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.feeUtxoState;
            TegmentClient.Get<FeeUTxoStateResponseFormatter>(path, callback);
        }
    }
}