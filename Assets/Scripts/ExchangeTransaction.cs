using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;
using TMPro;

public class ExchangeTransaction : MonoBehaviour
{

    [HideInInspector]
    public ExchangeRootData returndata = new ExchangeRootData();

    public TMP_InputField tokenID;
    public TMP_InputField amountToExchange;
    public TMP_InputField SN;
    public TMP_InputField Type;

    public TMP_InputField paymail;
    public TMP_InputField amountTo;

    public TextMeshProUGUI InfoBox;


    public async void CreateExchangeTxButton()
    {
        ExchangeRequest exchangeRequest = new ExchangeRequest();
        ExchangeRequestRoot exchangeRequestRoot = new ExchangeRequestRoot();

        exchangeRequestRoot.tokenId = tokenID.text;
        exchangeRequestRoot.amount =double.Parse(amountToExchange.text);
        exchangeRequestRoot.sn = int.Parse(SN.text);
        exchangeRequestRoot.type = Type.text;

        ExchnagePayment exchangePayment = new ExchnagePayment();
        exchangePayment.to = paymail.text;
        exchangePayment.amount = double.Parse(amountTo.text);

        exchangeRequestRoot.payment = new ExchnagePayment[1];
        exchangeRequestRoot.payment[0] = exchangePayment;

        exchangeRequest.dataArray = new ExchangeRequestRoot[1];
        exchangeRequest.dataArray[0] = exchangeRequestRoot;

        string strJsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(exchangeRequest);

        var result = await NetworkManager.Instance.PostRequestWithAuthToken(RelysiaSDKManager.Instance.AuthToken, API_constants.exchangeOffer, strJsonReq);
        JObject parsedResponse = JObject.Parse(result);
        InfoBox.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<ExchangeRootData>(parsedResponse.ToString());
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
