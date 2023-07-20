using Tegment.Logs;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

namespace Tegment.Transaction
{
    public static partial class RawTX
    {
        /// <summary>
        /// Build and return Raw Transaction
        /// Use the /rawTx  containing a single input and output. Transactions can be held and the utxo that is used will be blocked from the user access. 
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_to"></param>
        /// <param name="_amount"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void RawTransaction(string _walletID, RawTXRequestDataArray[] _dataArray, string _authToken, System.Action<RequestException, ResponseHelper, RawTxResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function RawTransaction");

            RawTXRequestFormatter rawTXRequestFormatter = new RawTXRequestFormatter();
            RawTXRequestDataArray rawTXRequestDataArray = new RawTXRequestDataArray();
            
            rawTXRequestFormatter.dataArray = new RawTXRequestDataArray[_dataArray.Length];
            rawTXRequestFormatter.dataArray = _dataArray;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;

            string path = PathConstants.baseURL + PathConstants.rawtx;
            TegmentClient.Post<RawTxResponseFormatter>(path, rawTXRequestFormatter, callback);
        }
    }
}
