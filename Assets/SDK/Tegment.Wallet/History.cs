using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Wallet
{
    public static partial class History
    {
        /// <summary>
        /// Get your History of transactions
        /// The transaction history endpoint returns all past transactions, both BSV and Tokens.
        /// </summary>
        /// <param name="_nextPageToken"></param>
        /// <param name="_tokenId"></param>
        /// <param name="_walletID"></param>
        /// <param name="_type"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GetHistory(string _nextPageToken, string _tokenId, string _walletID, string _type, string _authToken, System.Action<RequestException, ResponseHelper, HistoryResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetHistory");

            TegmentClient.EnableLog = enableLog;

            if (!string.IsNullOrEmpty(_nextPageToken))
            {
                TegmentClient.DefaultRequestParams["nextPageToken"] = _nextPageToken;
            }
            if (!string.IsNullOrEmpty(_tokenId))
            {
                TegmentClient.DefaultRequestParams["tokenId"] = _tokenId;
            }
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            if (!string.IsNullOrEmpty(_type))
            {
                TegmentClient.DefaultRequestHeaders["type"] = _type;
            }

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            string path = PathConstants.baseURL + PathConstants.history;
            TegmentClient.Get<HistoryResponseFormatter>(path,callback);
        }
    }
}
