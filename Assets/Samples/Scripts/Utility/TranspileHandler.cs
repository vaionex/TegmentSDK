using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine.UI;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// transpile solidity code sCrypt
    /// Takes base64 string of solidity code and converts it to sCrypt.
    /// </summary>
    public class TranspileHandler : MonoBehaviour
    {
        [SerializeField]
        private Toggle force;
        [SerializeField]
        private TMP_InputField sourceCode;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void Transpile_Submit()
        {
            responseText.text = "";

            Tegment.Utility.Transpile.Transpile_sCrypt(force.isOn, sourceCode.text, TranspileResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="transpileResponseFormatter"></param>
        private void TranspileResponseCallBack(RequestException exception, ResponseHelper response, TranspileResponseFormatter transpileResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            force.isOn = false;
            sourceCode.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}