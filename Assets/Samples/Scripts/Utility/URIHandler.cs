using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// Resolve Address and paymail alas information
    /// The URI Sample helps developers to resolve addresses, paymails and invoices and puts them into a standardized response format.
    /// </summary>
    public class URIHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _uri;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void URI_Submit()
        {
            responseText.text = "";

            Tegment.Utility.URI.GETURI(_uri.text, URIResponseCallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="uriResponseFormatter"></param>
        private void URIResponseCallBack(RequestException exception, ResponseHelper response, URIResponseFormatter uriResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            _uri.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}