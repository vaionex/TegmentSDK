using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.SmartContracts
{
    /// <summary>
    /// Smart contract redemption
    /// This sample lets user redeem tokens and thus dissolving the smart contract for satoshis.
    /// </summary>
    public class RedeemHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TMP_InputField amount;
        [SerializeField]
        private TMP_InputField tokenID;
        [SerializeField]
        private TMP_InputField sn;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void Redeem_Submit()
        {

            double amountVal = 0;
            if (!string.IsNullOrEmpty(amount.text))
            {
                amountVal = double.Parse(amount.text);
            }

            int snVal = 0;
            if (!string.IsNullOrEmpty(sn.text))
            {
                snVal = int.Parse(sn.text);
            }
            responseText.text = "";

            Tegment.SmartContracts.Redeem.RedeemToken(amountVal, tokenID.text, snVal, walletId.text, TegmentSessionHandler.Instance._authToken, RedeemCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="redeemResponseFormatter"></param>
        private void RedeemCallBack(RequestException exception, ResponseHelper response, RedeemResponseFormatter redeemResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            amount.text = "";
            tokenID.text = ""; ;
            sn.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
