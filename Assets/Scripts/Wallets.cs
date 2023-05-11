using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallets : MonoBehaviour
{
    public GameObject listHolder;
    public GameObject ListItem;
    // Start is called before the first frame update
    void Start()
    {
        SetupList();
    }

    private void SetupList()
    {
        ClearChildren();
        foreach (WalletList wallet in MenuUIManager.Instance.returnDataWalletsAPI.data.wallets)
        {
            GameObject go = Instantiate(ListItem, listHolder.transform);
            go.GetComponent<WalletListItem>().SetupData(wallet.walletLogo, wallet.walletID, wallet.walletTitle);
        }
    }
    public void GoBackToMainMenu()
    {
        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ClearChildren()
    {
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[listHolder.transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in listHolder.transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }
    }
}
