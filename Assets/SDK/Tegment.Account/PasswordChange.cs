using System.Collections;
using System.Collections.Generic;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Network;
using UnityEngine;
using Tegment.Utility;

namespace Tegment.Account
{
    public class PasswordChange {
        /// <summary>
        /// Change Password
        /// Change password function for existing users to change their password.
        /// </summary>
        /// <param name="_newPassword"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void PasswordChangeUser(string _newPassword, string _authToken, System.Action<RequestException, ResponseHelper, PasswordChangeResponseFormatter> callback)
        {
            PasswordChangeRequestFormatter passwordChangeRequestFormatter = new PasswordChangeRequestFormatter();
            passwordChangeRequestFormatter.newPassword = _newPassword;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            TegmentClient.Post<PasswordChangeResponseFormatter>(PathConstants.baseURL + PathConstants.passwordChange, passwordChangeRequestFormatter, callback);
        }
    }
}
