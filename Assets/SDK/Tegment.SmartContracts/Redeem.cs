using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.SmartContracts
{
    public static partial class Redeem 
    {
        /// <summary>
        /// Smart contract redemption
        /// This function lets user redeem tokens and thus dissolving the smart contract for satoshis.
        /// </summary>
        /// <param name="_amount"></param>
        /// <param name="_tokenID"></param>
        /// <param name="_sn"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <returns></returns>
        public static void RedeemToken(double _amount, string _tokenID, int _sn, string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, RedeemResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function RedeemToken");

            //Add Request Class Data
            RedeemRequestFormatter redeemRequestFormatter = new RedeemRequestFormatter();
            redeemRequestFormatter.dataArray = new RedeemRequestDataArray[1];
            RedeemRequestDataArray redeemRequestDataArray = new RedeemRequestDataArray();
            redeemRequestDataArray.amount = _amount;
            redeemRequestDataArray.tokenId = _tokenID;
            redeemRequestDataArray.sn = _sn;
            redeemRequestFormatter.dataArray[0] = redeemRequestDataArray;
            //Request Class Data added
            //
            //Logging
            TegmentClient.EnableLog = enableLog;
            //Now Add headers
           
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.redeem;
            TegmentClient.Post<RedeemResponseFormatter>(path, redeemRequestFormatter, callback);
        }
    }
}
