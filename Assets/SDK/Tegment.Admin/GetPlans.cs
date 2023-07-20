using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;


namespace Tegment.Admin
{
    public static partial class GetPlans
    {
        /// <summary>
        /// Get Plan provided by Service Type
        /// </summary>
        /// <param name="_serviceType"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void AdminGetPlan(string _serviceType, string _authToken, System.Action<RequestException, ResponseHelper, AdminGetPlanResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function AdminGetPlan");


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Plans_Get.Replace("{serviceType}", _serviceType);

            TegmentClient.Get<AdminGetPlanResponseFormatter>(path, callback);
        }
    }
}
