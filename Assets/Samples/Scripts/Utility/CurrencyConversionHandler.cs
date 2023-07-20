using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// Convert BSV Satoshis to flat currency
    /// Add a satoshi amount and fiat pair of your choice, e.g. USD, EUR, INR to receive information of the equivalent value.
    /// </summary>
    public class CurrencyConversionHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField satoshis;
        [SerializeField]
        private TMP_InputField currency;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void CurrencyConversion_Submit()
        {
            responseText.text = "";

            Tegment.Utility.CurrencyConversion.ConvertSatoshiToCurrency(satoshis.text, currency.text, CurrencyConversionResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="currencyConversionResponseFormatter"></param>
        private void CurrencyConversionResponseCallBack(RequestException exception, ResponseHelper response, CurrencyConversionResponseFormatter currencyConversionResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            satoshis.text = "";
            currency.text = "";
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}