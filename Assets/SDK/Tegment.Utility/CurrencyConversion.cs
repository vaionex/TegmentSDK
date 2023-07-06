using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;

namespace Tegment.Utility {
    public static partial class CurrencyConversion 
    {
        /// <summary>
        /// Convert BSV Satoshis to flat currency
        /// Add a satoshi amount and fiat pair of your choice, e.g. USD, EUR, INR to receive information of the equivalent value.
        /// </summary>
        /// <param name="_satoshis"></param>
        /// <param name="_currency"></param>
        /// <returns></returns>
        public static APIResponseFormatter<CurrencyConversionResponseFormatter> ConvertSatoshiToCurrency(string _satoshis, string _currency)
        {
            TegmentClient.DefaultRequestHeaders["satoshis"] = _satoshis;
            TegmentClient.DefaultRequestHeaders["currency"] = _currency;
            APIResponseFormatter<CurrencyConversionResponseFormatter> apiResponseFormatter = new APIResponseFormatter<CurrencyConversionResponseFormatter>();
            TegmentClient.Get<string>(PathConstants.baseURL + PathConstants.tokenMetrics).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<CurrencyConversionResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<CurrencyConversionResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}
