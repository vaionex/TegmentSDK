using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;

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
        /// <param name="_currency"></param>
        /// <returns></returns>
        public static APIResponseFormatter<TranspileResponseFormatter> Transpile_sCrypt(bool _force, string _sourceCode, string _currency)
        {
            TranspileRequestFormatter transpileRequestFormatter = new TranspileRequestFormatter();
            transpileRequestFormatter.sourceCode = _sourceCode;


            TegmentClient.DefaultRequestHeaders["force"] = _force.ToString();
           
            APIResponseFormatter<TranspileResponseFormatter> apiResponseFormatter = new APIResponseFormatter<TranspileResponseFormatter>();
            TegmentClient.Post<string>(PathConstants.baseURL + PathConstants.transpile, transpileRequestFormatter).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<TranspileResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<TranspileResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}
