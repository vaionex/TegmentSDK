using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

namespace Tegment.Transaction
{
    public static partial class ExchangeOffer
    {
        /// <summary>
        /// Creates swap Offer for Exchange Transaction- returns SwapID
        /// This function allows user to create a swap offer object that can be used for the exchange endpoint.
        /// The amount value is the value in satoshis wanted in exchange for the token. Payment field is to add in extra outputs if requested with amount in satoshis
        /// and to for address string
        /// </summary>
        /// <param name="_tokenId"></param>
        /// <param name="_sn"></param>
        /// <param name="_amount"></param>
        /// <param name="_type"></param>
        /// <param name="_exchangeOfferPayment"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        public static void ExchangeOfferTransaction(string _tokenId, int _sn, double _amount,string _type, ExchangeOfferRequestPayment[] _exchangeOfferPayment, string _walletID, string _authToken,System.Action<RequestException, ResponseHelper, ExchangeOfferResponseFormatter> callback)
        {
            ExchangeOfferRequestFormatter exchangeOfferRequestFormatter = new ExchangeOfferRequestFormatter();
            ExchangeOfferRequestDataArray exchangeOfferRequestDataArray = new ExchangeOfferRequestDataArray();
            exchangeOfferRequestDataArray.tokenId = _tokenId;
            exchangeOfferRequestDataArray.sn = _sn;
            exchangeOfferRequestDataArray.amount = _amount;
            exchangeOfferRequestDataArray.type = _type;
            exchangeOfferRequestDataArray.payment = new ExchangeOfferRequestPayment[_exchangeOfferPayment.Length];
            exchangeOfferRequestDataArray.payment=_exchangeOfferPayment;

            exchangeOfferRequestFormatter.dataArray = new ExchangeOfferRequestDataArray[1];
            exchangeOfferRequestFormatter.dataArray[0] = exchangeOfferRequestDataArray;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            TegmentClient.Post<ExchangeOfferResponseFormatter>(PathConstants.baseURL + PathConstants.exchangeOffer, exchangeOfferRequestFormatter, callback);
        }
    }
}
