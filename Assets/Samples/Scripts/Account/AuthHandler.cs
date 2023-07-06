
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine;
using TMPro;

/// <summary>
/// This class is a sample login class to auth with Tegment SDK samples
/// </summary>
namespace Tegment.Unity.Samples.Authentication
{
    public class AuthHandler : MonoBehaviour
    {
        public static AuthHandler Instance;

        [SerializeField]
        private TMP_InputField email;
        [SerializeField]
        private TMP_InputField password;
        [SerializeField]
        private TextMeshProUGUI errorText;
       
        private void Awake()
        {
            Instance = this;
        }
        /// <summary>
        /// Login Button Function
        /// </summary>
        public void Login()
        {
            Tegment.Account.Auth.GetauthToken(email.text, password.text, AuthCallBack);
        }
        /// <summary>
        /// On Auth callback for response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="authResponse"></param>
        private void AuthCallBack(RequestException exception, ResponseHelper response, AuthResponseFormatter authResponse)
        {
            if (exception == null)
            {
                TegmentSessionHandler.Instance.OnSuccessAuth(exception, response, authResponse);
            }
            else
            {
                errorText.text= authResponse.data.msg;
            }
        }
    }
}