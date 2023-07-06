using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;


namespace Tegment.SmartContracts
{

    public static partial class Issue {
        /// <summary>
        /// Mint a token
        /// Mint a token with given specifications (can be both token or NFT)
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_protocolId"></param>
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
        /// <param name="_type"></param>
        /// <param name="_altURI"></param>
        /// <param name="_splitable"></param>
        /// <param name="_data"></param>
        /// <param name="_protocol"></param>
        /// <param name="_reminting"></param>
        /// <param name="_walletID"></param>
        /// <param name="_authToken"></param>
        /// <returns></returns>
        public static APIResponseFormatter<IssueResponseFormatter> MintIssue(string _name, string _protocolId, string _symbol,
            string _description, string _image, int _tokenSupply, int _decimals, int _satsPerToken, string _terms, string _licenceId,
            string _organisation, string _legalForm, string _governingLaw, string _issuerCountry, string _jurisdiction, string _email,
            string _schemaId, string _website, string _legalTerms,string _URI, string _type,string _altURI, bool _splitable, object _data,
            string _protocol, bool _reminting, string _walletID, string _authToken)
        {

            //Add Request Class Data
            IssueRequestFormatter issueRequestFormatter = new IssueRequestFormatter();

            issueRequestFormatter.name = _name;
            issueRequestFormatter.protocolId = _protocolId;
            issueRequestFormatter.symbol = _symbol;
            issueRequestFormatter.description = _description;
            issueRequestFormatter.image = _image;
            issueRequestFormatter.tokenSupply = _tokenSupply;
            issueRequestFormatter.decimals = _decimals;
            issueRequestFormatter.satsPerToken = _satsPerToken;

            issueRequestFormatter.splitable = _splitable;
            issueRequestFormatter.data = _data;


            
            IssueRequestProperties_Legal issueRequestProperties_Legal = new IssueRequestProperties_Legal();
            issueRequestProperties_Legal.terms = _legalTerms;
            issueRequestProperties_Legal.licenceId = _licenceId;

            IssueRequestProperties_Issuer issueRequestProperties_Issuer = new IssueRequestProperties_Issuer();
            issueRequestProperties_Issuer.organisation = _organisation;
            issueRequestProperties_Issuer.legalForm = _legalForm;
            issueRequestProperties_Issuer.governingLaw = _governingLaw;
            issueRequestProperties_Issuer.issuerCountry = _issuerCountry;
            issueRequestProperties_Issuer.jurisdiction = _jurisdiction;
            issueRequestProperties_Issuer.email = _email;

            

            IssueRequestProperties_Meta_Legal issueRequestProperties_Meta_Legal = new IssueRequestProperties_Meta_Legal();
            issueRequestProperties_Meta_Legal.terms = _terms;

            IssueRequestProperties_Media issueRequestProperties_Media = new IssueRequestProperties_Media();
            issueRequestProperties_Media.URI = _URI;
            issueRequestProperties_Media.type = _type;
            issueRequestProperties_Media.altURI = _altURI;

            IssueRequestProperties_Meta issueRequestProperties_Meta = new IssueRequestProperties_Meta();
            issueRequestProperties_Meta.schemaId = _schemaId;
            issueRequestProperties_Meta.website = _website;
            issueRequestProperties_Meta.legal = issueRequestProperties_Meta_Legal;
            issueRequestProperties_Meta.media = new IssueRequestProperties_Media[1];
            issueRequestProperties_Meta.media[0] = issueRequestProperties_Media;

            IssueRequestProperties issueRequestProperties = new IssueRequestProperties();
            issueRequestProperties.legal = issueRequestProperties_Legal;
            issueRequestProperties.issuer = issueRequestProperties_Issuer;
            issueRequestProperties.meta = issueRequestProperties_Meta;

            issueRequestFormatter.properties = issueRequestProperties;
            //Request Class Data added
            //
            //Now Add headers
            TegmentClient.DefaultRequestHeaders["protocol"] = _protocol;
            TegmentClient.DefaultRequestHeaders["reminting"] = _reminting.ToString();
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;


            APIResponseFormatter<IssueResponseFormatter> apiResponseFormatter = new APIResponseFormatter<IssueResponseFormatter>();
            TegmentClient.Post<string>(PathConstants.baseURL + PathConstants.issue, issueRequestFormatter).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<IssueResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<IssueResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}