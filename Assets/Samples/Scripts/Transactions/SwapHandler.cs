using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implements a sample Accepting atomic swap offers
    /// This transaction allows users to accept swap offers by passing respective hex value.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class SwapHandler : MonoBehaviour
    {
        ///Wallet ID
        [SerializeField]
        private TMP_InputField walletId;
        //Swap Hex
        [SerializeField]
        private TMP_InputField SwapHex;
        //Response text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button on click handler
        /// </summary>
        public void SwapTransaction_Submit()
        {
            responseText.text = "";
            Tegment.Transaction.Swap.SwapTransaction(SwapHex.text,walletId.text,TegmentSessionHandler.Instance._authToken, SwapTransactionCallBack,true);
        }

        /// <summary>
        /// Callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="swapTransactionResponse"></param>
        private void SwapTransactionCallBack(RequestException exception, ResponseHelper response, SwapResponseFormatter swapTransactionResponse)
        {
            responseText.text = response.Text;
        }

        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            SwapHex.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}