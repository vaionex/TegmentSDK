using UnityEngine;
using TMPro;
using Tegment.Network;

namespace Tegment.Unity.Samples.Delete
{
    /// <summary>
    /// Delete all wallets
    /// This will delete all Wallets at once
    /// </summary>
    public class DeleteAllWalletsHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void DeleteAllWallets_Submit()
        {
            responseText.text = "";

            Tegment.Delete.DeleteAllWallets.AllWallets(TegmentSessionHandler.Instance._authToken, DeleteAllWalletsCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 2 params here, first is for exceptio is there is any
        /// second is response
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        private void DeleteAllWalletsCallBack(RequestException exception, ResponseHelper response)
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
