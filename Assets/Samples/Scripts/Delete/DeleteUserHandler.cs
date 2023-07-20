using UnityEngine;
using TMPro;
using Tegment.Network;

namespace Tegment.Unity.Samples.Delete
{
    /// <summary>
    /// Delete User Account
    /// you can delete user related whole data like wallets, paymail, account etc.
    /// </summary>
    public class DeleteUserHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void DeleteUser_Submit()
        {
            responseText.text = "";

            Tegment.Delete.DeleteUser.User(TegmentSessionHandler.Instance._authToken, DeleteUserCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 2 params here, first is for exceptio is there is any
        /// second is response
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        private void DeleteUserCallBack(RequestException exception, ResponseHelper response)
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
