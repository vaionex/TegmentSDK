using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Logs;

namespace Tegment.Utility {
    public static partial class CurrencyConversion 
    {
        /// <summary>
        /// Convert BSV Satoshis to flat currency
        /// Add a satoshi amount and fiat pair of your choice, e.g. USD, EUR, INR to receive information of the equivalent value.
        /// </summary>
        /// <param name="_satoshis"></param>
        /// <param name="_currency"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void ConvertSatoshiToCurrency(string _satoshis, string _currency, System.Action<RequestException, ResponseHelper, CurrencyConversionResponseFormatter> callback, bool enableLog = false)
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function ConvertSatoshiToCurrency");

            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["satoshis"] = _satoshis;
            TegmentClient.DefaultRequestHeaders["currency"] = _currency;

            string path = PathConstants.baseURL + PathConstants.currencyConversion;
            TegmentClient.Get<CurrencyConversionResponseFormatter>(path, callback);
        }
    }
}
