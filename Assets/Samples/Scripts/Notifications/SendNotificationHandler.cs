using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Notifications
{
    /// <summary>
    /// to send notification 
    /// </summary>
    public class SendNotificationHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TMP_InputField _type;
        [SerializeField]
        private TMP_InputField userAddress;
        [SerializeField]
        private TMP_InputField amount;
        [SerializeField]
        private TMP_InputField transactionType;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void SendNotification_Submit()
        {
            responseText.text = "";

            double amountVal = 0f;
            if (!string.IsNullOrEmpty(amount.text))
            {
                amountVal = double.Parse(amount.text);
            }

            Tegment.Notifications.SendNotification.SendNotificationFromWallet(walletId.text,_type.text,userAddress.text,amountVal,transactionType.text, TegmentSessionHandler.Instance._authToken, SendNotificationResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="sendNotificationsResponseFormatter"></param>
        private void SendNotificationResponseCallBack(RequestException exception, ResponseHelper response, SendNotificationsResponseFormatter sendNotificationsResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text="";
            _type.text="";
            userAddress.text="";
            amount.text="";
            transactionType.text="";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}