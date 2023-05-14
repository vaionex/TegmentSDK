
///Network manager class for GET, POST and PUT calls
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Threading.Tasks;

public class NetworkManager : MonoBehaviour
{
    [SerializeField]
    //private string EndPointAddress;
    //NetworkManager instance to access this out of this class
    public static NetworkManager Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
   


    public async Task<Texture2D> GetRemoteTexture(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz

            // read results:
            if (www.result != UnityWebRequest.Result.Success)// for Unity >= 2020.1
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

    public async Task<string> PostRequest(string API, string strJsonReq)
    {
        string url = API_constants.baseURL + API;
        Debug.Log(url);
        var request = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(strJsonReq);
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
            return request.downloadHandler.text;
        }

        else
        {
            Debug.Log("Request Failed. Error:" + request.error);
            return request.downloadHandler.text;
        }
    }
    public async Task<string> PostRequestWithAuthToken(string authToken,string API, string strJsonReq)
    {
        string url = API_constants.baseURL + API;
        Debug.Log(url);
        var request = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(strJsonReq);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "*/*");
        request.SetRequestHeader("authToken", authToken);

        request.SendWebRequest();

        //Wait while request is not done.
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
    public async Task<string> GetRequest(string authToken, string API, UnityWebRequest request)
    {
        string url = API_constants.baseURL + API;
        Debug.Log(url);

        request = UnityWebRequest.Get(url);
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
}