using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;
using TMPro;

public class DropTransaction : MonoBehaviour
{
    [HideInInspector]
    public DropTXRootData returndata = new DropTXRootData();

    public TMP_InputField recieverAddress;
    public TMP_InputField Amount;
    public TMP_InputField TokenId;
    public TMP_InputField Notes;

    public TextMeshProUGUI InfoBox;

    public void Start()
    {

    }



    public async void CreateDropTxButton()
    {
        DropRequest dropTxRequest = new DropRequest();
        DropData dropTxData = new DropData();

        dropTxData.to = recieverAddress.text;
        dropTxData.amount = double.Parse(Amount.text.ToString());
        dropTxRequest.dataArray = new DropData[1];
        dropTxRequest.dataArray[0] = dropTxData;
        string strJsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(dropTxRequest);

        var result = await NetworkManager.Instance.PostRequestWithAuthToken(RelysiaSDKManager.Instance.AuthToken, API_constants.drop, strJsonReq);
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
