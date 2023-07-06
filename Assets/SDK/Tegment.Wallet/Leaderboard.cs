using System.Collections;
using System.Collections.Generic;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine;
using Tegment.Utility;

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
        public static void GetLeaderboard(string _nextPageToken, string _tokenId, string _authToken, System.Action<RequestException, ResponseHelper, LeaderboardResponseFormatter> callback)
        {
            if (!string.IsNullOrEmpty(_nextPageToken))
            {
                TegmentClient.DefaultRequestParams["nextPageToken"] = _nextPageToken;
            }

            TegmentClient.DefaultRequestHeaders["tokenId"] = _tokenId;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            TegmentClient.Get<LeaderboardResponseFormatter>(PathConstants.baseURL + PathConstants.leaderboard, callback);
        }
    }
}
