using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Wallets
{
    /// <summary>
    /// This implements to provide list of available user wallets. As a param this needs a oauth as param to get data
    /// The function provides the user with a list of all active wallets on their account. Depending on your service requirements, you might have one or multiple wallets.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class WalletsHandler : MonoBehaviour
    {
        //Response Text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button to get wallets
        /// </summary>
        public void Wallets_Submit()
        {
            responseText.text = "";
            Tegment.Wallet.Wallets.GetWallets(TegmentSessionHandler.Instance._authToken, WalletsCallBack,true);
        }

        /// <summary>
        /// Callback to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="leaderboardResponse"></param>
        private void WalletsCallBack(RequestException exception, ResponseHelper response, WalletsResponseFormatter leaderboardResponse)
        {
            responseText.text = response.Text;
        }

        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}