using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Notifications
{
    public static partial class SendNotification
    {
        /// <summary>
        /// Send a Notification from Wallet
        /// </summary>
        /// <param name="_walletId"></param>
        /// <param name="_type"></param>
        /// <param name="_userAddress"></param>
        /// <param name="_amount"></param>
        /// <param name="_transactionType"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void SendNotificationFromWallet(string _walletId, string _type, string _userAddress,double _amount, string _transactionType, string _authToken, System.Action<RequestException, ResponseHelper, SendNotificationsResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
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
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.send_notification;
            TegmentClient.Post<SendNotificationsResponseFormatter>(path, sendNotificationRequestFormatter, callback);
        }
    }
}
