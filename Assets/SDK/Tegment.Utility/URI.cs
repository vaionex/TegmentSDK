using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;


namespace Tegment.Utility
{
    public static partial class URI 
    {
        /// <summary>
        /// Resolve Address and paymail alias information
        /// The URI function helps to resolve addresses, paymails and invoices and puts them into a standardized response format.
        /// </summary>
        /// <param name="_URI"></param>
        /// <returns></returns>
        public static APIResponseFormatter<URIResponseFormatter> GETURI(string _URI)
        {
            TegmentClient.DefaultRequestHeaders["uri"] = _URI;
            APIResponseFormatter<URIResponseFormatter> apiResponseFormatter = new APIResponseFormatter<URIResponseFormatter>();
            TegmentClient.Get<string>(PathConstants.baseURL + PathConstants.URI).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<URIResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<URIResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}