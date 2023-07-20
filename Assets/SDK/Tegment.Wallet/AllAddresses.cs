using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Wallet
{
    public static partial class AllAddresses
    {
        /// <summary>
        /// Get All addresses from wallets
        /// Get a list of all wallet addresses that are currently available in your wallet.
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GetAllAddress(string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, AllAddressResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetAllAddress");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            string path = PathConstants.baseURL + PathConstants.allAddresses;
            TegmentClient.Get<AllAddressResponseFormatter>(path, callback);
        }
    }
}
