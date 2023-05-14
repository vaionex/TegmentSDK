using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;
using TMPro;
public class OfferTransactions : MonoBehaviour
{
    [HideInInspector]
    public DropTXRootData returndata = new DropTXRootData();

    public TMP_InputField tokenID;
    public TMP_InputField SN;
    public TMP_InputField AmountOffer;
    public TMP_InputField AmountWanted;

    public TextMeshProUGUI InfoBox;




    public async void CreateOfferTxButton()
    {
        OfferRequest offerRequest = new OfferRequest();
        OfferData offerData = new OfferData();

        offerData.tokenId = tokenID.text;
        offerData.amount = double.Parse(AmountOffer.text.ToString());
        offerData.sn = int.Parse(SN.text.ToString());
        offerData.wantedAmount = double.Parse(AmountWanted.text.ToString());

        offerRequest.dataArray = new OfferData[1];
        offerRequest.dataArray[0] = offerData;
        string strJsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(offerRequest);

        var result = await NetworkManager.Instance.PostRequestWithAuthToken(RelysiaSDKManager.Instance.AuthToken, API_constants.offer, strJsonReq);
        JObject parsedResponse = JObject.Parse(result);
        InfoBox.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<DropTXRootData>(parsedResponse.ToString());
        if (returndata.data.status == "success")
        {
            MenuUIManager.Instance.GoToMainMenu(gameObject);
        }

        Debug.Log("result: " + result);
    }



    public void GoBackToMainMenu()
    {
        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
