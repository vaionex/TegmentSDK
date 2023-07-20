using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class BSVAliasReceiveTransaction
    {
        public static void ReceiveTransaction(string _paymail, string _hex, string _reference, string _sender, string _pubkey, string _signature, string _note, System.Action<RequestException, ResponseHelper, BSVAliasReceiveTransactionResponseFormatter> callback, bool enableLog = false)
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

            string path = PathConstants.baseURL + PathConstants.bsvalias_receiveTranssaction.Replace("{paymailId}", _paymail);
            TegmentClient.Post<BSVAliasReceiveTransactionResponseFormatter>(path, bSVAliasReceiveTransactionRequestFormatter, callback);
        }
    }
}
