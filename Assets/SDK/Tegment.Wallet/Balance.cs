using System.Collections;
using System.Collections.Generic;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine;
using Tegment.Utility;
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
        public static void GetBalanceData(string _nextPageToken,string _walletID, string _type,string _currency, string _compact, int _maxResults,  string _authToken, System.Action<RequestException, ResponseHelper, BalanceResponseFormatter> callback)
        {
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

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;


            TegmentClient.Get<BalanceResponseFormatter>(PathConstants.baseURL + PathConstants.balance, callback);
        }
    }
}
