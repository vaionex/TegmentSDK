using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{

    /// <summary>
    /// This class implements sample to allows user to create a swap offer object that can be used for the exchange class.
    /// The amount value is the value in satoshis wanted in exchange for the token.
    /// Payment field is to add in extra outputs if requested with amount in satoshis and to for address string.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class ExchangeOfferHandler : MonoBehaviour
    {
        //Wallet Id
        [SerializeField]
        private TMP_InputField walletId;
        //Token ID
        [SerializeField]
        private TMP_InputField tokenId;
        //SN
        [SerializeField]
        private TMP_InputField sn;
        //Amount
        [SerializeField]
        private TMP_InputField amount;
        //Type
        [SerializeField]
        private TMP_InputField type;
        //Offer Amount
        [SerializeField]
        private TMP_InputField offer_Amount;
        //Offer To
        [SerializeField]
        private TMP_InputField offer_To;
        //Response Text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click handler
        /// </summary>
        public void ExchangeOfferTransaction_Submit()
        {
            double amountVal = 0f;
            if (!string.IsNullOrEmpty(amount.text))
            {
                amountVal = double.Parse(amount.text);
            }
            double offerAmountVal = 0f;
            if (!string.IsNullOrEmpty(offer_Amount.text))
            {
                offerAmountVal = double.Parse(offer_Amount.text);
            }
            int snVal = 0;
            if (!string.IsNullOrEmpty(sn.text))
            {
                snVal = int.Parse(sn.text);
            }
            ExchangeOfferRequestPayment[] exchangeOfferRequestPayments_array = new ExchangeOfferRequestPayment[1];
            ExchangeOfferRequestPayment exchangeOfferRequestPayment = new ExchangeOfferRequestPayment();
            exchangeOfferRequestPayment.amount = offerAmountVal;
            exchangeOfferRequestPayment.to = offer_To.text;
            exchangeOfferRequestPayments_array[0] = exchangeOfferRequestPayment;

            responseText.text = "";
            Tegment.Transaction.ExchangeOffer.ExchangeOfferTransaction(tokenId.text,snVal,amountVal,type.text,exchangeOfferRequestPayments_array, walletId.text,TegmentSessionHandler.Instance._authToken, ExchangeOfferTransactionCallBack,true);
        }

        /// <summary>
        /// Callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="ExchangeOfferTransactionResponse"></param>
        private void ExchangeOfferTransactionCallBack(RequestException exception, ResponseHelper response, ExchangeOfferResponseFormatter ExchangeOfferTransactionResponse)
        {
            responseText.text = response.Text;
        }

        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            tokenId.text="";
            sn.text = ""; ;
            amount.text= "";
            type.text="";
            offer_Amount.text="";
            offer_To.text="";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}