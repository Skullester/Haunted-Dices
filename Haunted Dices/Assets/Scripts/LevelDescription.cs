using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelDescription : MonoBehaviour
{
    [SerializeField]
    private TMP_Text descriptionLevelText;

    [SerializeField, TextArea]
    private string[] descriptions;

    private TMP_Text levelTitle;

    private void Awake()
    {
        levelTitle = transform.Find("LevelTitle").GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        switch (Buttons.levelTitle)
        {
            case "Уровень 1":
                levelTitle.text = Buttons.levelTitle;
                descriptionLevelText.text = descriptions[0];
                break;
            case "Уровень 2":
                levelTitle.text = Buttons.levelTitle;
                descriptionLevelText.text = descriptions[1];
                break;
        }
    }
}
