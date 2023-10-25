using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class Inspect
    {
        /// <summary>
        /// Inspect an atomic swapOffer
        /// This allows users to inspect an atomic swap hex to verify the validity of the offer.
        /// </summary>
        /// <param name="_swapHex"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void InspectTransaction(string _swapHex,string _authToken, System.Action<RequestException, ResponseHelper, InspectResponseFormatter> callback, bool enableLog=false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function InspectTransaction");

            InspectRequestFormatter inspectRequestFormatter = new InspectRequestFormatter();
            InspectRequestDataArray inspectRequestDataArray = new InspectRequestDataArray();
            inspectRequestDataArray.swapHex = _swapHex;

            inspectRequestFormatter.dataArray = new InspectRequestDataArray[1];
            inspectRequestFormatter.dataArray[0] = inspectRequestDataArray;

            TegmentClient.EnableLog = enableLog;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.inspect;
            TegmentClient.Post<InspectResponseFormatter>(path, inspectRequestFormatter,callback);
        }
    }
}
