using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;


namespace Tegment.Utility
{
    public static partial class PostUtility 
    {
        /// <summary>
        /// Post messages to the Blockchain
        /// The /post function broadcasts array of notes to the blockchain (in B:// protocol format).
        /// </summary>
        /// <param name="_notesData"></param>
        /// <param name="_customToken"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void PostUtil(string[] _notesData, string _customToken,string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, PostUploadResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function PostUpload");

            PostUploadRequestFormatter postUploadRequestFormatter = new PostUploadRequestFormatter();
            PostUploadRequestData postUploadRequestData = new PostUploadRequestData();
            postUploadRequestData.notes = _notesData;

            postUploadRequestFormatter.dataArray = new PostUploadRequestData[1];
            postUploadRequestFormatter.dataArray[0] = postUploadRequestData;


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["custom-token"] = _customToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.post;
            TegmentClient.Post<PostUploadResponseFormatter>(path, postUploadRequestFormatter, callback);
        }
    }
}