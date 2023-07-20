using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

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
        /// <param name="enableLog"></param>
        public static void ExchangeSwapTransaction(string _swapID,string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, ExchangeSwapResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function ExchangeSwapTransaction");

            ExchangeSwapRequestFormatter exchangeSwapRequestFormatter = new ExchangeSwapRequestFormatter();
            ExchangeSwapRequestDataArray exchangeSwapRequestDataArray = new ExchangeSwapRequestDataArray();
            exchangeSwapRequestDataArray.swapId = _swapID;
            
            exchangeSwapRequestFormatter.dataArray = new ExchangeSwapRequestDataArray[1];
            exchangeSwapRequestFormatter.dataArray[0] = exchangeSwapRequestDataArray;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.exchangeSwap;
            TegmentClient.Post<ExchangeSwapResponseFormatter>(path, exchangeSwapRequestFormatter, callback);
        }
    }
}
