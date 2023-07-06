using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using UnityEngine.UI;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// The class implements sample that enables users to pay their invoices that were earlier resolved and put into a standardized format.
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class PayHandler : MonoBehaviour
    {
        //Wallet ID
        [SerializeField]
        private TMP_InputField walletID;
        //URI
        [SerializeField]
        private TMP_InputField URI;
        //Type
        [SerializeField]
        private TMP_InputField _type;
        //Main Protocol
        [SerializeField]
        private TMP_InputField mainProtocol;
        //OutPuts
        [SerializeField]
        private TMP_InputField scripts;
        [SerializeField]
        private TMP_InputField satoshis_Output;
        //Inputs
        [SerializeField]
        private TMP_InputField txId_Input;
        [SerializeField]
        private TMP_InputField vOut_Input;
        [SerializeField]
        private TMP_InputField satoshis_Input;
        [SerializeField]
        private TMP_InputField scriptPubKey_Input;
        [SerializeField]
        private TMP_InputField scriptType_Input;
        [SerializeField]
        private TMP_InputField scriptSig_Input;
        [SerializeField]
        private TMP_InputField network;
        [SerializeField]
        private TMP_InputField paymentUrl;
        [SerializeField]
        private TMP_InputField creationTimeStamp;
        [SerializeField]
        private TMP_InputField expirationTimeStamp;
        [SerializeField]
        private TMP_InputField memo;
        [SerializeField]
        private Toggle isBSV;
        [SerializeField]
        private TMP_InputField peer;
        [SerializeField]
        private TMP_InputField peerData;
        [SerializeField]
        private TMP_InputField peerProtocol;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void PayTransaction_Submit()
        {
            responseText.text = "";

            int satoshi_OutputVal = 0;
            if (!string.IsNullOrEmpty(satoshis_Output.text))
            {
                satoshi_OutputVal = int.Parse(satoshis_Output.text);
            }

            int vout_InputVal = 0;
            if (!string.IsNullOrEmpty(vOut_Input.text))
            {
                vout_InputVal = int.Parse(vOut_Input.text);
            }

            int satoshi_InputVal = 0;
            if (!string.IsNullOrEmpty(satoshis_Input.text))
            {
                satoshi_InputVal = int.Parse(satoshis_Input.text);
            }

            int creationTimeVal = 0;
            if (!string.IsNullOrEmpty(creationTimeStamp.text))
            {
                creationTimeVal = int.Parse(creationTimeStamp.text);
            }
            int expirationTimeVal = 0;
            if (!string.IsNullOrEmpty(expirationTimeStamp.text))
            {
                expirationTimeVal = int.Parse(expirationTimeStamp.text);
            }
            // Prepare output request
            PayOutputRequest[] payOutputRequestArray = new PayOutputRequest[1];
            PayOutputRequest payOutputRequest = new PayOutputRequest();

            payOutputRequest.script = scripts.text;
            payOutputRequest.sathoshis = satoshi_OutputVal;
            payOutputRequestArray[0] = payOutputRequest;

            //Prepare input request
            PayInputRequest[] payInputRequestsArray = new PayInputRequest[1];
            PayInputRequest payInputRequest = new PayInputRequest();
            payInputRequest.txid = txId_Input.text;
            payInputRequest.vout = vout_InputVal;
            payInputRequest.satoshis = satoshi_InputVal;
            payInputRequest.scriptPubKey = scriptPubKey_Input.text;
            payInputRequest.scriptType = scriptType_Input.text;
            payInputRequest.scriptSig = scriptSig_Input.text;
            payInputRequestsArray[0] = payInputRequest;


            Tegment.Transaction.Pay.PayTransaction(URI.text, _type.text, mainProtocol.text, payOutputRequestArray, payInputRequestsArray, network.text,
                paymentUrl.text, creationTimeVal, expirationTimeVal, memo.text, isBSV.isOn.ToString().ToLower(),
                peer.text, peerData.text, peerProtocol.text, walletID.text, TegmentSessionHandler.Instance._authToken, PayTransactionCallBack,true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="PayTransactionResponse"></param>
        private void PayTransactionCallBack(RequestException exception, ResponseHelper response, PayResponseFormatter PayTransactionResponse)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletID.text = "";
            URI.text = "";
            _type.text = "";
            mainProtocol.text = "";
            //OutPuts
            scripts.text = "";
            satoshis_Output.text = "";
            //Inputs
            txId_Input.text = "";
            vOut_Input.text = "";
            satoshis_Input.text = "";
            scriptPubKey_Input.text = "";
            scriptType_Input.text = "";
            scriptSig_Input.text = "";
            network.text = "";
            paymentUrl.text = "";
            creationTimeStamp.text = "";
            expirationTimeStamp.text = "";
            memo.text = "";

            peer.text = "";
            peerData.text = "";
            peerProtocol.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}