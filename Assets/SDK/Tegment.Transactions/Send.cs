using System.Collections;
using System.Collections.Generic;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine;
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
        /// <param name="_to"></param>
        /// <param name="_amount"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void SendAmount(string _walletID, string _to, double _amount, string _authToken, System.Action<RequestException, ResponseHelper, SendResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SendAmount");

            SendRequestFormatter sendRequestFormatter = new SendRequestFormatter();
            SendRequestDataArray sendRequestDataArray = new SendRequestDataArray();
            sendRequestDataArray.to = _to;
            sendRequestDataArray.amount = _amount;
            sendRequestFormatter.dataArray = new SendRequestDataArray[1];
            sendRequestFormatter.dataArray[0] = sendRequestDataArray;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;

            TegmentClient.Post<SendResponseFormatter>(PathConstants.baseURL + PathConstants.send, sendRequestFormatter, callback);
        }
    }
}
