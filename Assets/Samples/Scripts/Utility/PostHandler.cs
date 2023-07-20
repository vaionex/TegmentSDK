using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;

namespace Tegment.Unity.Samples.Utility
{
    /// <summary>
    /// Post Messages to blockchain
    /// The post sample broadcasts array of notes to the blockchain (in B:// protocol format).
    /// </summary>
    public class PostHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField customToken;
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TMP_InputField notes;
        [SerializeField]
        private TextMeshProUGUI responseText;

        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void Post_Submit()
        {
            responseText.text = "";

            string[] notesData = notes.text.Split(','); 

            Tegment.Utility.PostUtility.PostUtil(notesData, customToken.text, walletId.text, TegmentSessionHandler.Instance._authToken, PostResponseCallBack, true);
        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="postUploadResponseFormatter"></param>
        private void PostResponseCallBack(RequestException exception, ResponseHelper response, PostUploadResponseFormatter postUploadResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            customToken.text = "";
            walletId.text = "";
            notes.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}