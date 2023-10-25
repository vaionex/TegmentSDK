using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Paymail
{
    public class PostBSVAliasAddress : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField paymail;
        [SerializeField]
        private TMP_InputField senderHandle;
        [SerializeField]
        private TMP_InputField dt;
        [SerializeField]
        private TMP_InputField signature;
        [SerializeField]
        private TMP_InputField amount;
        [SerializeField]
        private TMP_InputField purpose;
        [SerializeField]
        private TMP_InputField senderName;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void BSVAliasAddress_Submit()
        {
            responseText.text = "";

            double amountVal = 0;
            if (!string.IsNullOrEmpty(amount.text))
            {
                amountVal = double.Parse(amount.text);
            }

            Tegment.Paymail.BSVAlias_Address.PostBSVAliasAddress(paymail.text,senderHandle.text,dt.text,signature.text,amountVal,purpose.text,senderName.text, PostBSVAliasAddressResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="bSVAlias_AddressResponseFormatter"></param>
        private void PostBSVAliasAddressResponseCallBack(RequestException exception, ResponseHelper response, BSVAlias_AddressResponseFormatter bSVAlias_AddressResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            paymail.text = "";
            senderHandle.text="";
            dt.text="";
            signature.text="";
            amount.text="";
            purpose.text="";
            senderName.text="";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}