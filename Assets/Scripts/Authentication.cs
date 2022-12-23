using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class Authentication : MonoBehaviour
{
    public Text loginEmail;
    public Text loginPassword;
    public Text loginResultText;
    
    public Text signUpEmail;
    public Text signUpPassword;
    public Text signUpResultText;

    //private async void Start()
    //{
    //    var result = await LogIn("gaming@tegment.com", "gamingRewards123");
    //    Debug.Log("result: " + result);
    //}

    public async Task<string> SignUp(string _email, string _password)
    {
        string url = API_constants.baseURL + "/v1/signUp";
     
        JObject jsonObject = new JObject();
        jsonObject.Add("email", _email);
        jsonObject.Add("password", _password);

        string json = jsonObject.ToString();

        var request = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "*/*");

        request.SendWebRequest();

        while (!request.isDone)
        {
            await Task.Yield();
        }

        

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Request is successful.");

            var jsonResponse = request.downloadHandler.text;
            JObject parsedResponse = JObject.Parse(jsonResponse);
            string accessToken = parsedResponse["data"]["token"].ToString();
            
            return request.downloadHandler.text;
            
        }

        else
        {
            Debug.Log("Request Failed. Error:" + request.error);
            return request.downloadHandler.text;
            
        }
    }

    public async Task<string> LogIn(string _email, string _password)
    {
        string url = API_constants.baseURL + "/v1/auth";

        JObject jsonObject = new JObject();
        jsonObject.Add("email", _email);
        Debug.Log(_email);
        Debug.Log(_password);
        jsonObject.Add("password", _password);
        string json = jsonObject.ToString();

        Debug.Log(json);

        var request = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "*/*");

        request.SendWebRequest();

        //Wait while request is not done.
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

    public async void LoginButton()
    {
        var result = await LogIn(loginEmail.text, loginPassword.text);
        JObject parsedResponse = JObject.Parse(result);
        loginResultText.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");

        Debug.Log("result: " + result);
    }
    
    public async void SignUpButton()
    {
        var result = await SignUp(signUpEmail.text, signUpPassword.text);
        JObject parsedResponse = JObject.Parse(result);
        signUpResultText.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");

        Debug.Log("result: " + result);
    }
}
