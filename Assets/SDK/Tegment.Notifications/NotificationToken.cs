using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Notifications
{
    public static partial class NotificationToken 
    {
        /// <summary>
        /// Update Notification Token
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_walletId"></param>
        /// <param name="_expoNotificationToken"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void PutNotificationToken(string _userID, string _walletId,string _expoNotificationToken,string _authToken, System.Action<RequestException, ResponseHelper, NotificationTokenResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function PutNotificationToken");

            NotificationTokenRequestFormatter notificationTokenRequestFormatter = new NotificationTokenRequestFormatter();
            notificationTokenRequestFormatter.expoNotificationToken = _expoNotificationToken;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletId;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.notification_Token.Replace("{userId}", _userID);
            TegmentClient.Put<NotificationTokenResponseFormatter>(path, notificationTokenRequestFormatter, callback);
        }
    }
}
