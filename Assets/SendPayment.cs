using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;
using TMPro;
public class SendPayment : MonoBehaviour
{
    [HideInInspector]
    public SendPaymentRootData returndata = new SendPaymentRootData();

    public TMP_InputField recieverAddress;
    public TMP_InputField Amount;
    public TMP_InputField Notes;
    public TextMeshProUGUI InfoBox;

    public void Start()
    {
        
    }



    public async void SendPaymentButton()
    {
        SendCoinsRequest sendCoinsRequest = new SendCoinsRequest();
        SendCoinsData sendCoinsData = new SendCoinsData();

        sendCoinsData.to = recieverAddress.text;
        sendCoinsData.amount =double.Parse (Amount.text.ToString());
        sendCoinsRequest.dataArray = new SendCoinsData[1] ;
        sendCoinsRequest.dataArray[0] = sendCoinsData;
        string strJsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(sendCoinsRequest);

        var result = await NetworkManager.Instance.PostRequestWithAuthToken(RelysiaSDKManager.Instance.AuthToken, API_constants.send, strJsonReq);
        JObject parsedResponse = JObject.Parse(result);
        InfoBox.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<SendPaymentRootData>(parsedResponse.ToString());
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
