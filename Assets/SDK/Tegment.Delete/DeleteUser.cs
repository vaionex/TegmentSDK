using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Delete
{
    public static partial class DeleteUser 
    {
        public static void User(string _authToken, System.Action<RequestException, ResponseHelper > callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function DeleteUser");


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            DeleteEmptyBody deleteEmptyBody = new DeleteEmptyBody();
            deleteEmptyBody.emptybodyText = "";

            string path = PathConstants.baseURL + PathConstants.delete_user;

            RequestHelper requestHelper = new RequestHelper();
            requestHelper.Body = deleteEmptyBody;
            requestHelper.Uri = path;


            TegmentClient.Delete(requestHelper, callback);
        }
    }

    public class DeleteEmptyBody
    {
        public string emptybodyText;
    }
}
