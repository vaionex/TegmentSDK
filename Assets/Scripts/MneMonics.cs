using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class MneMonics : MonoBehaviour
{
    public TMP_Dropdown walletDropDown;
    public TextMeshProUGUI txtmenMonic;

    [HideInInspector]
    public MnemonicRoot returnDataMnemonicAPI = new MnemonicRoot();

    // Start is called before the first frame update
    void Start()
    {
        walletDropDown.onValueChanged.AddListener(delegate {
            WalletDropDownValueChanged(walletDropDown);
        });
        walletDropDown.options.Clear();
        walletDropDown.ClearOptions();
        SetUpDropdown();
    }

    private async void SetUpDropdown()
    {
        foreach (WalletList wallet in MenuUIManager.Instance.returnDataWalletsAPI.data.wallets)
        {
            walletDropDown.options.Add(new TMP_Dropdown.OptionData() { text = wallet.walletID });
        }
        walletDropDown.RefreshShownValue();

        var result= await GetMnemonic(walletDropDown.options[0].text);
        returnDataMnemonicAPI = JsonUtility.FromJson<MnemonicRoot>(result.ToString());
        txtmenMonic.text = returnDataMnemonicAPI.data.mnemonic;
    }

    private async void WalletDropDownValueChanged( TMP_Dropdown dropDown)
    {
        Debug.Log(dropDown.options[dropDown.value].text);
        var result= await GetMnemonic(dropDown.options[dropDown.value].text);
        returnDataMnemonicAPI = JsonUtility.FromJson<MnemonicRoot>(result.ToString());
        txtmenMonic.text = returnDataMnemonicAPI.data.mnemonic;
    }

    public async Task<string> GetMnemonic( string strWalletID)
    {
        Debug.Log(strWalletID);
        string url = API_constants.baseURL + API_constants.mnemonic;
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Get(url);

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("accept", "*/*");
        request.SetRequestHeader("authToken", RelysiaSDKManager.Instance.AuthToken);
        request.SetRequestHeader("walletID", strWalletID);

        request.SendWebRequest();

        while (!request.isDone)
        {
            await Task.Yield();
        }


        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Request is successful." + request.downloadHandler.text);
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
