using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class InitBeta
    {
        /// <summary>
        /// Setup your fee manager
        /// Creates a new Fee Manager that can cover the transaction fees of your users.
        /// </summary>
        /// <param name="_mnemonic"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void InitBetaVersion(string _mnemonic, string _authToken, System.Action<RequestException, ResponseHelper, InitBetaResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function InitBetaVersion");

           
            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["mnemonic"] = _mnemonic;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            TegmentClient.Get<InitBetaResponseFormatter>(PathConstants.baseURL + PathConstants.auth, callback);
        }
    }
}
