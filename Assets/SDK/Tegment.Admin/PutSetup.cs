using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class PutSetup
    {
        /// <summary>
        /// Update existing setup
        /// </summary>
        /// <param name="_projectName"></param>
        /// <param name="_type"></param>
        /// <param name="_paymailDomain"></param>
        /// <param name="_newServiceId"></param>
        /// <param name="_apiKey"></param>
        /// <param name="_authDomain"></param>
        /// <param name="_databaseURL"></param>
        /// <param name="_projectId"></param>
        /// <param name="_storageBucket"></param>
        /// <param name="_messagingSenderId"></param>
        /// <param name="_appId"></param>
        /// <param name="_measurementId"></param>
        /// <param name="_organisation"></param>
        /// <param name="_legalForm"></param>
        /// <param name="_governingLaw"></param>
        /// <param name="_mailingAddress"></param>
        /// <param name="_issuerCountry"></param>
        /// <param name="_jurisdiction"></param>
        /// <param name="_email"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        public static void AdminPutSetup(string _projectName, string _type, string _paymailDomain,string _newServiceId,
           string _apiKey, string _authDomain, string _databaseURL, string _projectId, string _storageBucket, string _messagingSenderId,
           string _appId, string _measurementId,
           string _organisation, string _legalForm, string _governingLaw, string _mailingAddress, string _issuerCountry, string _jurisdiction, string _email,
           string _authToken, System.Action<RequestException, ResponseHelper, PutSetupResponseFormatter> callback, bool enableLog = false)
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function AdminPutSetup");
            PutSetupRequestFormatter putSetupRequestFormatter = new PutSetupRequestFormatter();
            putSetupRequestFormatter.projectName = _projectName;
            putSetupRequestFormatter.type = _type;
            putSetupRequestFormatter.paymailDomain = _paymailDomain;
            putSetupRequestFormatter.newServiceId = _newServiceId;

            PutSetupRequestFormatterFirebaseConfig putSetupRequestFormatterFirebaseConfig = new PutSetupRequestFormatterFirebaseConfig();
            putSetupRequestFormatterFirebaseConfig.apiKey = _apiKey;
            putSetupRequestFormatterFirebaseConfig.authDomain = _authDomain;
            putSetupRequestFormatterFirebaseConfig.databaseURL = _databaseURL;
            putSetupRequestFormatterFirebaseConfig.projectId = _projectId;
            putSetupRequestFormatterFirebaseConfig.storageBucket = _storageBucket;
            putSetupRequestFormatterFirebaseConfig.messagingSenderId = _messagingSenderId;
            putSetupRequestFormatterFirebaseConfig.appId = _appId;
            putSetupRequestFormatterFirebaseConfig.measurementId = _measurementId;
            putSetupRequestFormatter.firebaseConfig = putSetupRequestFormatterFirebaseConfig;

            PutSetupRequestFormatterLegel putSetupRequestFormatterLegel = new PutSetupRequestFormatterLegel();
            putSetupRequestFormatterLegel.organisation = _organisation;
            putSetupRequestFormatterLegel.legalForm = _legalForm;
            putSetupRequestFormatterLegel.governingLaw = _governingLaw;
            putSetupRequestFormatterLegel.mailingAddress = _mailingAddress;
            putSetupRequestFormatterLegel.issuerCountry = _issuerCountry;
            putSetupRequestFormatterLegel.jurisdiction = _jurisdiction;
            putSetupRequestFormatterLegel.email = _email;
            putSetupRequestFormatter.legal = putSetupRequestFormatterLegel;


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Setup_Post;

            TegmentClient.Post<PutSetupResponseFormatter>(path, putSetupRequestFormatter, callback);
        }

    }
}
