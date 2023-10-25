using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class BSVAliasP2PPaymentDestination 
    {
        /// <summary>
        /// BSV Alias P2P Payment
        /// </summary>
        /// <param name="_paymail"></param>
        /// <param name="_satoshis"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void BSVAliasP2PPayment(string _paymail,int _satoshis, System.Action<RequestException, ResponseHelper, BSVAliasP2PPaymentDestinationResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function BSVAliasP2PPayment");

            BSVAliasP2PPaymentDestinationRequestFormatter bSVAliasP2PPaymentDestinationRequestFormatter = new BSVAliasP2PPaymentDestinationRequestFormatter();
            bSVAliasP2PPaymentDestinationRequestFormatter.satoshis = _satoshis;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.bsvalias_P2P_PaymentDestination.Replace("{paymailId}", _paymail);
            TegmentClient.Post<BSVAliasP2PPaymentDestinationResponseFormatter>( path, bSVAliasP2PPaymentDestinationRequestFormatter, callback);
        }
    }
}
