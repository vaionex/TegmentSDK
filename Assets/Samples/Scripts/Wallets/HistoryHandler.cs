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
    /// This class implements a sample to get your History of transactions
    /// It returns all past transactions, both BSV and Tokens.
    /// </summary>
    public class HistoryHandler : MonoBehaviour
    {
        //Next page token
        [SerializeField]
        private TMP_InputField nextPageToken;
        //Token id
        [SerializeField]
        private TMP_InputField tokenID;
        //Wallet Id
        [SerializeField]
        private TMP_InputField walletID;
        //Type 
        [SerializeField]
        private TMP_InputField _type;

        //Response text
        [SerializeField]
        private TextMeshProUGUI responseText;


        /// <summary>
        /// Submit button to get history of transactions
        /// </summary>
        public void History_Submit()
        {
            responseText.text = "";
            Tegment.Wallet.History.GetHistory(nextPageToken.text,tokenID.text, walletID.text, _type.text, TegmentSessionHandler.Instance._authToken, HistoryCallBack);
        }

        /// <summary>
        /// Callback function to handle the response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="historyResponse"></param>
        private void HistoryCallBack(RequestException exception, ResponseHelper response, HistoryResponseFormatter historyResponse)
        {
            responseText.text = response.Text;
        }

        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            nextPageToken.text = "";
            tokenID.text = "";
            walletID.text = "";
            _type.text = "";
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
