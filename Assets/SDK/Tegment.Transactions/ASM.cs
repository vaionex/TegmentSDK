using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

namespace Tegment.Transaction
{
    public static partial class ASM 
    {
        /// <summary>
        /// Upload custom ASM script in a transaction
        /// Thisallows custom scripts to be added as outputs in a transaction
        /// </summary>
        /// <param name="_asm"></param>
        /// <param name="_amount"></param>
        /// <param name="_authToken"></param>
        /// <returns></returns>
        public static void CreateASM(string _serviceId, string _walletId,string _asm, double _amount, string _authToken, System.Action<RequestException, ResponseHelper, ASMResponseFormatter> callback)
        {
            ASMRequestFormatter asmRequestFormatter = new ASMRequestFormatter();
            ASMRequestDataArray aSMRequestDataArray = new ASMRequestDataArray();
            aSMRequestDataArray.asm = _asm;
            aSMRequestDataArray.amount = _amount;

            TegmentClient.DefaultRequestHeaders["serviceId"] = _serviceId;
            TegmentClient.DefaultRequestHeaders["walletId"] = _walletId;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;

            TegmentClient.Post<ASMResponseFormatter>(PathConstants.baseURL + PathConstants.asm, asmRequestFormatter);
        }
    }
}
