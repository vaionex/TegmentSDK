using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Notifications
{
    /// <summary>
    /// This class is used to create a notification token 
    /// </summary>
    public class NotificationTokenHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField userId;
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TMP_InputField exportNotification;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void NotificationToken_Submit()
        {
            responseText.text = "";

            Tegment.Notifications.NotificationToken.PutNotificationToken(userId.text, walletId.text, exportNotification.text, TegmentSessionHandler.Instance._authToken, NotificationTokenResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="notificationTokenResponseFormatter"></param>
        private void NotificationTokenResponseCallBack(RequestException exception, ResponseHelper response, NotificationTokenResponseFormatter notificationTokenResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            userId.text = "";
            walletId.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
