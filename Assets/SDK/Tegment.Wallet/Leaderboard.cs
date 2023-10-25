using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Wallet
{
    public static partial class Leaderboard
    {
        /// <summary>
        /// Get token ownership details
        /// Returns all user data who have this particular token.
        /// </summary>
        /// <param name="_nextPageToken"></param>
        /// <param name="_tokenId"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void GetLeaderboard(string _nextPageToken, string _tokenId, string _authToken, System.Action<RequestException, ResponseHelper, LeaderboardResponseFormatter> callback, bool enableLog=false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetLeaderboard");

            TegmentClient.EnableLog = enableLog;

            if (!string.IsNullOrEmpty(_nextPageToken))
            {
                TegmentClient.DefaultRequestParams["nextPageToken"] = _nextPageToken;
            }

            TegmentClient.DefaultRequestHeaders["tokenId"] = _tokenId;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.leaderboard;
            TegmentClient.Get<LeaderboardResponseFormatter>(path, callback);
        }
    }
}
