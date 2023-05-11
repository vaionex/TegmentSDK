using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WalletListItem : MonoBehaviour
{
    public Image WalletLogo;
    public TextMeshProUGUI WalletId;
    public TextMeshProUGUI WalletName;

  

    public void SetupData(string WalletLogo, string strWalletId, string strWalletName)
    {
        WalletId.text = strWalletId;
        WalletName.text = strWalletName;
        if (WalletLogo != null)
        {
            SetupLogo(WalletLogo);
        }
    }

    private async void SetupLogo(string strWalletlogo)
    {
        Texture2D _texture = await NetworkManager.Instance.GetRemoteTexture(strWalletlogo);

        Sprite avtarSprite = SpriteFromTexture2D(_texture);

        WalletLogo.sprite = avtarSprite;
    }

    Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}
