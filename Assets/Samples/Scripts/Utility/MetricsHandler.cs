using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// Get the latest wallet UTXO state
    /// UTXOs are the base unit of transactions in the Bitcoin network.
    /// The metrics sample first updates the last UTXO state, and then shows a detailled output of each UTXO in the wallet.
    /// </summary>
    public class MetricsHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void Metrics_Submit()
        {
            responseText.text = "";

            Tegment.Utility.Metrics.MetricsDetails(walletId.text, TegmentSessionHandler.Instance._authToken, MetricsResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="metricsResponseFormatter"></param>
        private void MetricsResponseCallBack(RequestException exception, ResponseHelper response, MetricsResponseFormatter metricsResponseFormatter)
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
