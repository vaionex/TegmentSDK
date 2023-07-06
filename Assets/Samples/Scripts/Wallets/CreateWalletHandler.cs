using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine.UI;

namespace Tegment.Unity.Samples.Wallets
{
    /// <summary>
    /// This class implements a sample to create wallet
    /// Sample create a HD wallet of choice in your user account. You can select between standard, secure, escrow and shared wallets.
    /// </summary>
    public class CreateWalletHandler : MonoBehaviour
    {
        //wallet Title
        [SerializeField]
        private TMP_InputField walletTitle;
        //mnemonic Phase 
        [SerializeField]
        private TMP_InputField mnemonicPhrase;
        //Paymail
        [SerializeField]
        private TMP_InputField paymail;
        //Type of wallet
        [SerializeField]
        private TMP_InputField _type;
        //Wallet Logo path
        [SerializeField]
        private TMP_InputField walletLogo;
        //True/false activate wallet
        [SerializeField]
        private Toggle walletActivate;
        //Response
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Button click handler for submission
        /// </summary>
        public void CreateWallet_Submit()
        {
           responseText.text = "";
           Tegment.Wallet.CreateWallet.CreateWalletAccount(walletTitle.text, walletActivate.isOn, TegmentSessionHandler.Instance._authToken, CreateWalletCallBack, mnemonicPhrase.text, paymail.text, _type.text, walletLogo.text);
        }
        /// <summary>
        /// callback handler for response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="createWalletResponse"></param>
        private void CreateWalletCallBack(RequestException exception, ResponseHelper response, CreateWalletResponseFormatter createWalletResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletTitle.text = "";
            mnemonicPhrase.text = "";
            paymail.text = "";
            _type.text = "";
            walletLogo.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
