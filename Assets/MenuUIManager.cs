using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;

    public List<GameObject> UIScreens;

 
    public GameObject LoginScreen;

    public GameObject SignUpScreen;

    public GameObject SDKMenuScreen;

    public GameObject SDKTitleScreen;


    

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
    }

    public void GoToTitleScreen(GameObject gb)
    {
        SDKTitleScreen.SetActive(true);
        gb.SetActive(false);
    }
}
