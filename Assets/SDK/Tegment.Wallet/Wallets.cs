using System.Collections;
using System.Collections.Generic;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine;
using Tegment.Utility;

namespace Tegment.Wallet
{

    public static partial class Wallets
    {
        /// <summary>
        /// List of available user wallets
        /// The function provides the user with a list of all active wallets on their account. Depending on your service requirements, you might have one or multiple wallets.
        /// </summary>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void GetWallets(string _authToken, System.Action<RequestException, ResponseHelper, WalletsResponseFormatter> callback)
        {
            TegmentClient.DefaultRequestHeaders["oauth"] = _authToken;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            TegmentClient.Get<WalletsResponseFormatter>(PathConstants.baseURL + PathConstants.wallets, callback);
        }
    }
}
