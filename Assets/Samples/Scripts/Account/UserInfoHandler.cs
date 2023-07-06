using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Account
{
    /// <summary>
    /// This class is used to get the user information whose loggedin
    /// </summary>

    public class UserInfoHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button to get user info
        /// </summary>
        public void UserInfo_Submit()
        {
            responseText.text = "";
            Tegment.Account.UserInfo.GetUserInfo(TegmentSessionHandler.Instance._authToken, UserInfoCallBack);
        }
        /// <summary>
        /// callback handler to handle the response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="userInfoResponse"></param>
        private void UserInfoCallBack(RequestException exception, ResponseHelper response, UserInfoResponseFormatter userInfoResponse)
        {
            Debug.Log(response.Text);
            responseText.text = response.Text;
        }
        /// <summary>
        /// Back to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}