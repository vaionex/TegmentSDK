using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Wallets
{
    /// <summary>
    /// This sample class is used get your wallet Address and paymail
    /// Receive a single address and the paymail alias to receive Coins or Token.
    /// </summary>
    public class AddressHandler : MonoBehaviour
    {
        //WalletID
        [SerializeField]
        private TMP_InputField walletID;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Address Submit button handler
        /// </summary>
        public void Address_Submit()
        {
            responseText.text = "";
            Tegment.Wallet.Address.GetAddress(walletID.text,TegmentSessionHandler.Instance._authToken, AddressCallBack);
        }

        /// <summary>
        /// Callback handler for the response of Address
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="addressResponse"></param>
        private void AddressCallBack(RequestException exception, ResponseHelper response, AddressResponseFormatter addressResponse)
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