using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Delete
{
    public static partial class DeleteWallet 
    {
        /// <summary>
        /// Deletes Selected wallet and all its data
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void Wallet(string _walletID,string _authToken, System.Action<RequestException, ResponseHelper> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function DeleteWallet");


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            DeleteEmptyBody deleteEmptyBody = new DeleteEmptyBody();
            deleteEmptyBody.emptybodyText = "";

            string path = PathConstants.baseURL + PathConstants.delete_wallets;

            RequestHelper requestHelper = new RequestHelper();
            requestHelper.Body = deleteEmptyBody;
            requestHelper.Uri = path;

            TegmentClient.Delete(requestHelper, callback);
        }
    }
}
