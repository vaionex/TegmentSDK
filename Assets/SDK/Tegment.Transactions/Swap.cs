using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

namespace Tegment.Transaction
{
    public static partial class Swap
    {
        /// <summary>
        /// Accepting atomic swap offers
        /// This transaction allows users to accept swap offers by passing respective hex value.
        /// </summary>
        /// <param name="_swapHex"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void SwapTransaction(string _swapHex, string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, SwapResponseFormatter> callback)
        {
            SwapRequestFormatter swapRequestFormatter = new SwapRequestFormatter();
            SwapRequestDataArray swapRequestDataArray = new SwapRequestDataArray();
            swapRequestDataArray.swapHex = _swapHex;

            swapRequestFormatter.dataArray = new SwapRequestDataArray[1];
            swapRequestFormatter.dataArray[0] = swapRequestDataArray;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;

            TegmentClient.Post<SwapResponseFormatter>(PathConstants.baseURL + PathConstants.swap, swapRequestFormatter, callback);
        }
    }
}