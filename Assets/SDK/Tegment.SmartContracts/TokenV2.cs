using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

namespace Tegment.SmartContracts
{
    public static partial class TokenV2 
    {
        /// <summary>
        /// Get STAS token details
        /// Insert your STAS tokenId to receive information about it.
        /// </summary>
        /// <param name="_tokenID"></param>
        /// <returns></returns>
        public static APIResponseFormatter<TokenV2_ResponseFormatter> GetTokenV2(string _tokenID)
        {
            APIResponseFormatter<TokenV2_ResponseFormatter> apiResponseFormatter = new APIResponseFormatter<TokenV2_ResponseFormatter>();
            TegmentClient.Get<string>(PathConstants.baseURL + PathConstants.token_v2 + _tokenID).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<TokenV2_ResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<TokenV2_ResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}
