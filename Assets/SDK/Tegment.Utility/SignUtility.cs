using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;

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
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void SignMessage(string _address, string _derivationPath, string _message, string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, SignUtilityResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function SignMessage");

            SignUtilityRequestFormatter signUtilityRequestFormatter = new SignUtilityRequestFormatter();

            SignUtilityRequestDataArray signUtilityRequestDataArray = new SignUtilityRequestDataArray();
            signUtilityRequestDataArray.address = _address;
            signUtilityRequestDataArray.derivationPath = _derivationPath;
            signUtilityRequestDataArray.message = _message;

            signUtilityRequestFormatter.dataArray = new SignUtilityRequestDataArray[1];
            signUtilityRequestFormatter.dataArray[0] = signUtilityRequestDataArray;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.sign;
            TegmentClient.Post<SignUtilityResponseFormatter>(path, signUtilityRequestFormatter, callback);
        }
    }
}


