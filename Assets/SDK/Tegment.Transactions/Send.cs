using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.RequestFormatter;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class Send 
    {
        /// <summary>
        /// Transfer coins to an address
        /// Use the /send function to create transactions to peers. The /send endpoint is agnostic to sending either Tokens or BSV.
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="dataArray"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void SendAmount(string _walletID, SendRequestDataArray[] dataArray, string _authToken, System.Action<RequestException, ResponseHelper, SendResponseFormatter> callback, bool enableLog=false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SendAmount");

            SendRequestFormatter sendRequestFormatter = new SendRequestFormatter();
            sendRequestFormatter.dataArray = new SendRequestDataArray[dataArray.Length];
            sendRequestFormatter.dataArray = dataArray;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.send;
            TegmentClient.Post<SendResponseFormatter>(path, sendRequestFormatter, callback);
        }
    }
}
