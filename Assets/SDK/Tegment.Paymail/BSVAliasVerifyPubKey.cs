using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class BSVAliasVerifyPubKey
    {
        /// <summary>
        /// Match BSV Alias Verify PubKey
        /// </summary>
        /// <param name="_paymail"></param>
        /// <param name="_pubKey"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void MatchBSVAliasVerifyPubKey(string _paymail, string _pubKey, System.Action<RequestException, ResponseHelper, BSVAliasVerifyPubKeyResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function MatchBSVAliasVerifyPubKey");

            TegmentClient.EnableLog = enableLog;

            //TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            TestData testData = new TestData();
            testData.data = "";
          
            
            string path = PathConstants.baseURL + PathConstants.bsvalias_Verifypubkey.Replace("{paymailId}", _paymail).Replace("{pubkey}", _pubKey);
      
            TegmentClient.Post<BSVAliasVerifyPubKeyResponseFormatter>(path, testData, callback);
        }
    }
    //adding test class here because unity cann't send empty webform in post, this data is not relevant to function
    public class TestData
    {
        public string data;
    }
}
