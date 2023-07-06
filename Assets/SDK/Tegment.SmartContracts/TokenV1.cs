using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;


namespace Tegment.SmartContracts
{
    public static partial class TokenV1 
    {
        public static APIResponseFormatter<TokenV1_ResponseFormatter> GetTokenV1(string _tokenID)
        {
            APIResponseFormatter<TokenV1_ResponseFormatter> apiResponseFormatter = new APIResponseFormatter<TokenV1_ResponseFormatter>();
            TegmentClient.Get<string>(PathConstants.baseURL + PathConstants.token_v1+_tokenID).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<TokenV1_ResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<TokenV1_ResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}
