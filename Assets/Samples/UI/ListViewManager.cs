using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ListViewManager : MonoBehaviour
{
    [SerializeField]
    private Button btnIdentity;
    [SerializeField]
    private Button btnWallet;
    [SerializeField]
    private Button btnTransactions;
    [SerializeField]
    private Button btnSmartContracts;
    [SerializeField]
    private Button btnUtility;
    [SerializeField]
    private Button btnPaymail;
    [SerializeField]
    private Button btnNotifications;
    [SerializeField]
    private Button btnDelete;
   /* [SerializeField]
    private Button btnAdministration;
    [SerializeField]
    private Button btnQuota;*/

   
    public List<GridDataItem> identity = new List<GridDataItem>();

    [SerializeField]
    private List<GridDataItem> wallet = new List<GridDataItem>();

    [SerializeField]
    private List<GridDataItem> transactions = new List<GridDataItem>();

    [SerializeField]
    private List<GridDataItem> smartContracts = new List<GridDataItem>();

    [SerializeField]
    private List<GridDataItem> utility = new List<GridDataItem>();

    [SerializeField]
    private List<GridDataItem> paymail = new List<GridDataItem>();

    [SerializeField]
    private List<GridDataItem> notifications = new List<GridDataItem>();

    [SerializeField]
    private List<GridDataItem> delete = new List<GridDataItem>();

    /*[SerializeField]
    private List<GridDataItem> administration = new List<GridDataItem>();

    [SerializeField]
    private List<GridDataItem> quota = new List<GridDataItem>();*/


    void Start()
    {
        btnIdentity.onClick.AddListener(() => Identity_Click());
        btnWallet.onClick.AddListener(() => Wallet_Click());
        btnTransactions.onClick.AddListener(() => Transaction_Click());
        btnSmartContracts.onClick.AddListener(() => SmartContracts_Click());
        btnUtility.onClick.AddListener(() => Utility_Click());
        btnPaymail.onClick.AddListener(() => Paymail_Click());
        btnNotifications.onClick.AddListener(() => Notifications_Click());
        btnDelete.onClick.AddListener(() => Delete_Click());
        //btnAdministration.onClick.AddListener(() => Administration_Click());
        //btnQuota.onClick.AddListener(() => Quota_Click());

        GridViewManager.Instance.SetUpGridData(identity);
    }

    private void Identity_Click()
    {
        GridViewManager.Instance.SetUpGridData(identity);
    }
    private void Wallet_Click()
    {
        GridViewManager.Instance.SetUpGridData(wallet);
    }
    private void Transaction_Click()
    {
        GridViewManager.Instance.SetUpGridData(transactions);
    }
    private void SmartContracts_Click()
    {
        GridViewManager.Instance.SetUpGridData(smartContracts);
    }
    private void Utility_Click()
    {
        GridViewManager.Instance.SetUpGridData(utility);
    }
    private void Paymail_Click()
    {
        GridViewManager.Instance.SetUpGridData(paymail);
    }
    private void Notifications_Click()
    {
        GridViewManager.Instance.SetUpGridData(notifications);
    }
    private void Delete_Click()
    {
        GridViewManager.Instance.SetUpGridData(delete);
    }
    /*private void Administration_Click()
    {
        GridViewManager.Instance.SetUpGridData(administration);
    }

    private void Quota_Click()
    {
        GridViewManager.Instance.SetUpGridData(quota);
    }*/
}
[Serializable]
public class GridDataItem
{
    public string ButtonText;
    public GameObject UIName;
}