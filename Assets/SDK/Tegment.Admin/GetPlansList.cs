using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class GetPlansList 
    {
        /// <summary>
        /// Get List of exisiting plans
        /// </summary>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void AdminGetPlansList(string _authToken, System.Action<RequestException, ResponseHelper, AdminGetPlansListResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function AdminGetPlansList");


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Plans_List;

            TegmentClient.Get<AdminGetPlansListResponseFormatter>(path, callback);
        }
    }
}
