using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class BSVAliasReceiveTransaction
    {
        /// <summary>
        /// Receive Transaction
        /// </summary>
        /// <param name="_paymail"></param>
        /// <param name="_hex"></param>
        /// <param name="_reference"></param>
        /// <param name="_sender"></param>
        /// <param name="_pubkey"></param>
        /// <param name="_signature"></param>
        /// <param name="_note"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void ReceiveTransaction(string _paymail, string _hex, string _reference, string _sender, string _pubkey, string _signature, string _note, System.Action<RequestException, ResponseHelper, BSVAliasReceiveTransactionResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function ReceiveTransaction");

            BSVAliasReceiveTransactionRequestFormatter bSVAliasReceiveTransactionRequestFormatter = new BSVAliasReceiveTransactionRequestFormatter();
            bSVAliasReceiveTransactionRequestFormatter.hex = _hex;
            bSVAliasReceiveTransactionRequestFormatter.reference = _reference;

            BSVAliasReceiveTransactionRequestFormatterMetaData bSVAliasReceiveTransactionRequestFormatterMetaData = new BSVAliasReceiveTransactionRequestFormatterMetaData();
            bSVAliasReceiveTransactionRequestFormatterMetaData.sender = _sender;
            bSVAliasReceiveTransactionRequestFormatterMetaData.pubkey = _pubkey;
            bSVAliasReceiveTransactionRequestFormatterMetaData.signature = _signature;
            bSVAliasReceiveTransactionRequestFormatterMetaData.note = _note;

            bSVAliasReceiveTransactionRequestFormatter.metadata = bSVAliasReceiveTransactionRequestFormatterMetaData;


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.bsvalias_receiveTranssaction.Replace("{paymailId}", _paymail);
            TegmentClient.Post<BSVAliasReceiveTransactionResponseFormatter>(path, bSVAliasReceiveTransactionRequestFormatter, callback);
        }
    }
}
