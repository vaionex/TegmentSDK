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
    /// This class implements a sample to get your wallet balance
    /// Returns both coin and token balances.
    /// </summary>
    public class BalanceHandler : MonoBehaviour
    {
        // Next page token
        [SerializeField]
        private TMP_InputField nextPageToken;
        //Wallet Id
        [SerializeField]
        private TMP_InputField walletID;
        //Wallet Type
        [SerializeField]
        private TMP_InputField _type;
        //currency type ( usd, bsv etc)
        [SerializeField]
        private TMP_InputField currency;
        //MAx result per call
        [SerializeField]
        private TMP_InputField maxResults;
        //True/false Is compact
        [SerializeField]
        private Toggle compact;
        //Response text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click handler to get balance
        /// </summary>
        public void Balance_Submit()
        {
            responseText.text = "";
            int maxResultVal = 0;
            if(!string.IsNullOrEmpty(maxResults.text))
            {
                maxResultVal = int.Parse(maxResults.text);
            }
            Tegment.Wallet.Balance.GetBalanceData(nextPageToken.text,walletID.text,_type.text,currency.text,compact.isOn.ToString().ToLower(), maxResultVal, TegmentSessionHandler.Instance._authToken, BalanceCallBack);
        }

        /// <summary>
        /// Callback handler to get response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="balanceResponse"></param>
        private void BalanceCallBack(RequestException exception, ResponseHelper response, BalanceResponseFormatter balanceResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            nextPageToken.text = "";
            walletID.text = "";
            _type.text = "";
            currency.text = "";
            maxResults.text = "";
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
