using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;

namespace Tegment.Utility
{

    public static partial class CompileUtility
    {
        /// <summary>
        /// Compile sCrypt code to bitcoin script
        /// Takes base64 string of sCrypt code and converts it to Bitcoin Script.
        /// </summary>
        /// <param name="_sourceCode"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void Compile_sCrypt(string _sourceCode, System.Action<RequestException, ResponseHelper, CompileResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function Compile_sCrypt");

            TegmentClient.EnableLog = enableLog;

            CompileRequestFormatter compileRequestFormatter = new CompileRequestFormatter();
            compileRequestFormatter.sourceCode = _sourceCode;


            string path = PathConstants.baseURL + PathConstants.compile;
            TegmentClient.Post<CompileResponseFormatter>(path, compileRequestFormatter, callback);
        }
    }
}
