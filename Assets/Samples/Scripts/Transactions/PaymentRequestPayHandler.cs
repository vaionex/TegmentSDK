using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implements a sample to takes invoice and settles it.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class PaymentRequestPayHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField invoiceID;
        [SerializeField]
        private TMP_InputField merchantData;
        [SerializeField]
        private TMP_InputField transaction;
        [SerializeField]
        private TMP_InputField refundTo;
        [SerializeField]
        private TMP_InputField memo;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void PaymentRequestPay_Submit()
        {
            responseText.text = "";

            Tegment.Transaction.PaymentRequestPay.SettleInvoice(invoiceID.text,merchantData.text,transaction.text,refundTo.text, memo.text, PaymentRequestPayTransactionCallBack,true);
        }

        /// <summary>
        /// Callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="paymentRequestPayResponse"></param>
        private void PaymentRequestPayTransactionCallBack(RequestException exception, ResponseHelper response, PaymentRequestPayResponseFormatter paymentRequestPayResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// Clear the input controls and go back to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            invoiceID.text = "";
            merchantData.text="";
            transaction.text="";
            refundTo.text="";
            memo.text = "";
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
