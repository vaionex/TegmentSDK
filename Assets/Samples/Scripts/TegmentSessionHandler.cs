using System.Collections;
using System.Collections.Generic;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.Unity.Samples.Account;
using Tegment.Unity.Samples;
using UnityEngine;

/// <summary>
/// This class is designed to handle the session of current login for Tegment SDK Sample, This implements login UI, Signup UI,and forgot password
/// This class also handles the aurrent authToken for further implementation
/// </summary>
namespace Tegment.Unity.Samples
{
    public class TegmentSessionHandler : MonoBehaviour
    {
        public static TegmentSessionHandler Instance;
        //SDK menu on successful login
        [SerializeField]
        private GameObject SDKMenu;
        //Login UI
        [SerializeField]
        private GameObject LoginUI;
        //Signup UI
        [SerializeField]
        private GameObject SignUpUI;
        //Forgot Password UI
        [SerializeField]
        private GameObject ResetPasswordUI;
        [HideInInspector]
        public bool isAuthenticated = false;
        [HideInInspector]
        public string _authToken;

        private void Awake()
        {
            Instance = this;
        }
        /// <summary>
        /// On successful Login
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="authResponse"></param>
        public void OnSuccessAuth(RequestException exception, ResponseHelper response, AuthResponseFormatter authResponse)
        {
            isAuthenticated = true;
            _authToken = authResponse.data.token;
            LoginUI.SetActive(false);
            SDKMenu.SetActive(true);
        }

        /// <summary>
        /// On Successful SignUP
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="signUpResponse"></param>
        public void OnSuccessSignUp(RequestException exception, ResponseHelper response, SignUpResponseFormatter signUpResponse)
        {
            isAuthenticated = true;
            _authToken = signUpResponse.data.token;
            SignUpUI.SetActive(false);
            SDKMenu.SetActive(true);
        }
        /// <summary>
        /// On Successful Forgot Password
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="resetPasswordResponse"></param>
        public void OnSuccessResetPassword(RequestException exception, ResponseHelper response, ResetPasswordResponseFormatter resetPasswordResponse)
        {
            ResetPasswordUI.SetActive(false);
            LoginUI.SetActive(true);
        }
        public void OnSessionend()
        {
         //   AuthHandler.Instance.Login();
        }
        // Go Back to main menu
        public void ClosePopupGO(GameObject gb)
        {
            SDKMenu.SetActive(true);
            gb.SetActive(false);
        }
    }
}
