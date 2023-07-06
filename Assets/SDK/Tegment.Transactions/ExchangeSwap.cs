using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

namespace Tegment.Transaction
{
    public static partial class ExchangeSwap 
    {
        /// <summary>
        /// Atomic swap
        /// This swap allows users to accept a swap offers via swap ID
        /// </summary>
        /// <param name="_swapID"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void ExchangeSwapTransaction(string _swapID,string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, ExchangeSwapResponseFormatter> callback)
        {
            ExchangeSwapRequestFormatter exchangeSwapRequestFormatter = new ExchangeSwapRequestFormatter();
            ExchangeSwapRequestDataArray exchangeSwapRequestDataArray = new ExchangeSwapRequestDataArray();
            exchangeSwapRequestDataArray.swapId = _swapID;
            
            exchangeSwapRequestFormatter.dataArray = new ExchangeSwapRequestDataArray[1];
            exchangeSwapRequestFormatter.dataArray[0] = exchangeSwapRequestDataArray;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";


            TegmentClient.Post<string>(PathConstants.baseURL + PathConstants.exchangeSwap, exchangeSwapRequestFormatter);
        }
    }
}