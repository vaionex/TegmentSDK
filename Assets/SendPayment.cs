using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System;

public class SendPayment : MonoBehaviour
{
    // Start is called before the first frame update
    private string authToken;

    public SendPaymentRootData returndata = new SendPaymentRootData();

    public Text recieverAddress;
    public Text Amount;
    public Text InfoBox;

    public void Start()
    {
        authToken = RelysiaSDKManager.Instance.AuthToken;
    }



    public async void SendPaymentButton()
    {
        var result = await PerformTransaction(authToken, recieverAddress.text, Convert.ToDouble(Amount.text));
        JObject parsedResponse = JObject.Parse(result);
        InfoBox.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<SendPaymentRootData>(parsedResponse.ToString());
        if (returndata.data.status == "success")
        {
            //RelysiaSDKManager.Instance.SetAPIResultData(returndata);
            MenuUIManager.Instance.GoToMainMenu(gameObject);
        }

        Debug.Log("result: " + result);
    }

    public async Task<string> PerformTransaction(string authToken, string recieverAddress,
    double amountToSend)
    {
        string url = API_constants.baseURL + "/v1/send";

        JObject data = new JObject();
        data.Add("to", recieverAddress);
        data.Add("amount", amountToSend);

        JArray jArray = new JArray();
        jArray.Add(data);

        JObject jsonObject = new JObject();
        jsonObject["dataArray"] = jArray;

        string json = jsonObject.ToString();
        Debug.Log(jsonObject.ToString());

        var request = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        //Set headers for Send request.
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "*/*");
        request.SetRequestHeader("authToken", authToken);


        request.SendWebRequest();

        while (!request.isDone)
        {
            await Task.Yield();
        }



        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Request is successful.");
            /*
                        var jsonResponse = request.downloadHandler.text;
                        JObject parsedResponse = JObject.Parse(jsonResponse);
                        string accessToken = parsedResponse["data"]["token"].ToString();
            */
            return request.downloadHandler.text;

        }

        else
        {
            Debug.Log("Request Failed. Error:" + request.error);
            return request.downloadHandler.text;

        }
    }

    public void GoBackToMainMenu()
    {
        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }

}
