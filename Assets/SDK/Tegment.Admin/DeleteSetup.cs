using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class DeleteSetup 
    {
        /// <summary>
        /// Delete Setup from provided serviceID
        /// </summary>
        /// <param name="_serviceId"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void DeleteAdminSetup(string _serviceId, string _authToken, System.Action<RequestException, ResponseHelper> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function DeleteAdminSetup");

          
            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
           
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Setup_Delete.Replace("{serviceId}", _serviceId);

            TegmentClient.Delete(path, callback);
        }
    }
}
