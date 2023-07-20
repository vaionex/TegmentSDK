using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

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
        /// <param name="enableLog"></param>
        public static void PasswordChangeUser(string _newPassword, string _authToken, System.Action<RequestException, ResponseHelper, PasswordChangeResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function PasswordChangeUser");

            PasswordChangeRequestFormatter passwordChangeRequestFormatter = new PasswordChangeRequestFormatter();
            passwordChangeRequestFormatter.newPassword = _newPassword;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            string path = PathConstants.baseURL + PathConstants.passwordChange;
            TegmentClient.Post<PasswordChangeResponseFormatter>(path, passwordChangeRequestFormatter, callback);
        }
    }
}
