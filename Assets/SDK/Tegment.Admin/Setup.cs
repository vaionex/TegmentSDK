using Tegment.ResponseFormatter;
using Tegment.RequestFormatter;
using Tegment.Network;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.Admin
{
    public static partial class Setup 
    {
        /// <summary>
        /// Setup Project
        /// </summary>
        /// <param name="_projectName"></param>
        /// <param name="_type"></param>
        /// <param name="_paymailDomain"></param>
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
        public static void AdminSetup(string _projectName, string _type, string _paymailDomain,
            string _apiKey, string _authDomain, string _databaseURL, string _projectId, string _storageBucket, string _messagingSenderId,
            string _appId, string _measurementId,
            string _organisation, string _legalForm, string _governingLaw, string _mailingAddress, string _issuerCountry, string _jurisdiction, string _email,
            string _authToken, System.Action<RequestException, ResponseHelper, SetupResponseFormatter> callback, bool enableLog = false)
        {

            if (enableLog)
                LogManager.WriteToLog("Request Function AdminSetup");
            SetupRequestFormatter setupRequestFormatter = new SetupRequestFormatter();
            setupRequestFormatter.projectName = _projectName;
            setupRequestFormatter.type = _type;
            setupRequestFormatter.paymailDomain = _paymailDomain;

            SetupRequestFormatterFirebaseConfig setupRequestFormatterFirebaseConfig = new SetupRequestFormatterFirebaseConfig();
            setupRequestFormatterFirebaseConfig.apiKey = _apiKey;
            setupRequestFormatterFirebaseConfig.authDomain = _authDomain;
            setupRequestFormatterFirebaseConfig.databaseURL = _databaseURL;
            setupRequestFormatterFirebaseConfig.projectId = _projectId;
            setupRequestFormatterFirebaseConfig.storageBucket = _storageBucket;
            setupRequestFormatterFirebaseConfig.messagingSenderId = _messagingSenderId;
            setupRequestFormatterFirebaseConfig.appId = _appId;
            setupRequestFormatterFirebaseConfig.measurementId = _measurementId;
            setupRequestFormatter.firebaseConfig = setupRequestFormatterFirebaseConfig;

            SetupRequestFormatterLegel setupRequestFormatterLegel = new SetupRequestFormatterLegel();
            setupRequestFormatterLegel.organisation = _organisation;
            setupRequestFormatterLegel.legalForm = _legalForm;
            setupRequestFormatterLegel.governingLaw = _governingLaw;
            setupRequestFormatterLegel.mailingAddress = _mailingAddress;
            setupRequestFormatterLegel.issuerCountry = _issuerCountry;
            setupRequestFormatterLegel.jurisdiction = _jurisdiction;
            setupRequestFormatterLegel.email = _email;
            setupRequestFormatter.legal = setupRequestFormatterLegel;


            TegmentClient.EnableLog = enableLog;

            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            TegmentClient.DefaultRequestHeaders["Content-Type"] = "application/json";
            TegmentClient.DefaultRequestHeaders["accept"] = "*/*";

            string path = PathConstants.baseURL + PathConstants.admin_Setup_Post;

            TegmentClient.Post<SetupResponseFormatter>(path, setupRequestFormatter, callback);
        }
    }
}
