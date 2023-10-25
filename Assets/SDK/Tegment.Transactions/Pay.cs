using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Transaction
{
    public static partial class Pay
    {
        /// <summary>
        /// Pay an Invoice request
        /// The endpoint enables users to pay their invoices that were earlier resolved and put into a standardized format by the /URI endpoint.
        /// </summary>
        /// <param name="_uri"></param>
        /// <param name="_type"></param>
        /// <param name="_mainProtocol"></param>
        /// <param name="_Outputs"></param>
        /// <param name="_Inputs"></param>
        /// <param name="_network"></param>
        /// <param name="_paymentURL"></param>
        /// <param name="_creationTimeStamp"></param>
        /// <param name="_expirationTimeStamp"></param>
        /// <param name="_memo"></param>
        /// <param name="_isBSV"></param>
        /// <param name="_peer"></param>
        /// <param name="_peerData"></param>
        /// <param name="_peerProtocol"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void PayTransaction(string _uri, string _type, string _mainProtocol, PayOutputRequest[] _Outputs,
            PayInputRequest[] _Inputs,string _network, string _paymentURL,int _creationTimeStamp, int _expirationTimeStamp,string _memo,
            string _isBSV,string _peer, string _peerData, string _peerProtocol, string _walletID, string _authToken,
            System.Action<RequestException, ResponseHelper, PayResponseFormatter> callback, bool enableLog=false, string _serviceId = "")
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function PayTransaction");

            PayRequestFormatter payRequestFormatter = new PayRequestFormatter();
            payRequestFormatter.uri = _uri;
            payRequestFormatter.type = _type;
            payRequestFormatter.mainProtocol = _mainProtocol;
            payRequestFormatter.outputs =_Outputs;
            payRequestFormatter.inputs = _Inputs;
            payRequestFormatter.network = _network;
            payRequestFormatter.paymentUrl = _paymentURL;
            payRequestFormatter.creationTimeStamp = _creationTimeStamp;
            payRequestFormatter.expirationTimeStamp = _expirationTimeStamp;
            payRequestFormatter.memo = _memo;
            payRequestFormatter.isBSV = _isBSV;
            payRequestFormatter.peer = _peer;
            payRequestFormatter.peerData = _peerData;
            payRequestFormatter.peerProtocol = _peerProtocol;

            TegmentClient.EnableLog = enableLog;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.pay;
            TegmentClient.Post<PayResponseFormatter>(path, payRequestFormatter, callback);
        }
    }
}
