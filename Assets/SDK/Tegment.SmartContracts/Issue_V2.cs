using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;
using Tegment.Logs;

namespace Tegment.SmartContracts
{
    public static partial class Issue_V2
    {
        /// <summary>
        /// Mint a token
        /// Mint a token with given specifications (can be both token or NFT)
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_symbol"></param>
        /// <param name="_description"></param>
        /// <param name="_image"></param>
        /// <param name="_tokenSupply"></param>
        /// <param name="_decimals"></param>
        /// <param name="_satsPerToken"></param>
        /// <param name="_terms"></param>
        /// <param name="_licenceId"></param>
        /// <param name="_organisation"></param>
        /// <param name="_legalForm"></param>
        /// <param name="_governingLaw"></param>
        /// <param name="_issuerCountry"></param>
        /// <param name="_jurisdiction"></param>
        /// <param name="_email"></param>
        /// <param name="_schemaId"></param>
        /// <param name="_website"></param>
        /// <param name="_legalTerms"></param>
        /// <param name="_URI"></param>
        /// <param name="_type_media"></param>
        /// <param name="_altURI"></param>
        /// <param name="_data"></param>
        /// <param name="_protocol"></param>
        /// <param name="_reminting"></param>
        /// <param name="_type"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <param name="callback"></param>
        /// <param name="enableLog"></param>
        /// <param name="_serviceId"></param>
        public static void MintIssueV2(string _name, string _symbol,
             string _description, string _image, int _tokenSupply, int _decimals, int _satsPerToken, string _terms, string _licenceId,
             string _organisation, string _legalForm, string _governingLaw, string _issuerCountry, string _jurisdiction, string _email,
             string _schemaId, string _website, string _legalTerms, string _URI, string _type_media, string _altURI, object _data,
             string _protocol, bool _reminting, string _type, string _walletID, string _authToken,
             System.Action<RequestException, ResponseHelper, IssueV2ResponseFormatter> callback, bool enableLog = false, string _serviceId = "")
        {
            if (enableLog)
                LogManager.WriteToLog("Request Function MintIssueV2");

            //Add Request Class Data
            IssueV2RequestFormatter issueV2RequestFormatter = new IssueV2RequestFormatter();

            issueV2RequestFormatter.name = _name;
            issueV2RequestFormatter.symbol = _symbol;
            issueV2RequestFormatter.description = _description;
            issueV2RequestFormatter.image = _image;
            issueV2RequestFormatter.tokenSupply = _tokenSupply;
            issueV2RequestFormatter.decimals = _decimals;
            issueV2RequestFormatter.satsPerToken = _satsPerToken;

            issueV2RequestFormatter.data = _data;



            IssueV2RequestProperties_Legal issueV2RequestProperties_Legal = new IssueV2RequestProperties_Legal();
            issueV2RequestProperties_Legal.terms = _legalTerms;
            issueV2RequestProperties_Legal.licenceId = _licenceId;

            IssueV2RequestProperties_Issuer issueV2RequestProperties_Issuer = new IssueV2RequestProperties_Issuer();
            issueV2RequestProperties_Issuer.organisation = _organisation;
            issueV2RequestProperties_Issuer.legalForm = _legalForm;
            issueV2RequestProperties_Issuer.governingLaw = _governingLaw;
            issueV2RequestProperties_Issuer.issuerCountry = _issuerCountry;
            issueV2RequestProperties_Issuer.jurisdiction = _jurisdiction;
            issueV2RequestProperties_Issuer.email = _email;



            IssueV2RequestProperties_Meta_Legal issueV2RequestProperties_Meta_Legal = new IssueV2RequestProperties_Meta_Legal();
            issueV2RequestProperties_Meta_Legal.terms = _terms;

            IssueV2RequestProperties_Media issueV2RequestProperties_Media = new IssueV2RequestProperties_Media();
            issueV2RequestProperties_Media.URI = _URI;
            issueV2RequestProperties_Media.type = _type_media;
            issueV2RequestProperties_Media.altURI = _altURI;

            IssueV2RequestProperties_Meta issueV2RequestProperties_Meta = new IssueV2RequestProperties_Meta();
            issueV2RequestProperties_Meta.schemaId = _schemaId;
            issueV2RequestProperties_Meta.website = _website;
            issueV2RequestProperties_Meta.legal = issueV2RequestProperties_Meta_Legal;
            issueV2RequestProperties_Meta.media = new IssueV2RequestProperties_Media[1];
            issueV2RequestProperties_Meta.media[0] = issueV2RequestProperties_Media;

            IssueV2RequestProperties issueV2RequestProperties = new IssueV2RequestProperties();
            issueV2RequestProperties.legal = issueV2RequestProperties_Legal;
            issueV2RequestProperties.issuer = issueV2RequestProperties_Issuer;
            issueV2RequestProperties.meta = issueV2RequestProperties_Meta;

            issueV2RequestFormatter.properties = issueV2RequestProperties;
            //Request Class Data added
            //

            //Logging
            TegmentClient.EnableLog = enableLog;
            //Now Add headers
            TegmentClient.DefaultRequestHeaders["protocol"] = _protocol;
            TegmentClient.DefaultRequestHeaders["reminting"] = _reminting.ToString().ToLower();
            TegmentClient.DefaultRequestHeaders["type"] = _type;
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;
            if (!string.IsNullOrEmpty(_serviceId))
            {
                TegmentClient.DefaultRequestHeaders["serviceID"] = _serviceId;
            }

            string path = PathConstants.baseURL + PathConstants.issue_v2;
            TegmentClient.Post<IssueV2ResponseFormatter>(path, issueV2RequestFormatter, callback);
        }
    }
}
