using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Wallets
{
    /// <summary>
    /// this class implements sample to get All addresses from wallets
    /// Get a list of all wallet addresses that are currently available in your wallet.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class AllAddressHandler : MonoBehaviour
    {
        //Wallet ID Input
        [SerializeField]
        private TMP_InputField walletID;
        //Response
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button To Get All address
        /// </summary>
        public void AllAddress_Submit()
        {
            responseText.text = "";
            Tegment.Wallet.AllAddresses.GetAllAddress(walletID.text, TegmentSessionHandler.Instance._authToken, AllAddressCallBack,true);
        }

        /// <summary>
        /// All address callback to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="allAddressResponse"></param>
        private void AllAddressCallBack(RequestException exception, ResponseHelper response, AllAddressResponseFormatter allAddressResponse)
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
