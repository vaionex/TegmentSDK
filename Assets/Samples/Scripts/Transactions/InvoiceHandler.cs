using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// this class implements a sample that create an invoice to receive payments for a merchant product.
    /// </summary>
    public class InvoiceHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField Type;
        [SerializeField]
        private TMP_InputField Amount;
        [SerializeField]
        private TMP_InputField Address;
        [SerializeField]
        private TMP_InputField Description;
        [SerializeField]
        private TMP_InputField ExpirationInMinutes;
        [SerializeField]
        private TMP_InputField Memo;
        [SerializeField]
        private TMP_InputField MerchantData;
        [SerializeField]
        private TMP_InputField Amount_Native;
        [SerializeField]
        private TMP_InputField To_Native;
        [SerializeField]
        private TMP_InputField TokenAmount;
        [SerializeField]
        private TMP_InputField TokenRecipent;
        [SerializeField]
        private TMP_InputField TokenId;
        [SerializeField]
        private TMP_InputField ModeID;
        [SerializeField]
        private TMP_InputField Name_Benificiary;
        [SerializeField]
        private TMP_InputField Email_Benificiary;
        [SerializeField]
        private TMP_InputField Address_Benificiary;
        [SerializeField]
        private TMP_InputField PaymentReference_Benificiary;
        [SerializeField]
        private TextMeshProUGUI responseText;


        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void InvoiceTransaction_Submit()
        {
            responseText.text = "";

            double amountVal = 0f;
            if (!string.IsNullOrEmpty(Amount.text))
            {
                amountVal = double.Parse(Amount.text);
            }
            double amountVal_Native = 0f;
            if (!string.IsNullOrEmpty(Amount_Native.text))
            {
                amountVal_Native = double.Parse(Amount_Native.text);
            }

            int expirationTimeVal = 0;
            if (!string.IsNullOrEmpty(ExpirationInMinutes.text))
            {
                expirationTimeVal = int.Parse(ExpirationInMinutes.text);
            }

            int tokenAmountVal = 0;
            if (!string.IsNullOrEmpty(TokenAmount.text))
            {
                tokenAmountVal = int.Parse(TokenAmount.text);
            }


            // Prepare requests
            InvoiceRequestNativeTransactions invoiceRequestNativeTransactions = new InvoiceRequestNativeTransactions();
            invoiceRequestNativeTransactions.amount = amountVal_Native;
            invoiceRequestNativeTransactions.to = To_Native.text;



            InvoiceRequestStasTransactions invoiceRequestStasTransactions = new InvoiceRequestStasTransactions();
            invoiceRequestStasTransactions.tokenAmount = tokenAmountVal;
            invoiceRequestStasTransactions.tokenRecipient = TokenRecipent.text;
            invoiceRequestStasTransactions.tokenId = TokenId.text;


            InvoiceRequestTransactions[] invoiceRequestTransactionsArray = new InvoiceRequestTransactions[1];
            InvoiceRequestTransactions invoiceRequestTransactions = new InvoiceRequestTransactions();
            invoiceRequestTransactions.native = invoiceRequestNativeTransactions;
            invoiceRequestTransactions.stas = invoiceRequestStasTransactions;
            invoiceRequestTransactionsArray[0] = invoiceRequestTransactions;


            InvoiceRequestPaymentOptions invoiceRequestPaymentOptions = new InvoiceRequestPaymentOptions();
            invoiceRequestPaymentOptions.transactions = invoiceRequestTransactionsArray;

            InvoiceRequestPaymentOptions[] invoiceRequestPaymentOptionsArray = new InvoiceRequestPaymentOptions[1];
            invoiceRequestPaymentOptionsArray[0] = invoiceRequestPaymentOptions;


            InvoiceRequestBenificiary invoiceRequestBenificiary = new InvoiceRequestBenificiary();
            invoiceRequestBenificiary.name = Name_Benificiary.text;
            invoiceRequestBenificiary.email = Email_Benificiary.text;
            invoiceRequestBenificiary.address = Address_Benificiary.text;



            Tegment.Transaction.Invoice.CreateInvoice(Type.text, amountVal, Address.text, Description.text, expirationTimeVal, Memo.text, MerchantData.text, invoiceRequestPaymentOptionsArray, ModeID.text, invoiceRequestBenificiary,
                  TegmentSessionHandler.Instance._authToken, InvoiceTransactionCallBack);
        }

        /// <summary>
        /// Callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="invoiceTransactionResponse"></param>
        private void InvoiceTransactionCallBack(RequestException exception, ResponseHelper response, InvoiceResponseFormatter invoiceTransactionResponse)
        {
            responseText.text = response.Text;
        }

        /// <summary>
        /// Clear all the inputs and go back to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            Type.text = "";
            Amount.text = "";
            Address.text = "";
            Description.text = "";
            ExpirationInMinutes.text = "";
            Memo.text = "";
            MerchantData.text = "";
            Amount_Native.text = "";
            To_Native.text = "";
            TokenAmount.text = "";
            TokenRecipent.text = "";
            TokenId.text = "";
            ModeID.text = "";
            Name_Benificiary.text = "";
            Email_Benificiary.text = "";
            Address_Benificiary.text = "";
            PaymentReference_Benificiary.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}