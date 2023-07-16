using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VectorGraphics;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isFirst;

    [SerializeField]
    private Sprite[] spritesWarnings;

    [SerializeField]
    private Image[] imagesWarnings;

    [SerializeField]
    private GameObject warning;
    public static int s_levelTitleNumber;
    private GameObject panelAboutGame;
    private GameObject levelSelect;
    private GameObject settings;
    private GameObject levelDescription;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField]
    private Texture2D cursorTexture;

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;
        settings = transform?.Find("Settings")?.gameObject;
        levelDescription = transform?.Find("LevelDescription")?.gameObject ?? null;
        levelSelect = transform?.Find("LevelSelect")?.gameObject ?? null;
        panelAboutGame = transform?.Find("About")?.gameObject ?? null;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        switch (this.gameObject.tag)
        {
            case "Yes":
                isFirst = true;
                imagesWarnings[0].sprite = spritesWarnings[0];
                break;
            case "No":
                isFirst = false;
                imagesWarnings[1].sprite = spritesWarnings[1];
                break;
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (isFirst)
            imagesWarnings[0].sprite = spritesWarnings[2];
        else
            imagesWarnings[1].sprite = spritesWarnings[3];
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }

    public void ExitGame()
    {
        if (warning.activeSelf)
            Application.Quit();
        warning.SetActive(true);
    }

    public void Continue()
    {
        warning.SetActive(false);
    }

    public void Play(int indexOfButton)
    {
        if (levelDescription.activeSelf)
            SceneManager.LoadScene("Game");
        if (levelSelect.activeSelf)
        {
            s_levelTitleNumber = indexOfButton;
            levelDescription.SetActive(true);
        }
        levelSelect.SetActive(true);
    }

    public void BackToMenu()
    {
        if (panelAboutGame.activeSelf)
        {
            panelAboutGame.SetActive(false);
            return;
        }
        if (settings.activeSelf)
        {
            settings.SetActive(false);
            return;
        }
        if (levelDescription.activeSelf)
        {
            levelDescription.SetActive(false);
            return;
        }
        levelSelect.SetActive(!levelSelect.activeSelf);
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
    }

    public void ShowPanelAboutGame()
    {
        panelAboutGame.SetActive(true);
    }
}
