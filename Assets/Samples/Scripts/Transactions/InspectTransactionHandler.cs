using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implement sample that allows users to inspect an atomic swap hex to verify the validity of the offer.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class InspectTransactionHandler : MonoBehaviour
    {
        //SwapHex
        [SerializeField]
        private TMP_InputField swapHex;
        //Response Text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click handler
        /// </summary>
        public void InspectTransaction_Submit()
        {
            responseText.text = "";
            Tegment.Transaction.Inspect.InspectTransaction(swapHex.text, TegmentSessionHandler.Instance._authToken, InspectTransactionCallBack,true);
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
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            swapHex.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}