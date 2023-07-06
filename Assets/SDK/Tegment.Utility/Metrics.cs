using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;

namespace Tegment.Utility
{
    public static partial class Metrics
    {
        /// <summary>
        /// Get the latest wallet UTXO state
        /// UTXOs are the base unit of transactions in the Bitcoin network. The metrics endpoint first updates the last UTXO state, and then shows a detailled output of each UTXO in the wallet.
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <returns></returns>
        public static APIResponseFormatter<MetricsResponseFormatter> MetricsDetails(string _walletID, string _authToken)
        {
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            APIResponseFormatter<MetricsResponseFormatter> apiResponseFormatter = new APIResponseFormatter<MetricsResponseFormatter>();
            TegmentClient.Get<string>(PathConstants.baseURL + PathConstants.tokenMetrics).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<MetricsResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<MetricsResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}