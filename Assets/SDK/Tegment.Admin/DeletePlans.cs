using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class DeletePlans
    {
        /// <summary>
        /// Delete Service Plans
        /// </summary>
        /// <param name="_serviceType"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void DeleteAdminPlans(string _serviceType, string _authToken, System.Action<RequestException, ResponseHelper> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function DeleteAdminPlans");


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Plans_Delete.Replace("{serviceType}", _serviceType);

            TegmentClient.Delete(path, callback);
        }
    }
}