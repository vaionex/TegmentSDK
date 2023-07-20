using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin {
    public static partial class GetSetupList
    {
        public static void AdminGetSetUpList(string _authToken, System.Action<RequestException, ResponseHelper, GetSetupListResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function AdminGetSetUpList");


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Setup_ServiceIds;

            TegmentClient.Get<GetSetupListResponseFormatter>(path, callback);
        }
    }
}
