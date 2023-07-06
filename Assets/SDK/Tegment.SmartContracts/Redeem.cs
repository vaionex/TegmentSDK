using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

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
        public static APIResponseFormatter<RedeemResponseFormatter> RedeemToken(double _amount, string _tokenID, int _sn, string _walletID, string _authToken)
        {

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
            //Now Add headers
           
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;


            APIResponseFormatter<RedeemResponseFormatter> apiResponseFormatter = new APIResponseFormatter<RedeemResponseFormatter>();
            TegmentClient.Post<string>(PathConstants.baseURL + PathConstants.redeem, redeemRequestFormatter).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<RedeemResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<RedeemResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}
