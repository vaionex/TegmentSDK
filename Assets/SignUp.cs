using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class SignUp : MonoBehaviour
{
    public Text SignUpEmail;
    public Text SignUpPassword;
    public Text SignUpErrorPrompt;

    public AuthDataRoot returndata = new AuthDataRoot();

  /* public async Task<string> Sign_Up(string _email, string _password)
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
  */

    public async void SignUpButton()
    {
        SignUpRequest signUpRequest = new SignUpRequest();
        signUpRequest.email = SignUpEmail.text;
        signUpRequest.password = SignUpPassword.text;

        string strJsonReq = JsonUtility.ToJson(signUpRequest);

        //var result = await Sign_Up(SignUpEmail.text, SignUpPassword.text);
        var result = await NetworkManager.Instance.PostRequest(API_constants.signUP, strJsonReq);

        JObject parsedResponse = JObject.Parse(result);
        SignUpErrorPrompt.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<AuthDataRoot>(parsedResponse.ToString());
        if (returndata.data.status == "success")
        {
            RelysiaSDKManager.Instance.SetAPIResultData(returndata);
            MenuUIManager.Instance.GoToMainMenu(gameObject);
        }

        Debug.Log("result: " + result);
    }
}
