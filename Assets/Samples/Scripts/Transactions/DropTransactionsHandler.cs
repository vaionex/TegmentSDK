using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implements a sample to withdraw coins from private keys
    /// The drop Transaction allows users to transfer coins (BSV or Token) from a PrivateKey.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class DropTransactionsHandler : MonoBehaviour
    {
        // secret key
        [SerializeField]
        private TMP_InputField secretKey;
        //Service ID
        [SerializeField]
        private TMP_InputField serviceId;
        //Private key
        [SerializeField]
        private TMP_InputField privateKey;
        //Wallet address or paymail
        [SerializeField]
        private TMP_InputField to;
        // Amount bsv
        [SerializeField]
        private TMP_InputField amount;
        //notes if any
        [SerializeField]
        private TMP_InputField notes;
        //Token id
        [SerializeField]
        private TMP_InputField tokenId;
        //SN
        [SerializeField]
        private TMP_InputField sn;
        //Response text
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click handler
        /// </summary>
        public void DropTransaction_Submit()
        {
            double amountVal = 0f;
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
            Tegment.Transaction.Drop.DropTransaction(secretKey.text,serviceId.text,privateKey.text, to.text, amountVal,notes.text,tokenId.text,snVal,TegmentSessionHandler.Instance._authToken, DropTransactionCallBack,true);
        }
        /// <summary>
        /// call back function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="dropTransactionResponse"></param>
        private void DropTransactionCallBack(RequestException exception, ResponseHelper response, DropResponseFormatter dropTransactionResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            secretKey.text = "";
            serviceId.text = "";
            privateKey.text = "";
            to.text = "";
            amount.text = "";
            notes.text = "";
            tokenId.text = "";
            sn.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
