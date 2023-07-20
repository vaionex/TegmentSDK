using UnityEngine;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using System.Collections;
using System.Threading.Tasks;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class GetSetup 
    {
       /// <summary>
       /// Get Setup from provided Service ID
       /// </summary>
       /// <param name="_serviceID"></param>
       /// <param name="_authToken"></param>
       /// <param name="callback"></param>
       /// <param name="enableLog"></param>
        public static void GetSetupAdmin(string _serviceID, string _authToken, System.Action<RequestException, ResponseHelper, GetSetupResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function GetSetupAdmin");
           

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Setup_Get.Replace("{serviceId}",_serviceID);

            TegmentClient.Get<GetSetupResponseFormatter>(path, callback);
        }
    }
}
