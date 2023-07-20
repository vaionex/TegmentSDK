using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class Drop {

        /// <summary>
        /// Withdraw coins from private keys
        /// The drop Transaction allows users to transfer coins (BSV or Token) from a PrivateKey.
        /// </summary>
        /// <param name="_secretKey"></param>
        /// <param name="_serviceId"></param>
        /// <param name="_privateKey"></param>
        /// <param name="_to"></param>
        /// <param name="_amount"></param>
        /// <param name="_notes"></param>
        /// <param name="_tokenId"></param>
        /// <param name="_sn"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void DropTransaction(string _secretKey, string _serviceId, string _privateKey, string _to, double _amount, string _notes, string _tokenId, int _sn, string _authToken, System.Action<RequestException, ResponseHelper, DropResponseFormatter> callback,bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function DropTransaction");

            DropRequestFormatter dropRequestFormatter = new DropRequestFormatter();
            DropRequestDataArray dropRequestDataArray = new DropRequestDataArray();
            dropRequestDataArray.to = _to;
            dropRequestDataArray.amount = _amount;
            dropRequestDataArray.notes = _notes;
            dropRequestDataArray.tokenId = _tokenId;
            dropRequestDataArray.sn = _sn;
            dropRequestFormatter.dataArray = new DropRequestDataArray[1];
            dropRequestFormatter.dataArray[0] = dropRequestDataArray;

            TegmentClient.EnableLog = enableLog;

            if (!string.IsNullOrEmpty(_secretKey))
            {
                TegmentClient.DefaultRequestHeaders["secretKey"] = _secretKey;
            }
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }
            if (!string.IsNullOrEmpty(_privateKey))
            {
                TegmentClient.DefaultRequestHeaders["privateKey"] = _privateKey;
            }

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.drop;
            TegmentClient.Post<DropResponseFormatter>(path, dropRequestFormatter, callback);
        }
    }
}
