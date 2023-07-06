using UnityEngine;
using Tegment.Network;
using Tegment.RequestFormatter;
using Tegment.ResponseFormatter;
using Tegment.Utility;

namespace Tegment.SmartContracts
{
    public static partial class Issue_V2
    {
        public static APIResponseFormatter<IssueV2ResponseFormatter> MintIssueV2(string _name, string _protocolId, string _symbol,
             string _description, string _image, int _tokenSupply, int _decimals, int _satsPerToken, string _terms, string _licenceId,
             string _organisation, string _legalForm, string _governingLaw, string _issuerCountry, string _jurisdiction, string _email,
             string _schemaId, string _website, string _legalTerms, string _URI, string _type, string _altURI, bool _splitable, object _data,
             string _protocol, bool _reminting, string _walletID, string _authToken)
        {

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
            issueV2RequestProperties_Media.type = _type;
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
            //Now Add headers
            TegmentClient.DefaultRequestHeaders["protocol"] = _protocol;
            TegmentClient.DefaultRequestHeaders["reminting"] = _reminting.ToString();
            TegmentClient.DefaultRequestHeaders["walletID"] = _walletID;
            TegmentClient.DefaultRequestHeaders["authToken"] = _authToken;


            APIResponseFormatter<IssueV2ResponseFormatter> apiResponseFormatter = new APIResponseFormatter<IssueV2ResponseFormatter>();
            TegmentClient.Post<string>(PathConstants.baseURL + PathConstants.issue, issueV2RequestFormatter).Then(response => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<IssueV2ResponseFormatter>>(response.ToString());
            }).Catch(err => {
                apiResponseFormatter = JsonUtility.FromJson<APIResponseFormatter<IssueV2ResponseFormatter>>(err.ToString());
            });
            return apiResponseFormatter;
        }
    }
}
