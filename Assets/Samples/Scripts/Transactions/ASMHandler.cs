using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Transactions
{
    /// <summary>
    /// This class implements a sample to upload custom ASM script in a transaction
    /// Thisallows custom scripts to be added as outputs in a transaction
    /// To disable logging, set the last param to false on SDK call
    /// </summary>
    public class ASMHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField serviceID;
        [SerializeField]
        private TMP_InputField walletID;
        [SerializeField]
        private TMP_InputField ASM;
        [SerializeField]
        private TMP_InputField amount;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click handler
        /// </summary>
        public void PaymentRequestPay_Submit()
        {
            responseText.text = "";
            double amountVal = 0;
            if (!string.IsNullOrEmpty(amount.text))
            {
                amountVal = double.Parse(amount.text);
            }

            Tegment.Transaction.ASM.CreateASM(serviceID.text,walletID.text,ASM.text,amountVal, TegmentSessionHandler.Instance._authToken, asmRequestCallBack,true);
        }

        /// <summary>
        /// Callback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="asmResponseFormatter"></param>
        private void asmRequestCallBack(RequestException exception, ResponseHelper response, ASMResponseFormatter asmResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            serviceID.text="";
            walletID.text="";
            ASM.text="";
            amount.text="";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}