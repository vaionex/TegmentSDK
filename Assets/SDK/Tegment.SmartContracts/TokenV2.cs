using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.SmartContracts
{
    public static partial class TokenV2 
    {
        /// <summary>
        /// Get STAS token details
        /// Insert your STAS tokenId to receive information about it.
        /// </summary>
        /// <param name="_tokenID"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GetTokenV2(string _tokenID, System.Action<RequestException, ResponseHelper, TokenV2_ResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetTokenV2");

            TegmentClient.Get<TokenV2_ResponseFormatter>(PathConstants.baseURL + PathConstants.token_v2 + _tokenID, callback);
        }
    }
}
