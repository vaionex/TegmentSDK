using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// Sign a message to address string
    /// The sign sample will create a 64bit encoded signature of a message and an address string
    /// </summary>
    public class SignHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TMP_InputField address;
        [SerializeField]
        private TMP_InputField derivationPath;
        [SerializeField]
        private TMP_InputField message;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void Sign_Submit()
        {
            responseText.text = "";

            Tegment.Utility.SignUtility.SignMessage(address.text, derivationPath.text, message.text, walletId.text, TegmentSessionHandler.Instance._authToken, SignResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="signUtilityResponseFormatter"></param>
        private void SignResponseCallBack(RequestException exception, ResponseHelper response, SignUtilityResponseFormatter signUtilityResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            address.text = "";
            derivationPath.text = "";
            message.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
