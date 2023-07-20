using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;


namespace Tegment.Utility
{
    public static partial class URI 
    {
        /// <summary>
        /// Resolve Address and paymail alias information
        /// The URI function helps to resolve addresses, paymails and invoices and puts them into a standardized response format.
        /// </summary>
        /// <param name="_URI"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void GETURI(string _URI, System.Action<RequestException, ResponseHelper, URIResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GETURI");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["uri"] = _URI;

            string path = PathConstants.baseURL + PathConstants.URI;
            TegmentClient.Get<URIResponseFormatter>(path,callback);

        }
    }
}