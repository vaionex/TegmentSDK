using System.Collections;
using System.Collections.Generic;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine;
using Tegment.Utility;

namespace Tegment.Wallet
{
    public static partial class AllAddresses
    {
        /// <summary>
        /// Get All addresses from wallets
        /// Get a list of all wallet addresses that are currently available in your wallet.
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void GetAllAddress(string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, AllAddressResponseFormatter> callback)
        {
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            TegmentClient.Get<AllAddressResponseFormatter>(PathConstants.baseURL + PathConstants.allAddresses, callback);
        }
    }
}
