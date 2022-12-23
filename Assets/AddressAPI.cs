using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class AddressAPI : MonoBehaviour
{

    public Text Paymail;
    public Text Address;

    string authToken;

    public AddressDataRoot returndata = new AddressDataRoot();


    public void Start()
    {
        authToken = RelysiaSDKManager.Instance.AuthToken;
    }


    public async Task<string> GetAddress(string authToken)
    {
        string url = API_constants.baseURL + "/v1/address";

        UnityWebRequest request = UnityWebRequest.Get(url);


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
            return request.downloadHandler.text;

        }

        else
        {
            Debug.Log("Request Failed. Error:" + request.error);
            return request.downloadHandler.text;

        }
    }

    public async void AddressButton()
    {
        var result = await GetAddress(RelysiaSDKManager.Instance.AuthToken);
        JObject parsedResponse = JObject.Parse(result);
        //WalletID.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<AddressDataRoot>(parsedResponse.ToString());
        Paymail.text ="PayMail : " + returndata.data.paymail;
        Address.text ="Wallet ID : " + returndata.data.address;


        Debug.Log("result: " + result);
    }

    public void GoBackToMainMenu()
    {
        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
