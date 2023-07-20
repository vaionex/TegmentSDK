using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tegment.RequestFormatter
{
    public class SetupRequestFormatter
    {
        public string projectName;
        public string type;
        public string paymailDomain;
        public SetupRequestFormatterFirebaseConfig firebaseConfig;
        public SetupRequestFormatterLegel legal;
    }

    public class SetupRequestFormatterFirebaseConfig
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

    public class SetupRequestFormatterLegel
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

