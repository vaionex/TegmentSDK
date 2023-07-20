using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;

namespace Tegment.Utility
{
    public static partial class Transpile 
    {
        /// <summary>
        /// Transpile Solidity code to sCrypt
        /// Takes base64 string of solidity code and converts it to sCrypt.
        /// </summary>
        /// <param name="_force"></param>
        /// <param name="_sourceCode"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void Transpile_sCrypt(bool _force, string _sourceCode, System.Action<RequestException, ResponseHelper, TranspileResponseFormatter> callback, bool enableLog = false)
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function Transpile_sCrypt");

            TegmentClient.EnableLog = enableLog;

            TranspileRequestFormatter transpileRequestFormatter = new TranspileRequestFormatter();
            transpileRequestFormatter.sourceCode = _sourceCode;


            TegmentClient.DefaultRequestHeaders["force"] = _force.ToString().ToLower();

            string path = PathConstants.baseURL + PathConstants.transpile;
            TegmentClient.Post<TranspileResponseFormatter>(path, transpileRequestFormatter, callback);
        }
    }
}
