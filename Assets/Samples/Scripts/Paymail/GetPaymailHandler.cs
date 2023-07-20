using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Paymail
{
    //This sample is used to get the details of provided paymail
    public class GetPaymailHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField paymail;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void GetPaymail_Submit()
        {
            responseText.text = "";

            Tegment.Paymail.Paymail_Get.GetPaymailDetails(paymail.text,TegmentSessionHandler.Instance._authToken, GetPaymailResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="paymailGetResponseFormatter"></param>
        private void GetPaymailResponseCallBack(RequestException exception, ResponseHelper response, PaymailGetResponseFormatter paymailGetResponseFormatter)
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
