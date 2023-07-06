using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implements a sample to allows users to inspect an atomic swap hex to verify the validity of the offer.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class InspectV2TransactionHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField swapHex;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click handler
        /// </summary>
        public void InspectV2Transaction_Submit()
        {
            responseText.text = "";
            Tegment.Transaction.InspectV2.InspectTransactionV2(swapHex.text, TegmentSessionHandler.Instance._authToken, InspectTransactionCallBack,true);
        }

        /// <summary>
        /// Callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="inspectTransactionResponse"></param>
        private void InspectTransactionCallBack(RequestException exception, ResponseHelper response, InspectResponseFormatter inspectTransactionResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// Clear the input controls and go back to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            swapHex.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}