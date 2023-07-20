using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Notifications
{
    public static partial class SendNotification
    {
        public static void SendNotificationFromWallet(string _walletId, string _type, string _userAddress,double _amount, string _transactionType, string _authToken, System.Action<RequestException, ResponseHelper, SendNotificationsResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SendNotificationFromWallet");

            SendNotificationRequestFormatter sendNotificationRequestFormatter = new SendNotificationRequestFormatter();
            sendNotificationRequestFormatter.type = _type;
            sendNotificationRequestFormatter.userAddress = _userAddress;
            sendNotificationRequestFormatter.amount = _amount;
            sendNotificationRequestFormatter.transactionType = _transactionType;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletId;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.send_notification;
            TegmentClient.Post<SendNotificationsResponseFormatter>(path, sendNotificationRequestFormatter, callback);
        }
    }
}
