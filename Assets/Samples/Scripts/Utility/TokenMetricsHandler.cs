using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// Sync token from blockchain
    /// </summary>
    public class TokenMetricsHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void TokenMetrics_Submit()
        {
            responseText.text = "";

            Tegment.Utility.TokenMetrics.TokenMetricsSync(walletId.text, TegmentSessionHandler.Instance._authToken,TokenMetricsResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="tokenMetricsResponseFormatter"></param>
        private void TokenMetricsResponseCallBack(RequestException exception, ResponseHelper response, TokenMetricsResponseFormatter tokenMetricsResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}