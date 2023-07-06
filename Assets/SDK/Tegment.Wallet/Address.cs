using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
namespace Tegment.Wallet
{
    public static partial class Address
    {
        /// <summary>
        /// Get your wallet Address and paymail
        /// Receive a single address and the paymail alias to receive Coins or Token.
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void GetAddress(string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, AddressResponseFormatter> callback)
        {
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            
            TegmentClient.Get<AddressResponseFormatter>(PathConstants.baseURL + PathConstants.address, callback);
        }
    }
}
