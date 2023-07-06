using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// Create an Atomic Swap
    /// This class implements a sample to allows user to create a swap offer. For token to BSV swap use tokenId,
    /// amount(number of tokens) and sn(optional serial number if NFT) and wantedAmount in BSV value (decimal).
    /// For token to token swap use wantedAmount(wanted number of tokens), wantedTokenId and wantedSn(optional serial number if NFT),
    /// can also instead use wantedScript using a token script hex value instead of wantedTokenId and wantedSn
    /// </summary>
    public class OfferTransactionsHandler : MonoBehaviour
    {
        //Wallet Id 
        [SerializeField]
        private TMP_InputField walletId;
        //amount to offer
        [SerializeField]
        private TMP_InputField amount;
        //Wanted amount
        [SerializeField]
        private TMP_InputField wantedAmount;

        ///SN
        [SerializeField]
        private TMP_InputField sn;
        //TokenID
        [SerializeField]
        private TMP_InputField tokenId;
        //Response Text
        [SerializeField]
        private TextMeshProUGUI responseText;


        /// <summary>
        /// Submit button click handler
        /// </summary>
        public void OfferTransaction_Submit()
        {
            double amountVal = 0f;
            if (!string.IsNullOrEmpty(amount.text))
            {
                amountVal = double.Parse(amount.text);
            }
            double wantedAmountVal = 0f;
            if (!string.IsNullOrEmpty(wantedAmount.text))
            {
                wantedAmountVal = double.Parse(wantedAmount.text);
            }
            int snVal = 0;
            if (!string.IsNullOrEmpty(sn.text))
            {
                snVal = int.Parse(sn.text);
            }
            responseText.text = "";
            Tegment.Transaction.Offer.OfferTransaction(snVal,tokenId.text, amountVal, wantedAmountVal,walletId.text, TegmentSessionHandler.Instance._authToken, OfferTransactionCallBack);
        }

        /// <summary>
        /// callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="offerTransactionResponse"></param>
        private void OfferTransactionCallBack(RequestException exception, ResponseHelper response, OfferResponseFormatter offerTransactionResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            wantedAmount.text = "";
            amount.text = "";
            tokenId.text = "";
            sn.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}