using UnityEngine;
using TMPro;
using Tegment.Network;
using Tegment.ResponseFormatter;
using UnityEngine.UI;

namespace Tegment.Unity.Samples.SmartContracts
{
    /// <summary>
    /// Mint a token
    /// Mint a token with given specifications (can be both token or NFT)
    /// </summary>
    public class Issue_V2Handler : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField protocol;
        [SerializeField]
        private Toggle reMinting;
        [SerializeField]
        private TMP_InputField walletId;
        [SerializeField]
        private TMP_InputField _type;
        [SerializeField]
        private TMP_InputField _name;
        [SerializeField]
        private TMP_InputField symbol;
        [SerializeField]
        private TMP_InputField description;
        [SerializeField]
        private TMP_InputField image;
        [SerializeField]
        private TMP_InputField tokenSupply;
        [SerializeField]
        private TMP_InputField decimals;
        [SerializeField]
        private TMP_InputField satsPerToken;
        [SerializeField]
        private TMP_InputField terms_Legal;
        [SerializeField]
        private TMP_InputField licenceID_Legal;
        [SerializeField]
        private TMP_InputField organisation_Issuer;
        [SerializeField]
        private TMP_InputField legalForm_Issuer;
        [SerializeField]
        private TMP_InputField governingLaw_Issuer;
        [SerializeField]
        private TMP_InputField issuerCountry_Issuer;
        [SerializeField]
        private TMP_InputField jurisdiction_Issuer;
        [SerializeField]
        private TMP_InputField email_Issuer;
        [SerializeField]
        private TMP_InputField schemaId_Meta;
        [SerializeField]
        private TMP_InputField website_Meta;
        [SerializeField]
        private TMP_InputField terms_Legal_Meta;
        [SerializeField]
        private TMP_InputField URI_Media;
        [SerializeField]
        private TMP_InputField type_Media;
        [SerializeField]
        private TMP_InputField altURI_Media;
        [SerializeField]
        private TextMeshProUGUI responseText;


        /// <summary>
        /// Submit button click event handler
        /// </summary>
        public void IssueV2_Submit()
        {
            responseText.text = "";

            int tokenSupplyVal = 0;
            if (!string.IsNullOrEmpty(tokenSupply.text))
            {
                tokenSupplyVal = int.Parse(tokenSupply.text);
            }

            int decimalsVal = 0;
            if (!string.IsNullOrEmpty(decimals.text))
            {
                decimalsVal = int.Parse(decimals.text);
            }

            int satsPerTokenVal = 0;
            if (!string.IsNullOrEmpty(satsPerToken.text))
            {
                satsPerTokenVal = int.Parse(satsPerToken.text);
            }

            object data = new object();

            Tegment.SmartContracts.Issue_V2.MintIssueV2(_name.text, symbol.text, description.text, image.text, tokenSupplyVal, decimalsVal, satsPerTokenVal,
                terms_Legal.text, licenceID_Legal.text, organisation_Issuer.text, legalForm_Issuer.text, governingLaw_Issuer.text, issuerCountry_Issuer.text, jurisdiction_Issuer.text,
                email_Issuer.text, schemaId_Meta.text, website_Meta.text, terms_Legal_Meta.text, URI_Media.text, type_Media.text, altURI_Media.text, data, protocol.text,
                reMinting.isOn, _type.text, walletId.text, TegmentSessionHandler.Instance._authToken, Issue_V2CallBack, true);

        }

        /// <summary>
        /// calback function to handle response
        /// There are 3 params here, first is for exceptio is there is any
        /// second is response
        /// third is response converted to class object
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="response"></param>
        /// <param name="issueV2ResponseFormatter"></param>
        private void Issue_V2CallBack(RequestException exception, ResponseHelper response, IssueV2ResponseFormatter issueV2ResponseFormatter)
        {
            responseText.text = response.Text;
        }
        /// <summary>
        /// clear the input controls and go back button click handler to main menu
        /// </summary>
        public void GoBackToMainMenu()
        {
            protocol.text = "";
            reMinting.isOn = false;
            walletId.text = "";
            _type.text = "NFT";
            _name.text = "Store Bonus Points";
            symbol.text = "SBP";
            description.text = "A supermarket bonus point.";
            image.text = "https://commons.wikimedia.org/wiki/Category:Test_uploads#/media/File:Abcde_2.jpg";
            tokenSupply.text = "3";
            decimals.text = "0";
            satsPerToken.text = "1";
            terms_Legal.text = "STAS, Inc. retains all rights to the token script.  Use is subject to terms at https://stastoken.com/license.";
            licenceID_Legal.text = "stastoken.com";
            organisation_Issuer.text = "Vaionex Corp.";
            legalForm_Issuer.text = "Limited";
            governingLaw_Issuer.text = "US";
            issuerCountry_Issuer.text = "US";
            jurisdiction_Issuer.text = "US";
            email_Issuer.text = "info@vaionex.com";
            schemaId_Meta.text = "STAS1.0";
            website_Meta.text = "vaionex.com";
            terms_Legal_Meta.text = "Your token terms and description.";
            URI_Media.text = "";
            type_Media.text = "";
            altURI_Media.text = "";

            responseText.text = "response Text";
            TegmentSessionHandler.Instance.ClosePopupGO(gameObject);
        }
    }
}