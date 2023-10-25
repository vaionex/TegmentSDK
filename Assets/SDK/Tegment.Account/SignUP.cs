using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Account
{
    public static partial class SignUP
    {
        /// <summary>
        /// User Registration
        /// Creates a new user and returns the auth token required for API interactions.
        /// </summary>
        /// <param name="_email"></param>
        /// <param name="_password"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void SignUPAccount(string _email, string _password, System.Action<RequestException, ResponseHelper, SignUpResponseFormatter> callback, bool enableLog=false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SignUPAccount");

            SignUpRequestFormatter signUpRequestFormatter = new SignUpRequestFormatter();
            signUpRequestFormatter.email = _email;
            signUpRequestFormatter.password = _password;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.signUP;
            TegmentClient.Post<SignUpResponseFormatter>(path, signUpRequestFormatter, callback);
        }
    }
}
