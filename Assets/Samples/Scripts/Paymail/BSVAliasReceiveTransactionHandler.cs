using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Paymail
{

    public class BSVAliasReceiveTransactionHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField paymail;
        [SerializeField]
        private TMP_InputField hex;
        [SerializeField]
        private TMP_InputField reference;
        [SerializeField]
        private TMP_InputField sender;
        [SerializeField]
        private TMP_InputField pubKey;
        [SerializeField]
        private TMP_InputField signature;
        [SerializeField]
        private TMP_InputField note;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void BSVAliasReceiveTransaction_Submit()
        {
            responseText.text = "";

            Tegment.Paymail.BSVAliasReceiveTransaction.ReceiveTransaction(paymail.text, hex.text, reference.text, sender.text, pubKey.text, signature.text, note.text, BSVAliasReceiveTransactionResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="bSVAliasReceiveTransactionResponseFormatter"></param>
        private void BSVAliasReceiveTransactionResponseCallBack(RequestException exception, ResponseHelper response, BSVAliasReceiveTransactionResponseFormatter bSVAliasReceiveTransactionResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            paymail.text = "";
            hex.text = "";
            reference.text = "";
            sender.text = "";
            pubKey.text = "";
            signature.text = "";
            note.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
