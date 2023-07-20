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
        public static void WellKnownBSVAlliasDetails(System.Action<RequestException, ResponseHelper, WellKnownBSVAliasResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function WellKnownBSVAlliasDetails");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.bsvalias_wellknown;
            TegmentClient.Get<WellKnownBSVAliasResponseFormatter>(path, callback);
        }
    }
}
