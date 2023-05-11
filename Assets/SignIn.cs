using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class SignIn : MonoBehaviour
{
    public Text LogInEmail;
    public Text ResetPassEmail;
    public Text ResetPassErrorPrompt;
    public Text LogInPassword;
    public Text LoginErrorPrompt;

    public AuthDataRoot returndata = new AuthDataRoot();
    public ResetPassDataRoot Resetreturndata = new ResetPassDataRoot();


    public async void ResetPasswordButton()
    {
        ResetPasswordRequest resetPasswordRequest = new ResetPasswordRequest();
        resetPasswordRequest.email = ResetPassEmail.text;
        string strJsonReq = JsonUtility.ToJson(resetPasswordRequest);

        //var result = await SendRecoveryEmail(ResetPassEmail.text);
        var result = await NetworkManager.Instance.PostRequest(API_constants.passwordReset, strJsonReq);

        JObject parsedResponse = JObject.Parse(result);
        ResetPassErrorPrompt.text = parsedResponse["data"]["msg"].ToString();
        Resetreturndata = JsonUtility.FromJson<ResetPassDataRoot>(parsedResponse.ToString());
        if (returndata.data.status == "success")
        {
            //RelysiaSDKManager.Instance.SetAPIResultData(returndata);
        }

        Debug.Log("result: " + result);
    }


   /* public async Task<string> SendRecoveryEmail(string email)
    {
        string url = API_constants.baseURL + "/v1/reset/password";

        JObject jsonObject = new JObject();
        jsonObject.Add("email", email);
        Debug.Log(email);
        string json = jsonObject.ToString();

        Debug.Log(json);

        var request = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
       

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
    }*/

    public async void LoginButton()
    {
        LogInRequest logInRequest = new LogInRequest();
        logInRequest.email = LogInEmail.text;
        logInRequest.password = LogInPassword.text;

        string strJsonReq = JsonUtility.ToJson(logInRequest);

        //var result = await LogIn(LogInEmail.text, LogInPassword.text);
        var result = await NetworkManager.Instance.PostRequest(API_constants.auth, strJsonReq);

        JObject parsedResponse = JObject.Parse(result);
        LoginErrorPrompt.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<AuthDataRoot>(parsedResponse.ToString());
        if (returndata.data.status == "success")
        {
            RelysiaSDKManager.Instance.SetAPIResultData(returndata);
            MenuUIManager.Instance.GoToMainMenu(gameObject);
            
        }

        Debug.Log("result: " + result);
    }

  

}
