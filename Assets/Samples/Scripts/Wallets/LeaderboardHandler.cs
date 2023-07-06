using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Wallets
{
    /// <summary>
    /// This class implements a sample to get token ownership details
    /// It returns all user data who have this particular token.
    /// </summary>
    public class LeaderboardHandler : MonoBehaviour
    {
        //next page token
        [SerializeField]
        private TMP_InputField nextPageToken;
        //TokenID
        [SerializeField]
        private TMP_InputField TokenID;
        //Response text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button to get leaderboard
        /// </summary>
        public void Leaderboard_Submit()
        {
            responseText.text = "";
            Tegment.Wallet.Leaderboard.GetLeaderboard(nextPageToken.text, TokenID.text, TegmentSessionHandler.Instance._authToken, LeaderboardCallBack);
        }

        /// <summary>
        /// Callback handler to get response.
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="leaderboardResponse"></param>
        private void LeaderboardCallBack(RequestException exception, ResponseHelper response, LeaderboardResponseFormatter leaderboardResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            nextPageToken.text = "";
            TokenID.text = "";
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
