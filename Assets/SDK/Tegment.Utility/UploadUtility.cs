using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;


namespace Tegment.Utility
{
    public static partial class UploadUtility 
    {
        /// <summary>
        /// Blockchaon File upload
        /// The /upload broadcasts a media file (supplied as URL) to the blockchain (in B:// protocol format).
        /// </summary>
        /// <param name="_fileUrl"></param>
        /// <param name="_fileName"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void UploadFile(string _fileUrl, string _fileName, string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, UploadUtilityResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function GetauthToken");


            UploadUtilityRequestFormatter uploadUtilityRequestFormatter = new UploadUtilityRequestFormatter();
            uploadUtilityRequestFormatter.fileUrl = _fileUrl;
            uploadUtilityRequestFormatter.fileName = _fileName;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.upload;
            TegmentClient.Post<UploadUtilityResponseFormatter>(path, uploadUtilityRequestFormatter, callback);
        }
    }
}