using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button GetUserInfo;
    public Button GetAddress;
    public Button AllAddresses;
    public Button Leaderboards;
    public Button SendPayment;
    public Button Btn_Wallets;
    public Button IssueToken;
    public Button CreateWallet;
    public Button Mnemonic;
    public Button Balance;
    public Button RawTx;
    public Button DropTx;
    


    public GameObject UI_UserInfo;
    public GameObject UI_GetAddress;
    public GameObject UI_AllAddress;
    //public GameObject UI_Leaderboards;
    public GameObject UI_SendPayment;
    public GameObject UISendPayment_Payment;
    public GameObject UISendPayment_Token;
    public GameObject UISendPayment_NFT;
    public GameObject UI_Wallets;
    public GameObject UI_CreateWallet;
    public GameObject UI_Mnemonic;
    public GameObject UI_Balance;
    //public GameObject UI_IssueToken;
    public GameObject UI_RawTx;
    public GameObject UI_DropTx;

    // Start is called before the first frame update
    void Start()
    {
        HideAllUI();

        GetUserInfo.onClick.AddListener(() => GetUserInfo_Click());
        GetAddress.onClick.AddListener(() => GetAddress_Click());
        AllAddresses.onClick.AddListener(() => AllAddresses_Click());
        Leaderboards.onClick.AddListener(() => Leaderboards_Click());
        SendPayment.onClick.AddListener(() => SendPayment_Click());
        Btn_Wallets.onClick.AddListener(() => Wallets_Click());
        IssueToken.onClick.AddListener(() => IssueToken_Click());
        CreateWallet.onClick.AddListener(() => CreateWallet_Click());
        Mnemonic.onClick.AddListener(() => Mnemonic_Click());
        Balance.onClick.AddListener(() => Balance_Click());
        RawTx.onClick.AddListener(() => RawTx_Click());
        DropTx.onClick.AddListener(() => DropTx_Click());
    }

    private void HideAllUI()
    {
        UI_UserInfo.SetActive(false);
        UI_GetAddress.SetActive(false);
        UI_AllAddress.SetActive(false);
        UI_SendPayment.SetActive(false);
        UISendPayment_Payment.SetActive(false);
        UISendPayment_Token.SetActive(false);
        UISendPayment_NFT.SetActive(false);
        UI_Wallets.SetActive(false);
        UI_CreateWallet.SetActive(false);
        UI_Mnemonic.SetActive(false);
        UI_Balance.SetActive(false);
        UI_RawTx.SetActive(false);
        UI_DropTx.SetActive(false);
    }

    public void GetUserInfo_Click()
    {
        UI_UserInfo.SetActive(true);
    }
    public void GetAddress_Click()
    {
        UI_GetAddress.SetActive(true);
    }

    public void AllAddresses_Click()
    {
        UI_AllAddress.SetActive(true);
    }

    public void Leaderboards_Click()
    {
       // UI_Leaderboards.SetActive(true);
    }

    public void SendPayment_Click()
    {
        UI_SendPayment.SetActive(true);
        UISendPayment_Payment.SetActive(true);
    }
    public void Wallets_Click()
    {
        UI_Wallets.SetActive(true);
    }

    public void IssueToken_Click()
    {
       // UI_IssueToken.SetActive(true);
    }

    public void CreateWallet_Click()
    {
        UI_CreateWallet.SetActive(true);
    }

    public void Mnemonic_Click()
    {
        UI_Mnemonic.SetActive(true);
    }
    public void Balance_Click()
    {
        UI_Balance.SetActive(true);
    }

    public void RawTx_Click()
    {
        UI_RawTx.SetActive(true);
    }

    public void DropTx_Click()
    {
        UI_DropTx.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
