using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

/// <summary>
/// Change password sample for existing users to change their password.
/// </summary>
namespace Tegment.Unity.Samples.Account
{
    public class PasswordChangeHandler : MonoBehaviour
    {
        //New passwordInput
        [SerializeField]
        private TMP_InputField newPassword;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click
        /// </summary>
        public void PasswordChange_Submit()
        {
            responseText.text = "";
            Tegment.Account.PasswordChange.PasswordChangeUser(newPassword.text, TegmentSessionHandler.Instance._authToken, PasswordChangeCallBack);
        }

        /// <summary>
        /// Callback response handler
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="passwordChangeResponse"></param>
        private void PasswordChangeCallBack(RequestException exception, ResponseHelper response, PasswordChangeResponseFormatter passwordChangeResponse)
        {
            Debug.Log(response.Text);
            newPassword.text = "";
            responseText.text = response.Text;
        }
        /// <summary>
        /// Clear the input controls and go back to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
