using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text favorLeftText;
    private int favorLeft = 0;
    private int WeaponLevel = 0;
    private int WallDefenseLevel = 0;
    public Texture2D cursor;
    // Start is called before the first frame update
    void Start()
    {
        if (favorLeftText != null)
        {
            favorLeftText.text = "Favor left: " + favorLeft;
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
        favorLeft = newFavorleft;
        favorLeftText.text = "Favor left: " + favorLeft;
    }

    public void ShowUpgradeScreen(int favor, int playerweaponlevel, int walldefenselevel)
    {
        updateFavorLeft(favor);
        WeaponLevel = playerweaponlevel;
        WallDefenseLevel = walldefenselevel;
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
        var close_clicked_handler = CloseUpgradeScreenClicked;
        close_clicked_handler(this, null);
    }

    
}
