using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridViewManager : MonoBehaviour
{
    [HideInInspector]
    public static GridViewManager Instance;

    [SerializeField]
    public GameObject ItemPrefab;
    [SerializeField]
    public GameObject ItemHolder;

    private void Awake()
    {
        Instance = this;
    }
    public void SetUpGridData(List<GridDataItem> gridDataItems)
    {
        ClearChildren();
        foreach( GridDataItem gridDataItem in gridDataItems)
        {
            GameObject goItem = Instantiate(ItemPrefab, ItemHolder.transform);
            goItem.GetComponentInChildren<TextMeshProUGUI>().text = gridDataItem.ButtonText;
            goItem.GetComponent<Button>().onClick.AddListener(() => { gridDataItem.UIName.SetActive(true); });
        }
    }
    
    public void ClearChildren()
    {
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[ItemHolder.transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in ItemHolder.transform)
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
