using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

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
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void SwapTransaction(string _swapHex, string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, SwapResponseFormatter> callback, bool enableLog=false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SwapTransaction");

            SwapRequestFormatter swapRequestFormatter = new SwapRequestFormatter();
            SwapRequestDataArray swapRequestDataArray = new SwapRequestDataArray();
            swapRequestDataArray.swapHex = _swapHex;

            swapRequestFormatter.dataArray = new SwapRequestDataArray[1];
            swapRequestFormatter.dataArray[0] = swapRequestDataArray;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.swap;
            TegmentClient.Post<SwapResponseFormatter>(path, swapRequestFormatter, callback);
        }
    }
}