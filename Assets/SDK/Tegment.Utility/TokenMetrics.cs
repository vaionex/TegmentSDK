using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;

namespace Tegment.Utility
{
    public static partial class TokenMetrics 
    {
        /// <summary>
        /// Sync tokem from blockchain
        /// 
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <returns></returns>
        public static APIResponseFormatter<TokenMetricsResponseFormatter> TokenMetricsSync(string _walletID, string _authToken)
        {
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            APIResponseFormatter<TokenMetricsResponseFormatter> apiResponseFormatter = new APIResponseFormatter<TokenMetricsResponseFormatter>();
            TegmentClient.Get<string>(PathConstants.baseURL + PathConstants.tokenMetrics).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<TokenMetricsResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<TokenMetricsResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}
