using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;

namespace Tegment.Utility
{
    public static partial class SignUtility
    {
        /// <summary>
        /// Sign a message to an address string
        /// The sign endpoint will create a 64bit encoded signature of a message and an address string
        /// </summary>
        /// <param name="_address"></param>
        /// <param name="_derivationPath"></param>
        /// <param name="_message"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <returns></returns>
        public static APIResponseFormatter<SignUtilityResponseFormatter> SignMessage(string _address, string _derivationPath, string _message, string _walletID, string _authToken)
        {
            SignUtilityRequestFormatter signUtilityRequestFormatter = new SignUtilityRequestFormatter();

            SignUtilityRequestDataArray signUtilityRequestDataArray = new SignUtilityRequestDataArray();
            signUtilityRequestDataArray.address = _address;
            signUtilityRequestDataArray.derivationPath = _derivationPath;
            signUtilityRequestDataArray.message = _message;

            signUtilityRequestFormatter.dataArray = new SignUtilityRequestDataArray[1];
            signUtilityRequestFormatter.dataArray[0] = signUtilityRequestDataArray;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            APIResponseFormatter<SignUtilityResponseFormatter> apiResponseFormatter = new APIResponseFormatter<SignUtilityResponseFormatter>();
            TegmentClient.Post<string>(PathConstants.baseURL + PathConstants.sign, signUtilityRequestFormatter).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<SignUtilityResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<SignUtilityResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }

    }
}


