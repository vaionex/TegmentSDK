using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.SmartContracts
{
    /// <summary>
    /// Get STAS Token details
    /// Insert your STAS tokenId to receive information about it.
    /// </summary>
    public class TokenV2_Handler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField tokenId;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void TokenV2_Submit()
        {
            responseText.text = "";

            Tegment.SmartContracts.TokenV2.GetTokenV2(tokenId.text, Token_V2CallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="tokenV2ResponseFormatter"></param>
        private void Token_V2CallBack(RequestException exception, ResponseHelper response, TokenV2_ResponseFormatter tokenV2ResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            tokenId.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}