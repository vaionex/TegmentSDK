using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class Offer
    {
        /// <summary>
        /// Create an Atomic Swap
        /// This function allows user to create a swap offer. For token to BSV swap use tokenId,
        /// amount(number of tokens) and sn(optional serial number if NFT) and wantedAmount in BSV value (decimal).
        /// For token to token swap use wantedAmount(wanted number of tokens), wantedTokenId and wantedSn(optional serial number if NFT),
        /// can also instead use wantedScript using a token script hex value instead of wantedTokenId and wantedSn
        /// </summary>
        /// <param name="_sn"></param>
        /// <param name="_tokenId"></param>
        /// <param name="_amount"></param>
        /// <param name="_wantedAmount"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void OfferTransaction(int _sn, string _tokenId, double _amount, double _wantedAmount,string _walletID, string _authToken, System.Action<RequestException, ResponseHelper, OfferResponseFormatter> callback, bool enableLog=false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function OfferTransaction");

            OfferRequestFormatter offerRequestFormatter = new OfferRequestFormatter();
            OfferRequestDataArray offerRequestDataArray = new OfferRequestDataArray();
            offerRequestDataArray.sn = _sn;
            offerRequestDataArray.tokenId= _tokenId;
            offerRequestDataArray.amount = _amount;
            offerRequestDataArray.wantedAmount = _wantedAmount;

            offerRequestFormatter.dataArray = new OfferRequestDataArray[1];
            offerRequestFormatter.dataArray[0] = offerRequestDataArray;

            TegmentClient.EnableLog = enableLog;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.offer;
            TegmentClient.Post<OfferResponseFormatter>(path, offerRequestFormatter, callback);
        }
    }
}
