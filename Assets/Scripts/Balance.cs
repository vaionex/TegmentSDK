using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class Balance : MonoBehaviour
{
    public TMP_Dropdown walletDropDown;
    public TextMeshProUGUI txtCurrencyType;
    public TextMeshProUGUI txtCurrencyBalance;
    public TextMeshProUGUI txtCoinType;
    public TextMeshProUGUI txtCoinBalance;

    [HideInInspector]
    public BalanceRoot returnDataBalanceAPI = new BalanceRoot();


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

        var result = await GetBalance(walletDropDown.options[0].text);
        returnDataBalanceAPI = JsonUtility.FromJson<BalanceRoot>(result.ToString());
        txtCurrencyType.text = returnDataBalanceAPI.data.totalBalance.currency;
        txtCurrencyBalance.text = returnDataBalanceAPI.data.totalBalance.balance.ToString();

        txtCoinType.text = returnDataBalanceAPI.data.coins[0].protocol;
        txtCoinBalance.text = returnDataBalanceAPI.data.coins[0].balance.ToString();

    }

    private async void WalletDropDownValueChanged(TMP_Dropdown dropDown)
    {
        Debug.Log(dropDown.options[dropDown.value].text);
        var result = await GetBalance(dropDown.options[dropDown.value].text);
        returnDataBalanceAPI = JsonUtility.FromJson<BalanceRoot>(result.ToString());
        txtCurrencyType.text = returnDataBalanceAPI.data.totalBalance.currency;
        txtCurrencyBalance.text = returnDataBalanceAPI.data.totalBalance.balance.ToString();

        txtCoinType.text = returnDataBalanceAPI.data.coins[0].protocol;
        txtCoinBalance.text = returnDataBalanceAPI.data.coins[0].balance.ToString();
    }

    public async Task<string> GetBalance(string strWalletID)
    {
        Debug.Log(strWalletID);
        string url = API_constants.baseURL + API_constants.balance;
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
