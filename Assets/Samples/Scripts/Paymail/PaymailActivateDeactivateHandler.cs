using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using UnityEngine.UI;

namespace Tegment.Unity.Samples.Paymail
{
    /// <summary>
    /// Activate or Deactivate Paymail
    /// This sample implements function activate or deactivate paymail for given wallet Id
    /// </summary>
    public class PaymailActivateDeactivateHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private Toggle activate;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void PaymailActivate_Submit()
        {
            responseText.text = "";

            Tegment.Paymail.Paymail_Activate.PaymailActivate_DeActivate( activate.isOn, walletId.text, TegmentSessionHandler.Instance._authToken, PaymailActivateResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="paymailActivateResponseFormatter"></param>
        private void PaymailActivateResponseCallBack(RequestException exception, ResponseHelper response, PaymailActivateResponseFormatter paymailActivateResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            activate.isOn= false;

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
