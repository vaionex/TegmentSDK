using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// this class implements sample that Invoices allow merchants to specify the amount of BSV or Tokens they require to complete a value exchange, such as selling a Product.
    /// </summary>
    public class PaymentRequestV1Handler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField invoiceID;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click Event handler
        /// </summary>
        public void PaymentRequestV1_Submit()
        {
            responseText.text = "";

            Tegment.Transaction.PaymentRequest.GetPaymentRequest(invoiceID.text, PaymentRequestV1TransactionCallBack);
        }

        /// <summary>
        /// Callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="paymentRequestResponse"></param>
        private void PaymentRequestV1TransactionCallBack(RequestException exception, ResponseHelper response, PaymentRequestResponseFormatter paymentRequestResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// Clear the input control and go back to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            invoiceID.text="";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
