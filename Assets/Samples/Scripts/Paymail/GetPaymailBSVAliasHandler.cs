using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Paymail
{
    public class GetPaymailBSVAliasHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField paymail;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void GetPaymailBSVAlias_Submit()
        {
            responseText.text = "";

            Tegment.Paymail.Paymail_BSVAlias.GetPaymailBSVAlias(paymail.text, GetPaymailBSVAliasResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="paymailBSVAliasResponseFormatter"></param>
        private void GetPaymailBSVAliasResponseCallBack(RequestException exception, ResponseHelper response, PaymailBSVAliasResponseFormatter paymailBSVAliasResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            paymail.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
