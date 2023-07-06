using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Wallets
{
    /// <summary>
    /// This class implements a sample to get your Mnemonic Phrase
    /// The mnemonic phrase secures your wallet keys. Each mnemonic acts as seed of a HDPrivatekey that itself contains hundrets of PrivateKeys.
    /// </summary>
    public class MnemonicHandler : MonoBehaviour
    {
        // Wallet Id
        [SerializeField]
        private TMP_InputField walletID;
        //Response text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button handler to get mnemonic data for wallet Id
        /// </summary>
        public void Mnemonic_Submit()
        {
            responseText.text = "";
            Tegment.Wallet.Mnemonic.GetMnemonic(walletID.text, TegmentSessionHandler.Instance._authToken, MnemonicCallBack);
        }

        /// <summary>
        /// Callback handler to get response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="mnemonicResponse"></param>
        private void MnemonicCallBack(RequestException exception, ResponseHelper response, MnemonicResponseFormatter mnemonicResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletID.text = "";
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
