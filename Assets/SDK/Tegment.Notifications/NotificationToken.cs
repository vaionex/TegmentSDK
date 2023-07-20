using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Notifications
{
    public static partial class NotificationToken 
    {
        public static void PutNotificationToken(string _userID, string _walletId,string _expoNotificationToken,string _authToken, System.Action<RequestException, ResponseHelper, NotificationTokenResponseFormatter> callback, bool enableLog = false)
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

            string path = PathConstants.baseURL + PathConstants.notification_Token.Replace("{userId}", _userID);
            TegmentClient.Put<NotificationTokenResponseFormatter>(path, notificationTokenRequestFormatter, callback);
        }
    }
}
