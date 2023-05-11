using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class Wallet : MonoBehaviour
{

    public TMP_InputField WalletAddress;
    public TMP_InputField mnemonicPhrase;
    public Toggle activate;
    public Button btnCreateWallet;
   
    private CreateWalletRoot retunDataCreateWallet = new CreateWalletRoot();

    //Start is called before the first frame update
    public void Start()
    {
        btnCreateWallet.onClick.AddListener(() => CreateWallet());
    }


    public void CreateWallet()
    {
        var result= CreateWalletTask();
        retunDataCreateWallet = JsonUtility.FromJson<CreateWalletRoot>(result.ToString());
        if (retunDataCreateWallet.data.status == "success")
        {
            RelysiaSDKManager.Instance.WalletId=retunDataCreateWallet.data.walletID;
            MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public async Task<string> CreateWalletTask()
    {
        string url = API_constants.baseURL + API_constants.createWallet;
        Debug.Log(url);
        UnityWebRequest request =  UnityWebRequest.Get(url);
        
        
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "*/*");
        request.SetRequestHeader("authToken", RelysiaSDKManager.Instance.AuthToken);
        request.SetRequestHeader("walletTitle", WalletAddress.text);
        request.SetRequestHeader("paymailActivate", activate.isOn.ToString().ToLower());

        request.SendWebRequest();

        while (!request.isDone)
        {
            await Task.Yield();
        }
                

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Request is successful."+ request.downloadHandler.text);

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
    public void GoBackToMainMenu()
    {

        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }

}
