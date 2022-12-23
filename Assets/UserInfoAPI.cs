using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UserInfoAPI : MonoBehaviour
{
    public Image UserPhoto;
    public Text UserID;
    public Text UserName;
    public UserDataRoot returndata = new UserDataRoot();



    public async Task<string> GetUserInfo(string authToken)
    {
        string url = API_constants.baseURL + "/v1/user";

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

    public static async Task<Texture2D> GetRemoteTexture(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz

            // read results:
            if( www.result!=UnityWebRequest.Result.Success )// for Unity >= 2020.1
            {
                // log error:
#if DEBUG
                Debug.Log($"{www.error}, URL:{www.url}");
#endif

                // nothing to return on error:
                return null;
            }
            else
            {
                // return valid results:
                return DownloadHandlerTexture.GetContent(www);
            }
        }
    }

    public async void UserInfoButton()
    {
        var result = await GetUserInfo(RelysiaSDKManager.Instance.AuthToken);
        JObject parsedResponse = JObject.Parse(result);
        //WalletID.text = parsedResponse["data"]["msg"].ToString().Replace("_", " ");
        returndata = JsonUtility.FromJson<UserDataRoot>(parsedResponse.ToString());
        UserName.text = "Name : " + returndata.data.userDetails.displayName;
        UserID.text = "ID : " + returndata.data.userDetails.userId;
        var Texture = await GetRemoteTexture(returndata.data.userDetails.photoUrl);
        UserPhoto.sprite = Sprite.Create(Texture,new Rect(0,0, Texture.width, Texture.height), new Vector2(0,0));
        Debug.Log("result: " + result);
    }

    public void GoBackToMainMenu()
    {
        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
