using Tegment.ResponseFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Paymail
{
    public static partial class BSVAliasVerifyPubKey
    {
        public static void MatchBSVAliasVerifyPubKey(string _paymail, string _pubKey, System.Action<RequestException, ResponseHelper, BSVAliasVerifyPubKeyResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function MatchBSVAliasVerifyPubKey");

            TegmentClient.EnableLog = enableLog;

            //TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

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
