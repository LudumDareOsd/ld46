using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text favorLeftText;
    private int favorLeft = 0;
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

    public void ShowUpgradeScreen()
    {
        gameObject.SetActive(true);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void clickUpgrade1()
    {
        Debug.Log("Clicked upgrade 1");
    }
    public void clickUpgrade2()
    {
        Debug.Log("Clicked upgrade 2");
    }

    public void clickUpgrade3()
    {
        Debug.Log("Clicked upgrade 3");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
    }
}
