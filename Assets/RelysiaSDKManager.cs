using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

[System.Serializable]

public class RelysiaSDKManager : MonoBehaviour
{
    public static RelysiaSDKManager Instance;

    public AuthDataRoot returndata = new AuthDataRoot();

    [HideInInspector]
    public string AuthToken = "";
    [HideInInspector]
    public string UserId;
    [HideInInspector]
    public string WalletId;

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
    }

    public void SetAPIResultData(AuthDataRoot data)
    {
        returndata = data;
        AuthToken = data.data.token;
        UserId = data.data.userId;
    }







    public void GetPlayerInfo()
    {
        StartCoroutine(FetchAccountDetails());
    }

    public IEnumerator FetchAccountDetails()
    {
        using (UnityWebRequest restAPI = UnityWebRequest.Get(API_constants.baseURL + "v1/user"))
        {
            restAPI.method = UnityWebRequest.kHttpVerbGET;  //this is declaring that we are actually sending a POST not a PUT, this is a little hack as above we declared it a PUT

            restAPI.SetRequestHeader("content-type", "application/json");
            restAPI.SetRequestHeader("Accept", "application/json");
            restAPI.SetRequestHeader("oauth", AuthToken);


            yield return restAPI.SendWebRequest();//sends out the request and waits for the returned content.

            if (restAPI.result == UnityWebRequest.Result.ConnectionError) //checks for errors
            {
                Debug.Log(restAPI.error);
                Debug.Log(restAPI.result.ToString());
            }
            else
            {
                Debug.Log("Form upload complete!");
                if (restAPI.isDone)
                {
                    var returnedBody = System.Text.Encoding.UTF8.GetString(restAPI.downloadHandler.data);//this takes the returned body from the rest api(this works for rest services that return JSON bodies only, use another configuration for other systems) and changes the content to UTF8 or "standard characters" so it can be turned into a string, it saves this data to the JSONNode object named returnedBody
                    Debug.Log(restAPI.result.ToString());

                    //returndata = JsonUtility.FromJson<DataRoot>(System.Text.Encoding.UTF8.GetString(restAPI.downloadHandler.data)); //this takes the returned body from the rest api(this works for rest services that return JSON bodies only, use another configuration for other systems) and changes the content to UTF8 or "standard characters" so it can be turned into a string, it saves this data to the JSONNode object named returnedBody
                    if (returndata == null)// if there is no returned body this assumes the connection failed because my rest api returns a return value if the log in attempt is valid or invalid, so no return means it failed to work in general.
                    {
                        Debug.Log("failed log in");
                    }
                    else
                    {
                        Debug.Log(returnedBody);
                    }
                }
            }

        }
    }
  
}
