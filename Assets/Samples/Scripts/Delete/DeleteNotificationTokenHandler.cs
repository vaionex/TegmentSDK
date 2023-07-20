using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Delete
{

    public class DeleteNotificationTokenHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField userId;
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void DeleteNotificationToken_Submit()
        {
            responseText.text = "";

            Tegment.Delete.DeleteNotificationToken.NotificationToken(walletId.text,userId.text, TegmentSessionHandler.Instance._authToken, DeleteNotificationTokenCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 2 params here, first is for exceptio is there is any
        /// second is response
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        private void DeleteNotificationTokenCallBack(RequestException exception, ResponseHelper response)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}