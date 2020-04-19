using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text favorLeftText;
    public Text WeaponLevelText;
    public Text WeaponUpgradeCostText;
    public Text WallLevelText;
    public Text WallUpgradeCostText;
    public Text WallRestoreCostText;
    public Texture2D cursor;
    // Start is called before the first frame update
    void Start()
    {
        if (favorLeftText != null)
        {
            favorLeftText.text = "Favor left: 0";
        }
        if (WeaponLevelText != null)
        {
            WeaponLevelText.text = "Weapon level: 1";
        }
        if (WeaponUpgradeCostText != null)
        {
            WeaponUpgradeCostText.text = "Cost: 1";
        }
        if (WallLevelText != null)
        {
            WallLevelText.text = "Wall level: 1";
        }
        if (WallUpgradeCostText != null)
        {
            WallUpgradeCostText.text = "Cost: 1";
        }
        if (WallRestoreCostText != null)
        {
            WallRestoreCostText.text = "Cost: 1";
        }
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
        favorLeftText.text = "Favor left: " + newFavorleft;
    }
    public void updatePlayerWeaponLevel(int weaponlevel)
    {
        WeaponLevelText.text = "Weapon level: " + weaponlevel;
    }
    public void updateWallDefenseLevel(int walldefenselevel)
    {
        WallLevelText.text = "Wall level: " + walldefenselevel;
    }
    public void updateWallUpgradeCost(int wallupgradecost)
    {
        WallUpgradeCostText.text = "Cost: " + wallupgradecost;
    }
    public void updateWeaponUpgradeCost(int weaponupgradecost)
    {
        WeaponUpgradeCostText.text = "Cost: " + weaponupgradecost;
    }
    public void updateWallRestoreCost(int wallrestorecost)
    {
        WallRestoreCostText.text = "Cost: " + wallrestorecost;
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

    
}
