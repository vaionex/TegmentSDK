using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implements to allows users to accept a swap offers via swap ID
    /// </summary>
    public class ExchangeSwapHandler : MonoBehaviour
    {
        //Wallet ID
        [SerializeField]
        private TMP_InputField walletId;
        //Swap ID
        [SerializeField]
        private TMP_InputField SwapId;
        //Response Text
        [SerializeField]
        private TextMeshProUGUI responseText;


        /// <summary>
        /// Submit button Click event handler
        /// </summary>
        public void ExchangeSwapTransaction_Submit()
        {
            responseText.text = "";
            Tegment.Transaction.ExchangeSwap.ExchangeSwapTransaction(SwapId.text, walletId.text, TegmentSessionHandler.Instance._authToken, ExchangeSwapTransactionCallBack);
        }



        /// <summary>
        /// Callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="ExchangeSwapTransactionResponse"></param>
        private void ExchangeSwapTransactionCallBack(RequestException exception, ResponseHelper response, ExchangeSwapResponseFormatter ExchangeSwapTransactionResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            SwapId.text = "";


            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
