using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllAddress : MonoBehaviour
{
    public GameObject ListHolderPrefab;
    public GameObject ListPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ProcessData();
    }

    private void ProcessData()
    {
        string[] Alladdressess = MenuUIManager.Instance.returnDataAllAddressesAPI.data.addressess;
        foreach(string address in Alladdressess)
        {
            GameObject goList = Instantiate(ListPrefab, ListHolderPrefab.transform);
            goList.GetComponent<TextMeshProUGUI>().text = address;
        }
    }

    public void GoBackToMainMenu()
    {
        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
