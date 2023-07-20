using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Wallet
{
    public static partial class Balance
    {
        /// <summary>
        /// Get your wallet balance
        /// Returns both coin and token balances.
        /// </summary>
        /// <param name="_nextPageToken"></param>
        /// <param name="_walletID"></param>
        /// <param name="_type"></param>
        /// <param name="_currency"></param>
        /// <param name="_compact"></param>
        /// <param name="_maxResults"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GetBalanceData(string _nextPageToken,string _walletID, string _type,string _currency, string _compact, int _maxResults,  string _authToken, System.Action<RequestException, ResponseHelper, BalanceResponseFormatter> callback, bool enableLog=false)
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function GetBalanceData");

            if (!string.IsNullOrEmpty(_nextPageToken))
            {
                TegmentClient.DefaultRequestParams["nextPageToken"] = _nextPageToken;
            }

            if (!string.IsNullOrEmpty(_walletID))
            {
                TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            }
            if (!string.IsNullOrEmpty(_type))
            {
                TegmentClient.DefaultRequestHeaders["type"] = _type;
            }
            if (!string.IsNullOrEmpty(_currency))
            {
                TegmentClient.DefaultRequestHeaders["currency"] = _currency;
            }
            if (!string.IsNullOrEmpty(_compact.ToString()))
            {
                TegmentClient.DefaultRequestHeaders["compact"] = _compact.ToLower();
            }
            if (_maxResults > 0)
            {
                TegmentClient.DefaultRequestHeaders["maxResults"] = _maxResults.ToString();
            }

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            string path = PathConstants.baseURL + PathConstants.balance;
            TegmentClient.Get<BalanceResponseFormatter>(path, callback);
        }
    }
}
