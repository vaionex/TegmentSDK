using System;

namespace Tegment.RequestFormatter
{
    public class PutSetupRequestFormatter
    {

        public string projectName;
        public string type;
        public string paymailDomain;
        public string newServiceId;
        public PutSetupRequestFormatterFirebaseConfig firebaseConfig;
        public PutSetupRequestFormatterLegel legal;
    }

    public class PutSetupRequestFormatterFirebaseConfig
    {
        public string apiKey;
        public string authDomain;
        public string databaseURL;
        public string projectId;
        public string storageBucket;
        public string messagingSenderId;
        public string appId;
        public string measurementId;
    }

    public class PutSetupRequestFormatterLegel
    {
        public string organisation;
        public string legalForm;
        public string governingLaw;
        public string mailingAddress;
        public string issuerCountry;
        public string jurisdiction;
        public string email;
    }
}