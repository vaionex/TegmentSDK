using UnityEngine;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;

namespace Tegment.Account
{
    public class ResetPassword
    {
        /// <summary>
        /// Password Reset
        /// Reset your password and send a confirmation to the registered mail.
        /// </summary>
        /// <param name="_email"></param>
        /// <param name="authToken"></param>
        /// <param name="callback"></param>
        public static void ResetUserPassword(string _email,  System.Action<RequestException, ResponseHelper, ResetPasswordResponseFormatter> callback)
        {
            ResetPasswordRequestFormatter resetPasswordRequestFormatter = new ResetPasswordRequestFormatter();
            resetPasswordRequestFormatter.email = _email;


            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            TegmentClient.Post<ResetPasswordResponseFormatter>(PathConstants.baseURL + PathConstants.passwordReset, resetPasswordRequestFormatter,callback);
        }
    }
}
