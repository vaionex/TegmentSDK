using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;

namespace Tegment.Unity.Samples.Paymail
{
    /// <summary>
    /// Get  some well known BSVAlias
    /// </summary>
    public class WellKnownBSVHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void WellKnownBSV_Submit()
        {
            responseText.text = "";

            Tegment.Paymail.WellKnownBSVAlias.WellKnownBSVAlliasDetails(WellKnownBSVResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="wellKnownBSVAliasResponseFormatter"></param>
        private void WellKnownBSVResponseCallBack(RequestException exception, ResponseHelper response, WellKnownBSVAliasResponseFormatter wellKnownBSVAliasResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
