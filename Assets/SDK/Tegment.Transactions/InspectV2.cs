using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class InspectV2 
    {
        /// <summary>
        /// Inspect an atomic swapOffer
        /// This allows users to inspect an atomic swap hex to verify the validity of the offer.
        /// </summary>
        /// <param name="_swapHex"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void InspectTransactionV2(string _swapHex, string _authToken, System.Action<RequestException, ResponseHelper, InspectV2ResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function InspectTransactionV2");

            InspectRequestFormatter inspectRequestFormatter = new InspectRequestFormatter();
            InspectRequestDataArray inspectRequestDataArray = new InspectRequestDataArray();
            inspectRequestDataArray.swapHex = _swapHex;

            inspectRequestFormatter.dataArray = new InspectRequestDataArray[1];
            inspectRequestFormatter.dataArray[0] = inspectRequestDataArray;

            TegmentClient.EnableLog = enableLog;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            string path = PathConstants.baseURL + PathConstants.inspect;
            TegmentClient.Post<InspectV2ResponseFormatter>(path, inspectRequestFormatter, callback);
        }
    }
}