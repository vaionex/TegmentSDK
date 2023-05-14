using UnityEngine;
using Newtonsoft.Json.Linq;
using TMPro;
public class SwapOffer : MonoBehaviour
{
    [HideInInspector]
    public SwapOfferRootData returndata = new SwapOfferRootData();

    public TMP_InputField SwapID;

    public TextMeshProUGUI InfoBox;


    public async void CreateSwapOfferTxButton()
    {
        SwapOfferRequest swapOfferRequest = new SwapOfferRequest();
        SwapOfferRequestRoot swapOfferRequestRoot = new SwapOfferRequestRoot();

        swapOfferRequestRoot.swapId = SwapID.text;


        swapOfferRequest.dataArray = new SwapOfferRequestRoot[1];
        swapOfferRequest.dataArray[0] = swapOfferRequestRoot;

       
        string strJsonReq = Newtonsoft.Json.JsonConvert.SerializeObject(swapOfferRequest);

        var result = await NetworkManager.Instance.PostRequestWithAuthToken(RelysiaSDKManager.Instance.AuthToken, API_constants.exchangeSwap, strJsonReq);
        JObject parsedResponse = JObject.Parse(result);
        InfoBox.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<SwapOfferRootData>(parsedResponse.ToString());
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
