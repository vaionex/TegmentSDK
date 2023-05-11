using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class UserInfoAPI : MonoBehaviour
{
    public Image UserPhoto;
    public TextMeshProUGUI UserID;
    public TextMeshProUGUI UserName;
   
    public static UserInfoAPI Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetUpData();
    }
  
  
    public async void SetUpData()
    {
        if (MenuUIManager.Instance.returndataUserInfoAPI.data.userDetails.displayName != null)
        {
            UserName.text = "Name : " + MenuUIManager.Instance.returndataUserInfoAPI.data.userDetails.displayName;
        }
        if (MenuUIManager.Instance.returndataUserInfoAPI.data.userDetails.userId != null)
        {
            UserID.text = "UserId : " + MenuUIManager.Instance.returndataUserInfoAPI.data.userDetails.userId;
        }
        if (MenuUIManager.Instance.returndataUserInfoAPI.data.userDetails.photoUrl != null)
        {
            var Texture = await NetworkManager.Instance.GetRemoteTexture(MenuUIManager.Instance.returndataUserInfoAPI.data.userDetails.photoUrl);
            UserPhoto.sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0, 0));
        }
    }

    public void GoBackToMainMenu()
    {
        MenuUIManager.Instance.SDKMenuScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
