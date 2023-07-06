using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;

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
        /// <returns></returns>
        public static APIResponseFormatter<UploadUtilityResponseFormatter> UploadFile(string _fileUrl, string _fileName, string _walletID, string _authToken)
        {
            UploadUtilityRequestFormatter uploadUtilityRequestFormatter = new UploadUtilityRequestFormatter();
            uploadUtilityRequestFormatter.fileUrl = _fileUrl;
            uploadUtilityRequestFormatter.fileName = _fileName;


            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            APIResponseFormatter<UploadUtilityResponseFormatter> apiResponseFormatter = new APIResponseFormatter<UploadUtilityResponseFormatter>();
            TegmentClient.Post<string>(PathConstants.baseURL + PathConstants.upload, uploadUtilityRequestFormatter).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<UploadUtilityResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<UploadUtilityResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}