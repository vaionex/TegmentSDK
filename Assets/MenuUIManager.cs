using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;

    public List<GameObject> UIScreens;
    public GameObject LoginScreen;
    public GameObject SignUpScreen;
    public GameObject SDKMenuScreen;
    public GameObject SDKTitleScreen;

    [HideInInspector]
    public UserDataRoot returndataUserInfoAPI = new UserDataRoot();
    [HideInInspector]
    public AddressDataRoot returndataAddressAPI = new AddressDataRoot();
    [HideInInspector]
    public AllAddressesRoot returnDataAllAddressesAPI = new AllAddressesRoot();
    [HideInInspector]
    public WalltesRoot returnDataWalletsAPI = new WalltesRoot();

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


    public void GoToMainMenu(GameObject gb)
    {
        SDKMenuScreen.SetActive(true);
        gb.SetActive(false);
        LoadUserInfoAPIData();
        LoadAddressAPI();
        LoadAllAddressesAPI();
        LoadAllWalletsAPI();
    }

    public void GoToTitleScreen(GameObject gb)
    {
        SDKTitleScreen.SetActive(true);
        gb.SetActive(false);
    }

    private async void LoadUserInfoAPIData()
    {
        UnityWebRequest request = new UnityWebRequest();
        var result = await NetworkManager.Instance.GetRequest(RelysiaSDKManager.Instance.AuthToken, API_constants.user, request);
        Debug.Log(result);
        returndataUserInfoAPI = JsonUtility.FromJson<UserDataRoot>(result.ToString());
    }

    private async void LoadAddressAPI()
    {
        UnityWebRequest request = new UnityWebRequest();
        var result = await NetworkManager.Instance.GetRequest(RelysiaSDKManager.Instance.AuthToken, API_constants.address,request);
        Debug.Log(result);
        returndataAddressAPI = JsonUtility.FromJson<AddressDataRoot>(result.ToString());
    }

    private async void LoadAllAddressesAPI()
    {
        UnityWebRequest request = new UnityWebRequest();
        var result = await NetworkManager.Instance.GetRequest(RelysiaSDKManager.Instance.AuthToken, API_constants.allAddresses, request);
        Debug.Log(result);
        returnDataAllAddressesAPI = JsonUtility.FromJson<AllAddressesRoot>(result.ToString());
    }

    private async void LoadAllWalletsAPI()
    {
        UnityWebRequest request = new UnityWebRequest();
        var result = await NetworkManager.Instance.GetRequest(RelysiaSDKManager.Instance.AuthToken, API_constants.wallets, request);
        Debug.Log(result);
        returnDataWalletsAPI = JsonUtility.FromJson<WalltesRoot>(result.ToString());
    }
}
