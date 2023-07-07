using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    public static int levelCounter = 0;
    public static string levelTitle;
    private bool isLevelSelectOpened;
    private GameObject panelAboutGame;
    private GameObject levelSelect;
    private GameObject settings;
    private GameObject levelDescription;

    void Awake()
    {
        settings = transform.Find("Settings").gameObject;
        levelDescription = transform.Find("LevelDescription").gameObject;
        levelSelect = transform.Find("LevelSelect").gameObject;
        panelAboutGame = transform.Find("PanelAbout").gameObject;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Play()
    {
        if (levelDescription.activeSelf)
            SceneManager.LoadScene("Game");
        isLevelSelectOpened = levelSelect.activeSelf;
        if (isLevelSelectOpened)
        {
            levelTitle = EventSystem.current.currentSelectedGameObject.transform
                .Find("Text (TMP)")
                .gameObject.GetComponent<TMP_Text>()
                .text;
            levelDescription.SetActive(true);
        }
        levelSelect.SetActive(true);
    }

    public void BackToMenu()
    {
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
        isLevelSelectOpened = levelSelect.activeSelf;
        levelSelect.SetActive(!levelSelect.activeSelf);
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
    }

    public void ShowPanelAboutGame()
    {
        bool isPanelVisible = panelAboutGame.activeSelf;
        panelAboutGame.SetActive(!isPanelVisible);
    }
}
