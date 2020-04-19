using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite[] FavorSprites;
    public Image FavorImage;
    public Sprite[] WeaponUpgradeSprites;
    private Sprite WeaponUpgradeSprite;
    private Sprite WeaponUpgradeHoverSprite;
    public Image WeaponUpgradImage;
    public Sprite[] WallUpgradeSprites;
    private Sprite WallUpgradeSprite;
    private Sprite WallUpgradeHoverSprite;
    public Image WallUpgradeImage;
    public Sprite[] WallRestoreSprites;
    private Sprite WallRestoreSprite;
    private Sprite WallRestoreHoverSprite;
    public Image WallRestoreImage;
    public Image CloseUpgradeScreenImage;
    public Sprite ExitSprite;
    public Sprite ExitHoverSprite;
    public Texture2D cursor;
    void Start()
    {
        if (gameObject != null || !gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateFavorLeft(int newFavorleft)
    {
        if (newFavorleft >= FavorSprites.Length)
        {
            FavorImage.sprite = FavorSprites[FavorSprites.Length - 1];
        } 
        else if (newFavorleft > 0)
        {
            FavorImage.sprite = FavorSprites[newFavorleft - 1];
        } 
        else
        {
            FavorImage.sprite = FavorSprites[0];
        }
    }
    public void updatePlayerWeaponLevel(int weaponlevel)
    {
        switch (weaponlevel)
        {
            case 1:
                WeaponUpgradImage.sprite = WeaponUpgradeSprite = WeaponUpgradeSprites[0];
                WeaponUpgradeHoverSprite = WeaponUpgradeSprites[1];
                break;
            case 2:
                WeaponUpgradImage.sprite = WeaponUpgradeSprite = WeaponUpgradeSprites[2];
                WeaponUpgradeHoverSprite = WeaponUpgradeSprites[3];
                break;
            case 3:
                WeaponUpgradImage.sprite = WeaponUpgradeHoverSprite = WeaponUpgradeSprite = WeaponUpgradeSprites[4];
                break;
            default:
                WeaponUpgradImage.sprite = WeaponUpgradeSprites[0];
                break;
        }

    }
    public void updateWallDefenseLevel(int walldefenselevel)
    {
        switch (walldefenselevel)
        {
            case 1:
                WallUpgradeImage.sprite = WallUpgradeSprite = WallUpgradeSprites[0];
                WallUpgradeHoverSprite = WallUpgradeSprites[1];
                break;
            case 2:
                WallUpgradeImage.sprite = WallUpgradeSprite = WallUpgradeSprites[2];
                WallUpgradeHoverSprite = WallUpgradeSprites[3];
                break;
            case 3:
                WallUpgradeImage.sprite = WallUpgradeHoverSprite = WallUpgradeSprite = WallUpgradeSprites[4];
                break;
            default:
                WallUpgradeImage.sprite = WallUpgradeSprite = WallUpgradeSprites[0];
                WallUpgradeHoverSprite = WallUpgradeSprites[1];
                break;
        }
    }
    public void updateWallUpgradeCost(int wallupgradecost)
    {
    }
    public void updateWeaponUpgradeCost(int weaponupgradecost)
    {
    }
    public void updateWallRestoreCost(int wallrestorecost)
    {
        switch (wallrestorecost)
        {
            default:
                WallRestoreImage.sprite = WallRestoreSprite = WallRestoreSprites[0];
                WallRestoreHoverSprite = WallRestoreSprites[1];
                break;
        }
    }
    
    public void ShowUpgradeScreen(int favor, int playerweaponlevel, int walldefenselevel, int weaponupgradecost, int wallupgradecost, int wallrestorecost)
    {
        updateFavorLeft(favor);
        updatePlayerWeaponLevel(playerweaponlevel);
        updateWallDefenseLevel(walldefenselevel);
        updateWeaponUpgradeCost(weaponupgradecost);
        updateWallUpgradeCost(wallupgradecost);
        updateWallRestoreCost(wallrestorecost);
        gameObject.SetActive(true);
    }
    public void CloseUpgradeScreen()
    {
        gameObject.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        var cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
    }

    public event EventHandler Upgrade1_Clicked;
    public void clickUpgrade1()
    {
        var upgrade1_clicked_handler = Upgrade1_Clicked;
        upgrade1_clicked_handler(this, null);

    }
    public event EventHandler Upgrade2_Clicked;
    public void clickUpgrade2()
    {
        var upgrade2_clicked_handler = Upgrade2_Clicked;
        upgrade2_clicked_handler(this, null);
    }
    public event EventHandler Upgrade3_Clicked;
    public void clickUpgrade3()
    {
        var upgrade3_clicked_handler = Upgrade3_Clicked;
        upgrade3_clicked_handler(this, null);
    }
    public event EventHandler CloseUpgradeScreenClicked;
    public void ClickCloseUpgradeScreen()
    {
        Debug.Log("At least the click is registered");
        var close_clicked_handler = CloseUpgradeScreenClicked;
        close_clicked_handler(this, null);
    }
    public event EventHandler SummonTheUncleanOne_Clicked;
    public void SummonTheUncleanOneClicked()
    {
        var summon_click_handler = SummonTheUncleanOne_Clicked;
        summon_click_handler(this, null);
    }

    public void onWeaponUpgradePointerEnter()
    {
        WeaponUpgradImage.sprite = WeaponUpgradeHoverSprite;
    }
    public void onWeaponUpgradePointerExit()
    {
        WeaponUpgradImage.sprite = WeaponUpgradeSprite;
    }
    public void onWallUpgradePointerEnter()
    {
        WallUpgradeImage.sprite = WallUpgradeHoverSprite;
    }
    public void onWallUpgradePointerExit()
    {
        WallUpgradeImage.sprite = WallUpgradeSprite;
    }
    public void onWallRestorePointerEnter()
    {
        WallRestoreImage.sprite = WallRestoreHoverSprite;
    }
    public void onWallRestorePointerExit()
    {
        WallRestoreImage.sprite = WallRestoreSprite;
    }
    public void onPentagramPointerEnter()
    {
        FavorImage.color = new Color(FavorImage.color.r, FavorImage.color.g, FavorImage.color.b, 1f);
    }
    public void onPentagramPointerExit()
    {
        FavorImage.color = new Color(FavorImage.color.r, FavorImage.color.g, FavorImage.color.b, 0.5f);
    }
    public void onCloseScreenPointerEnter()
    {
        CloseUpgradeScreenImage.sprite = ExitHoverSprite;
    }
    public void onCloseScreenPointerExit()
    {
        CloseUpgradeScreenImage.sprite = ExitSprite;
    }

}
