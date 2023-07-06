using System.Collections;
using System.Collections.Generic;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Network;
using UnityEngine;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Account
{
    public static partial class UserInfo
    {
        /// <summary>
        /// Profile Details
        /// To receive all account specific information.
        /// </summary>
        /// <param name="_oauth"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GetUserInfo(string _oauth, System.Action<RequestException, ResponseHelper, UserInfoResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetUserInfo");

            UserInfoRequestFormatter userInfoRequestFormatter = new UserInfoRequestFormatter();
            userInfoRequestFormatter.oauth = _oauth;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            TegmentClient.DefaultRequestHeaders["oauth"] = _oauth;
            TegmentClient.DefaultRequestHeaders["authToken"] = _oauth;
            TegmentClient.Get<UserInfoResponseFormatter>(PathConstants.baseURL + PathConstants.user,callback);
        }
    }
}
