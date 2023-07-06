using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using Tegment.Utility;

namespace Tegment.Wallet
{
    public static partial class CreateWallet
    {
        /// <summary>
        /// Create wallet
        /// Create a HD wallet of choice in your user account. You can select between standard, secure, escrow and shared wallets.
        /// </summary>
        /// <param name="_walletTitle"></param>
        /// <param name="_mnemonicPhrase"></param>
        /// <param name="paymail"></param>
        /// <param name="_paymailActivate"></param>
        /// <param name="_type"></param>
        /// <param name="_walletLogo"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void CreateWalletAccount(string _walletTitle, bool _paymailActivate, string _authToken, System.Action<RequestException, ResponseHelper, CreateWalletResponseFormatter> callback, string _mnemonicPhrase = null, string _paymail = null, string _type = null, string _walletLogo = null)
        {
            TegmentClient.DefaultRequestHeaders["walletTitle"] = _walletTitle;
            if (!string.IsNullOrEmpty(_mnemonicPhrase))
            {
                TegmentClient.DefaultRequestHeaders["mnemonicPhrase"] = _mnemonicPhrase;
            }
            if (!string.IsNullOrEmpty(_paymail))
            {
                TegmentClient.DefaultRequestHeaders["paymail"] = _paymail;
            }
            if (_paymailActivate)
            {
                TegmentClient.DefaultRequestHeaders["paymailActivate"] = _paymailActivate.ToString().ToLower();
            }
            if (!string.IsNullOrEmpty(_type))
            {
                TegmentClient.DefaultRequestHeaders["type"] = _type;
            }
            if (!string.IsNullOrEmpty(_walletLogo))
            {
                TegmentClient.DefaultRequestHeaders["walletLogo"] = _walletLogo;
            }

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;



            TegmentClient.Get<CreateWalletResponseFormatter>(PathConstants.baseURL + PathConstants.createWallet, callback);
        }
    }
}