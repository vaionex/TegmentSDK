using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Quota
{
    public static partial class PlanQuota 
    {
        /// <summary>
        /// Put a plan
        /// </summary>
        /// <param name="_serviceType"></param>
        /// <param name="_serviceId"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void PutPlan(string _serviceType, string _serviceId, string _authToken, System.Action<RequestException, ResponseHelper, PlanQuotaResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function PutPlan");

            PlanQuotaRequestFormatter planQuotaRequestFormatter = new PlanQuotaRequestFormatter();
            planQuotaRequestFormatter.serviceId = _serviceId;
            planQuotaRequestFormatter.serviceType = _serviceType;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.quota;
            TegmentClient.Put<PlanQuotaResponseFormatter>(path, planQuotaRequestFormatter, callback);
        }
    }
}
