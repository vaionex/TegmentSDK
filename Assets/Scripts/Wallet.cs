using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;


public class Wallet : MonoBehaviour
{
    public string authToken;

    //Start is called before the first frame update
    async void Start()
    {
        authToken = RelysiaSDKManager.Instance.AuthToken;
    }

    public async Task<string> SignUp(string authToken)
    {
        string url = API_constants.baseURL + "/v1/wallets";

        UnityWebRequest request =  UnityWebRequest.Get(url);
        
        
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

            //var jsonResponse = request.downloadHandler.text;
            //JObject parsedResponse = JObject.Parse(jsonResponse);
            //string accessToken = parsedResponse["data"]["token"].ToString();
            
            return request.downloadHandler.text;
            
        }

        else
        {
            Debug.Log("Request Failed. Error:" + request.error);
            return request.downloadHandler.text;
            
        }
    }

}
