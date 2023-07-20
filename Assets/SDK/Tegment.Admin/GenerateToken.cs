using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class GenerateToken
    {
        /// <summary>
        /// Generates a domain verification token
        /// This authenticate domains to verify whether infrastructure users are actually owning the specific domain.
        /// </summary>
        /// <param name="_domain"></param>
        /// <param name="_authToken"></param>
        /// <param name="_userID"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GenerateTokenAdmin(string _domain, string _authToken, string _userID, System.Action<RequestException, ResponseHelper, GenerateTokenResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GenerateTokenAdmin");

            GenerateTokenRequestFormatter generateTokenRequestFormatter = new GenerateTokenRequestFormatter();
            generateTokenRequestFormatter.domain = _domain;


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["userID"] = _userID;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.domain_GenerateToken;
            TegmentClient.Post<GenerateTokenResponseFormatter>(path, generateTokenRequestFormatter, callback);
        }
    }
}
