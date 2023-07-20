using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{

    public static partial class PostPlans 
    {
        /// <summary>
        /// Create plans
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
        public static void AdminPostPlans(string _serviceType,double _cost,int _apiCallLimit, double _feeManagerFundPerMonth, string[] _apiList, int _projectLimit, int _serviceFeeManagerFillingLimit, string _authToken, System.Action<RequestException, ResponseHelper, AdminPostPlanResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function AdminPostPlans");


            AdminPostPlanRequestFormatter adminPostPlanRequestFormatter = new AdminPostPlanRequestFormatter();
            adminPostPlanRequestFormatter.serviceType = _serviceType;
            adminPostPlanRequestFormatter.cost = _cost;
            adminPostPlanRequestFormatter.apiCallLimit = _apiCallLimit;
            adminPostPlanRequestFormatter.feeManagerFundPerMonth = _feeManagerFundPerMonth;

            AdminPostPlanRequestFormatter_unavailableApiList adminPostPlanRequestFormatter_UnavailableApiList = new AdminPostPlanRequestFormatter_unavailableApiList();
            adminPostPlanRequestFormatter_UnavailableApiList.apiList = _apiList;

            adminPostPlanRequestFormatter.unavailableApiList = adminPostPlanRequestFormatter_UnavailableApiList;
            adminPostPlanRequestFormatter.projectLimit = _projectLimit;
            adminPostPlanRequestFormatter.serviceFeeManagerFillingLimit = _serviceFeeManagerFillingLimit;

    
            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Plans_Post;

            TegmentClient.Post<AdminPostPlanResponseFormatter>(path, adminPostPlanRequestFormatter, callback);
        }
    }
}
