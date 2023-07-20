using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Paymail
{
    /// <summary>
    /// Update paymail address
    /// This sample implements wa to update the paymail address
    /// </summary>
    public class PutPaymailHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TMP_InputField newPaymail;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void PutPaymail_Submit()
        {
            responseText.text = "";

            Tegment.Paymail.Paymail_Put.PutPaymailDetails(walletId.text,newPaymail.text, TegmentSessionHandler.Instance._authToken, PutPaymailResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="paymailPutResponseFormatter"></param>
        private void PutPaymailResponseCallBack(RequestException exception, ResponseHelper response, PaymailPutResponseFormatter paymailPutResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            newPaymail.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
