using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Account
{
    public class ResetPassword
    {
        /// <summary>
        /// Password Reset
        /// Reset your password and send a confirmation to the registered mail.
        /// </summary>
        /// <param name="_email"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void ResetUserPassword(string _email,  System.Action<RequestException, ResponseHelper, ResetPasswordResponseFormatter> callback,bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function ResetUserPassword");

            ResetPasswordRequestFormatter resetPasswordRequestFormatter = new ResetPasswordRequestFormatter();
            resetPasswordRequestFormatter.email = _email;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.passwordReset;
            TegmentClient.Post<ResetPasswordResponseFormatter>(path, resetPasswordRequestFormatter,callback);
        }
    }
}
