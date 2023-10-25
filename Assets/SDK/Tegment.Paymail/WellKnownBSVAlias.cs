using UnityEngine;
using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using System.Collections;
using System.Threading.Tasks;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class WellKnownBSVAlias 
    {
        /// <summary>
        /// Well Known BSV Alias Details
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void WellKnownBSVAlliasDetails(System.Action<RequestException, ResponseHelper, WellKnownBSVAliasResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function WellKnownBSVAlliasDetails");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.bsvalias_wellknown;
            TegmentClient.Get<WellKnownBSVAliasResponseFormatter>(path, callback);
        }
    }
}
