using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;
using TMPro;

public class SwapTransaction : MonoBehaviour
{
    [HideInInspector]
    public SwapRootData returndata = new SwapRootData();

    public TMP_InputField SwapHex;
    public TextMeshProUGUI InfoBox;


    public async void CreateSwapTxButton()
    {
        SwapRequest swapRequest = new SwapRequest();
        SwapData swapData = new SwapData();

        swapData.swapHex = SwapHex.text;
        swapRequest.dataArray = new SwapData[1];
        swapRequest.dataArray[0] = swapData;
        string strJsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(swapRequest);

        var result = await NetworkManager.Instance.PostRequestWithAuthToken(RelysiaSDKManager.Instance.AuthToken, API_constants.swap, strJsonReq);
        JObject parsedResponse = JObject.Parse(result);
        InfoBox.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<SwapRootData>(parsedResponse.ToString());
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
