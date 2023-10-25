using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;
namespace Tegment.Wallet
{
    public static partial class Address
    {
        /// <summary>
        /// Get your wallet Address and paymail
        /// Receive a single address and the paymail alias to receive Coins or Token.
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void GetAddress(string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, AddressResponseFormatter> callback, bool enableLog=false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetAddress");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.address;
            TegmentClient.Get<AddressResponseFormatter>(path, callback);
        }
    }
}
