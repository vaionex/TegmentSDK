using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;
using System;

public class Transactions : MonoBehaviour
{
    private string authToken;
    public string recieverAddress;
    public string senderWalletId;
    public float amount;

    public SendPaymentRootData returndata = new SendPaymentRootData();


    private void Start()
    {
        authToken = RelysiaSDKManager.Instance.AuthToken;
    }

    

}


