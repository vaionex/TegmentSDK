using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

//This class is used to reset password and send a confirmation to the registered mail.
namespace Tegment.Unity.Samples.Account
{
    public class ResetPasswordHandler : MonoBehaviour
    {

        public static ResetPasswordHandler Instance;

        [SerializeField]
        private TMP_InputField email;
        [SerializeField]
        private TextMeshProUGUI errorText;

        private void Awake()
        {
            Instance = this;
        }
        /// <summary>
        /// Reset Password Button
        /// </summary>
        public void ResetPassword()
        {
            Tegment.Account.ResetPassword.ResetUserPassword(email.text, ResetPasswordCallBack);
        }

        /// <summary>
        /// Reset Password callback from server to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="resetPasswordResponse"></param>
        private void ResetPasswordCallBack(RequestException exception, ResponseHelper response, ResetPasswordResponseFormatter resetPasswordResponse)
        {
            if (exception == null)
            {
                TegmentSessionHandler.Instance.OnSuccessResetPassword(exception, response, resetPasswordResponse);
            }
            else
            {
                errorText.text = resetPasswordResponse.data.msg;
            }
        }
    }
}