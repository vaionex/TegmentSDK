using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class PutPlans 
    {
        /// <summary>
        /// Update any plan from given serviceType
        /// </summary>
        /// <param name="_serviceType"></param>
        /// <param name="_cost"></param>
        /// <param name="_apiCallLimit"></param>
        /// <param name="_feeManagerFundPerMonth"></param>
        /// <param name="_apiList"></param>
        /// <param name="_projectLimit"></param>
        /// <param name="_serviceFeeManagerFillingLimit"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void AdminPutPlans(string _serviceType, double _cost, int _apiCallLimit, double _feeManagerFundPerMonth, string[] _apiList, int _projectLimit, int _serviceFeeManagerFillingLimit, string _authToken, System.Action<RequestException, ResponseHelper, AdminPutPlansResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function AdminPutPlans");


            AdminPutPlansRequestFormatter adminPutPlanRequestFormatter = new AdminPutPlansRequestFormatter();
            adminPutPlanRequestFormatter.cost = _cost;
            adminPutPlanRequestFormatter.apiCallLimit = _apiCallLimit;
            adminPutPlanRequestFormatter.feeManagerFundPerMonth = _feeManagerFundPerMonth;

            AdminPutPlanRequestFormatter_unavailableApiList adminPutPlanRequestFormatter_UnavailableApiList = new AdminPutPlanRequestFormatter_unavailableApiList();
            adminPutPlanRequestFormatter_UnavailableApiList.apiList = _apiList;

            adminPutPlanRequestFormatter.unavailableApiList = adminPutPlanRequestFormatter_UnavailableApiList;
            adminPutPlanRequestFormatter.projectLimit = _projectLimit;
            adminPutPlanRequestFormatter.serviceFeeManagerFillingLimit = _serviceFeeManagerFillingLimit;


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["serviceType"] = _serviceType;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Plans_Put.Replace("{serviceType}", _serviceType); ;

            TegmentClient.Post<AdminPutPlansResponseFormatter>(path, adminPutPlanRequestFormatter, callback);
        }
    }
}