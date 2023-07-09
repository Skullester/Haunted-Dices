using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    public static int s_levelTitleNumber;
    private GameObject panelAboutGame;
    private GameObject levelSelect;
    private GameObject settings;
    private GameObject levelDescription;

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;
        settings = transform.Find("Settings").gameObject;
        levelDescription = transform.Find("LevelDescription").gameObject;
        levelSelect = transform.Find("LevelSelect").gameObject;
        panelAboutGame = transform.Find("About").gameObject;
    }

    public void ExitGame()
    {
        Application.Quit();
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
