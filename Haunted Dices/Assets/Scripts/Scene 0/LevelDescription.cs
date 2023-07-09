using UnityEngine;
using TMPro;

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
        switch (Buttons.s_levelTitleNumber)
        {
            case 0:
                levelTitle.text = "Уровень 1";
                descriptionLevelText.text = descriptions[0];
                break;
            case 1:
                levelTitle.text = "Уровень 2";
                descriptionLevelText.text = descriptions[1];
                break;
        }
    }
}
