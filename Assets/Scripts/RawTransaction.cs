using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;
using TMPro;

public class RawTransaction : MonoBehaviour
{
    [HideInInspector]
    public RawTXRootData returndata = new RawTXRootData();

    public TMP_InputField recieverAddress;
    public TMP_InputField Amount;
    public TMP_InputField Notes;
    public TextMeshProUGUI InfoBox;

    public void Start()
    {

    }



    public async void CreateRawTxButton()
    {
        RawTxRequest rawTxRequest = new RawTxRequest();
        RawTxData rawTxData = new RawTxData();

        rawTxData.to = recieverAddress.text;
        rawTxData.amount = double.Parse(Amount.text.ToString());
        rawTxRequest.dataArray = new RawTxData[1];
        rawTxRequest.dataArray[0] = rawTxData;
        string strJsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(rawTxRequest);

        var result = await NetworkManager.Instance.PostRequestWithAuthToken(RelysiaSDKManager.Instance.AuthToken, API_constants.rawtx, strJsonReq);
        JObject parsedResponse = JObject.Parse(result);
        InfoBox.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<RawTXRootData>(parsedResponse.ToString());
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
