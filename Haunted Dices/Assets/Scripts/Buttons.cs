using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    public static string levelName;
    private bool isLevelSelectOpened;
    private GameObject panelAboutGame;
    private GameObject levelSelect;
    private GameObject levelDescription;

    void Awake()
    {
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
            levelDescription.SetActive(true);
            levelName = EventSystem.current.currentSelectedGameObject.name;
        }
        levelSelect.SetActive(true);
    }

    public void BackToMenu()
    {
        if (levelDescription.activeSelf)
        {
            levelDescription.SetActive(false);
            return;
        }
        isLevelSelectOpened = levelSelect.activeSelf;
        levelSelect.SetActive(!levelSelect.activeSelf);
    }

    public void ShowSettings() { }

    public void ShowPanelAboutGame()
    {
        bool isPanelVisible = panelAboutGame.activeSelf;
        panelAboutGame.SetActive(!isPanelVisible);
    }
}
