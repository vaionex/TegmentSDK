using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using TMPro;

public class AddressAPI : MonoBehaviour
{

    public TextMeshProUGUI Paymail;
    public TextMeshProUGUI Address;

    public void Start()
    {
        SetupData();
    }

    private void SetupData()
    {
        Paymail.text = "PayMail : " + MenuUIManager.Instance.returndataAddressAPI.data.paymail;
        Address.text = "Wallet ID : " + MenuUIManager.Instance.returndataAddressAPI.data.address;
    }
   

    public void GoBackToMainMenu()
    {
        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
