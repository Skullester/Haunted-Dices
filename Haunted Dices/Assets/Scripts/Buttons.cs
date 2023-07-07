using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private GameObject panelAboutGame;

    void Awake()
    {
        panelAboutGame = transform.Find("PanelAbout").gameObject;
    }

    private void Start() { }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowSettings() { }

    public void ShowPanelAboutGame()
    {
        bool isPanelVisible = panelAboutGame.activeSelf;
        panelAboutGame.SetActive(!isPanelVisible);
    }
}
