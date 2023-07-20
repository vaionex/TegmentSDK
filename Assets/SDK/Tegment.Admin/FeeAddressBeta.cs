using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class FeeAddressBeta 
    {
        /// <summary>
        /// Get all Fee Manager Addresses
        /// Returns a list of feeManager addresses. The feeManager is used to fund transactions.
        /// </summary>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void FeeAddressBetaAdmin(string _authToken, System.Action<RequestException, ResponseHelper, FeeAddressBetaResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetauthToken");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";


            string path = PathConstants.baseURL + PathConstants.feeAddressBeta;
            TegmentClient.Get<FeeAddressBetaResponseFormatter>(path, callback);
        }
    }
}
