using System.Collections;
using System.Collections.Generic;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Wallet
{
    public static partial class Mnemonic
    {
        /// <summary>
        /// Get your Mnemonic Phrase
        /// The mnemonic phrase secures your wallet keys. Each mnemonic acts as seed of a HDPrivatekey that itself contains hundrets of PrivateKeys.
        /// </summary>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GetMnemonic(string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, MnemonicResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetMnemonic");


            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            TegmentClient.Get<MnemonicResponseFormatter>(PathConstants.baseURL + PathConstants.mnemonic, callback);
        }
    }
}
