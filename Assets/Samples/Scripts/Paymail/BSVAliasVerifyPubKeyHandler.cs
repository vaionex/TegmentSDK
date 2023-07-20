using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Paymail
{
    /// <summary>
    /// This sample shows example of implementation of verifying pub key
    /// </summary>
    public class BSVAliasVerifyPubKeyHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField paymail;
        [SerializeField]
        private TMP_InputField pubkey;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void BSVAliasVerifyPubKey_Submit()
        {
            responseText.text = "";

            Tegment.Paymail.BSVAliasVerifyPubKey.MatchBSVAliasVerifyPubKey(paymail.text, pubkey.text, BSVAliasVerifyPubKeyResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="bSVAliasVerifyPubKeyResponseFormatter"></param>
        private void BSVAliasVerifyPubKeyResponseCallBack(RequestException exception, ResponseHelper response, BSVAliasVerifyPubKeyResponseFormatter bSVAliasVerifyPubKeyResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            paymail.text = "";
            pubkey.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}