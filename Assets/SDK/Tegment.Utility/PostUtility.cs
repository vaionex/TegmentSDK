using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;

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
        /// <returns></returns>
        public static APIResponseFormatter<PostUploadResponseFormatter> PostUpload(string[] _notesData, string _customToken,string _walletID, string _authToken)
        {
            PostUploadRequestFormatter postUploadRequestFormatter = new PostUploadRequestFormatter();
            PostUploadRequestData postUploadRequestData = new PostUploadRequestData();
            postUploadRequestData.notes = _notesData;

            postUploadRequestFormatter.data = new PostUploadRequestData[1];
            postUploadRequestFormatter.data[0] = postUploadRequestData;

            TegmentClient.DefaultRequestHeaders["custom-token"] = _customToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            APIResponseFormatter<PostUploadResponseFormatter> apiResponseFormatter = new APIResponseFormatter<PostUploadResponseFormatter>();
            TegmentClient.Post<string>(PathConstants.baseURL + PathConstants.post, postUploadRequestFormatter).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<PostUploadResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<PostUploadResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}