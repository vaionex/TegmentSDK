using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implements a sample to build and return Raw Transaction
    /// Use the /rawTx  containing a single input and output. Transactions can be held and the utxo that is used will be blocked from the user access.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class RawTransactionsHandler : MonoBehaviour
    {
        //Wallet ID
        [SerializeField]
        private TMP_InputField walletId;
        //Receiver paymail or wallet id
        [SerializeField]
        private TMP_InputField To;
        //Amount to send
        [SerializeField]
        private TMP_InputField amount;
        //Response Text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void RawTransaction_Submit()
        {
            double amountVal = 0f;
            if (!string.IsNullOrEmpty(amount.text))
            {
                amountVal = double.Parse(amount.text);
            }

            RawTXRequestDataArray[] dataArrays = new RawTXRequestDataArray[1];
            dataArrays[0].to = To.text;
            dataArrays[0].amount = amountVal;

            responseText.text = "";
            Tegment.Transaction.RawTX.RawTransaction(walletId.text, dataArrays, TegmentSessionHandler.Instance._authToken, RawTransactionCallBack,true);
        }


        /// <summary>
        /// Callback handler to get the response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="rawTransactionResponse"></param>
        private void RawTransactionCallBack(RequestException exception, ResponseHelper response, RawTxResponseFormatter rawTransactionResponse)
        {
            responseText.text = response.Text;
        }

        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            To.text = "";
            amount.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
