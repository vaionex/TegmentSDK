using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class BSVAlias_Address
    {
        /// <summary>
        /// Post BSVAlias Address
        /// </summary>
        /// <param name="_paymail"></param>
        /// <param name="_senderHandle"></param>
        /// <param name="_dt"></param>
        /// <param name="_signature"></param>
        /// <param name="_amount"></param>
        /// <param name="_purpose"></param>
        /// <param name="_senderName"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void PostBSVAliasAddress(string _paymail, string _senderHandle, string _dt,string _signature, double _amount, string _purpose, string _senderName,  System.Action<RequestException, ResponseHelper, BSVAlias_AddressResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function PostBSVAliasAdress");

            BSVAlias_AddressRequestFormatter bSVAlias_AddressRequestFormatter = new BSVAlias_AddressRequestFormatter();
            bSVAlias_AddressRequestFormatter.senderHandle = _senderHandle;
            bSVAlias_AddressRequestFormatter.dt = _dt;
            bSVAlias_AddressRequestFormatter.signature = _signature;
            bSVAlias_AddressRequestFormatter.amount = _amount;
            bSVAlias_AddressRequestFormatter.purpose = _purpose;
            bSVAlias_AddressRequestFormatter.senderName = _senderName;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.bsvalias_Address.Replace("{paymailId}", _paymail);
            TegmentClient.Post<BSVAlias_AddressResponseFormatter>(path, bSVAlias_AddressRequestFormatter, callback);
        }
    }
}
