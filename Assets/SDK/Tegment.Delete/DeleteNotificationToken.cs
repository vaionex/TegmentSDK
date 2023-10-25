using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Delete
{
    public static partial class DeleteNotificationToken
    {
        /// <summary>
        /// Delete notification Token
        /// </summary>
        /// <param name="_walletId"></param>
        /// <param name="_userID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void NotificationToken(string _walletId, string _userID, string _authToken, System.Action<RequestException, ResponseHelper> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function DeleteNotificationToken");
        

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletId;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            DeleteEmptyBody deleteEmptyBody = new DeleteEmptyBody();
            deleteEmptyBody.emptybodyText = "";

            string path = PathConstants.baseURL + PathConstants.delete_notificationToken.Replace("{userId}", _userID);

            RequestHelper requestHelper = new RequestHelper();
            requestHelper.Body = deleteEmptyBody;
            requestHelper.Uri = path;

            
            TegmentClient.Delete(requestHelper, callback);
        }
    }
}
