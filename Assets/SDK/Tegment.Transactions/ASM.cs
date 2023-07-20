using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class ASM 
    {
        /// <summary>
        /// Upload custom ASM script in a transaction
        /// Thisallows custom scripts to be added as outputs in a transaction
        /// </summary>
        /// <param name="_serviceId"></param>
        /// <param name="_walletId"></param>
        /// <param name="_asm"></param>
        /// <param name="_amount"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void CreateASM(string _serviceId, string _walletId,string _asm, double _amount, string _authToken, System.Action<RequestException, ResponseHelper, ASMResponseFormatter> callback, bool enableLog=false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function CreateASM");
            ASMRequestFormatter asmRequestFormatter = new ASMRequestFormatter();
            ASMRequestDataArray aSMRequestDataArray = new ASMRequestDataArray();
            aSMRequestDataArray.asm = _asm;
            aSMRequestDataArray.amount = _amount;

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["serviceId"] = _serviceId;
            TegmentClient.DefaultRequestHeaders["walletId"] = _walletId;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            string path = PathConstants.baseURL + PathConstants.asm;
            TegmentClient.Post<ASMResponseFormatter>(path, asmRequestFormatter);
        }
    }
}
