using UnityEngine;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using System.Collections;
using System.Threading.Tasks;

namespace Tegment.Account
{
    public static partial class Auth
    {
        /// <summary>
        /// Login with an existing user account.
        /// This will be used to Get Auth Token for user who is signing In to relysia account, It will return authToken for further API calls
        /// </summary>
        /// <param name="_email"></param>
        /// <param name="_password"></param>
        /// <param name="callback"></param>
        public static void GetauthToken(string _email, string _password, System.Action<RequestException, ResponseHelper,AuthResponseFormatter> callback)
        {
            AuthRequestFormatter authRequestFormatter = new AuthRequestFormatter();
            authRequestFormatter.email = _email;
            authRequestFormatter.password = _password;


            TegmentClient.DefaultRequestHeaders["Content-Type"]= "application/json";
            TegmentClient.DefaultRequestHeaders["accept"]= "*/*";
            TegmentClient.Post<AuthResponseFormatter> (PathConstants.baseURL + PathConstants.auth, authRequestFormatter, callback);
        }
    }
}