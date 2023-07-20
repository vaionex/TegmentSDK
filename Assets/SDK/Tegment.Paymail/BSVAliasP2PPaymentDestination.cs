using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class BSVAliasP2PPaymentDestination 
    {
        public static void BSVAliasP2PPayment(string _paymail,int _satoshis, System.Action<RequestException, ResponseHelper, BSVAliasP2PPaymentDestinationResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function BSVAliasP2PPayment");

            BSVAliasP2PPaymentDestinationRequestFormatter bSVAliasP2PPaymentDestinationRequestFormatter = new BSVAliasP2PPaymentDestinationRequestFormatter();
            bSVAliasP2PPaymentDestinationRequestFormatter.satoshis = _satoshis;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.bsvalias_P2P_PaymentDestination.Replace("{paymailId}", _paymail);
            TegmentClient.Post<BSVAliasP2PPaymentDestinationResponseFormatter>( path, bSVAliasP2PPaymentDestinationRequestFormatter, callback);
        }
    }
}
