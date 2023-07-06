using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

/// <summary>
/// This class is used to create the signup request on Tegment SDK for sample
/// To disable logging, set the last param to false on SDK call
/// </summary>
namespace Tegment.Unity.Samples.Account
{
    public class SignupHandler : MonoBehaviour
    {
        public static SignupHandler Instance;
        //Email input
        [SerializeField]
        private TMP_InputField email;
        //Password Input
        [SerializeField]
        private TMP_InputField password;
        //Error Text
        [SerializeField]
        private TextMeshProUGUI errorText;
        private void Awake()
        {
            Instance = this;
        }
        /// <summary>
        /// Signup button handler
        /// </summary>
        public void SignUp()
        {
            Tegment.Account.SignUP.SignUPAccount(email.text, password.text, SignUpCallBack,true);
        }
        /// <summary>
        /// Callback for the request Sent to SDK to handle the response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="signupResponse"></param>
        private void SignUpCallBack(RequestException exception, ResponseHelper response, SignUpResponseFormatter signupResponse)
        {
            if (exception == null)
            {
                TegmentSessionHandler.Instance.OnSuccessSignUp(exception, response, signupResponse);
            }
            else
            {
                errorText.text = signupResponse.data.msg;
            }
        }
    }
}