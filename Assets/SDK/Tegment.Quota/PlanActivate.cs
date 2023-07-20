using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Quota
{
    public static partial class PlanActivate 
    {
        /// <summary>
        /// Activate any plan
        /// </summary>
        /// <param name="_serviceType"></param>
        /// <param name="_chargeFrom"></param>
        /// <param name="_serviceId"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void MakePlanActivate(string _serviceType, string _chargeFrom, string _serviceId, string _authToken, System.Action<RequestException, ResponseHelper, PlanActivateResponseFormattter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function MakePlanActivate");

            PlanActivateRequestFormatter planActivateRequestFormatter = new PlanActivateRequestFormatter();
            planActivateRequestFormatter.serviceId = _serviceId;
            planActivateRequestFormatter.chargeFrom = _chargeFrom;


            TegmentClient.EnableLog = enableLog;
            
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.plan_Activate.Replace("{serviceType", _serviceType);
            TegmentClient.Post<PlanActivateResponseFormattter>(path, planActivateRequestFormatter, callback);
        }
    }
}
