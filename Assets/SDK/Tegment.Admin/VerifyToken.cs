using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class VerifyToken
    {
        /// <summary>
        /// Verify domain ownership
        /// </summary>
        /// <param name="_domain"></param>
        /// <param name="_authToken"></param>
        /// <param name="_userID"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void VerifyTokenAdmin(string _domain, string _authToken, string _userID, System.Action<RequestException, ResponseHelper, VerifyTokenResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function VerifyTokenAdmin");

            VerifyTokenRequestFormatter verifyTokenRequestFormatter = new VerifyTokenRequestFormatter();
            verifyTokenRequestFormatter.domain = _domain;


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["userID"] = _userID;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL+PathConstants.verifyToken.Replace("{userId}", _userID);

            TegmentClient.Post<VerifyTokenResponseFormatter>(path, verifyTokenRequestFormatter, callback);
        }
    }
}
