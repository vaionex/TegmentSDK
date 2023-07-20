using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class BSVAlias_Address
    {
        public static void PostBSVAliasAdress(string _paymail, string _senderHandle, string _dt,string _signature, double _amount, string _purpose, string _senderName,  System.Action<RequestException, ResponseHelper, BSVAlias_AddressResponseFormatter> callback, bool enableLog = false)
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

            string path = PathConstants.baseURL + PathConstants.bsvalias_Address.Replace("{paymailId}", _paymail);
            TegmentClient.Post<BSVAlias_AddressResponseFormatter>(path, bSVAlias_AddressRequestFormatter, callback);
        }
    }
}
