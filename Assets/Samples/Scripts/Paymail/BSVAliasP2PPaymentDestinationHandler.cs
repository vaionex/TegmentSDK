using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Paymail
{
    public class BSVAliasP2PPaymentDestinationHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField paymail;
        [SerializeField]
        private TMP_InputField satoshis;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void BSVAliasP2PPaymentDestination_Submit()
        {
            responseText.text = "";

            int satoshisVal = 0;
            if (!string.IsNullOrEmpty(satoshis.text))
            {
                satoshisVal = int.Parse(satoshis.text);
            }

            Tegment.Paymail.BSVAliasP2PPaymentDestination.BSVAliasP2PPayment(paymail.text, satoshisVal, BSVAliasP2PPaymentDestinationResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="bSVAliasP2PPaymentDestinationResponseFormatter"></param>
        private void BSVAliasP2PPaymentDestinationResponseCallBack(RequestException exception, ResponseHelper response, BSVAliasP2PPaymentDestinationResponseFormatter bSVAliasP2PPaymentDestinationResponseFormatter )
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            paymail.text = "";
            satoshis.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
