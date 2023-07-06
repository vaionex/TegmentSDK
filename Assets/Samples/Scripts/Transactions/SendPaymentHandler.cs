using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implements a sample to transfer coins to an address
    /// Use this sample to create transactions to peers. this is agnostic to sending either Tokens or BSV.
    /// </summary>
    public class SendPaymentHandler : MonoBehaviour
    {
        //User's wallet id
        [SerializeField]
        private TMP_InputField walletId;
        //paymail or wallet address for receiver
        [SerializeField]
        private TMP_InputField To;
        //amount to be send
        [SerializeField]
        private TMP_InputField amount;
        //
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void SendPayment_Submit()
        {
            double amountVal = 0f;
            if (!string.IsNullOrEmpty(amount.text))
            {
                amountVal = double.Parse(amount.text);
            }
            responseText.text = "";
            Tegment.Transaction.Send.SendAmount(walletId.text, To.text,amountVal, TegmentSessionHandler.Instance._authToken, SendPaymentCallBack);
        }

        /// <summary>
        /// Callback to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="sendPaymentResponse"></param>
        private void SendPaymentCallBack(RequestException exception, ResponseHelper response, SendResponseFormatter sendPaymentResponse)
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
