using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// Block chain file upload
    /// The upload sample broadcasts a media file (supplied as URL) to the blockchain (in B:// protocol format).
    /// </summary>
    public class UploadHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TMP_InputField fileURL;
        [SerializeField]
        private TMP_InputField fileName;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void Upload_Submit()
        {
            responseText.text = "";

            Tegment.Utility.UploadUtility.UploadFile(fileURL.text, fileName.text, walletId.text, TegmentSessionHandler.Instance._authToken, UploadResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="uploadUtilityResponseFormatter"></param>
        private void UploadResponseCallBack(RequestException exception, ResponseHelper response, UploadUtilityResponseFormatter uploadUtilityResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            walletId.text = "";
            fileURL.text = "";
            fileName.text = "";
           
            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}
