using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
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
        public static void SignUPAccount(string _email, string _password, System.Action<RequestException, ResponseHelper, SignUpResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SignUPAccount");

            SignUpRequestFormatter signUpRequestFormatter = new SignUpRequestFormatter();
            signUpRequestFormatter.email = _email;
            signUpRequestFormatter.password = _password;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            TegmentClient.Post<SignUpResponseFormatter>(PathConstants.baseURL + PathConstants.signUP, signUpRequestFormatter, callback);
        }
    }
}
