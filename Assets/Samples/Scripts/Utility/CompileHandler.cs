using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// Compile sCrypt code to bitcoins script
    /// Takes base64 string of sCrypt code and converts it to Bitcoin Script.
    /// </summary>
    public class CompileHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField sourceCode;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void Compile_Submit()
        {
            responseText.text = "";

            Tegment.Utility.CompileUtility.Compile_sCrypt(sourceCode.text, CompileResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="compileResponseFormatter"></param>
        private void CompileResponseCallBack(RequestException exception, ResponseHelper response, CompileResponseFormatter compileResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            sourceCode.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
