using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Quota
{
    public static partial class PlanDeactivate
    {
        public static void MakePlanDeactivate(string _serviceId, string _authToken, System.Action<RequestException, ResponseHelper, PlanDeactivateResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function MakePlanDeactivate");


            PlanDeactivateRequestFormatter planDeactivateRequestFormatter = new PlanDeactivateRequestFormatter();
            planDeactivateRequestFormatter.serviceId = _serviceId;


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.plan_Deactivate;
            TegmentClient.Put<PlanDeactivateResponseFormatter>(path, planDeactivateRequestFormatter, callback);
        }
    }
}
