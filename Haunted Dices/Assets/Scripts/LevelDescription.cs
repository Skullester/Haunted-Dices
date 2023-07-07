using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelDescription : MonoBehaviour
{
    /*    enum Levels
       {
           First,
           Second
       } */

    private TMP_Text levelTitle;

    private void Awake()
    {
        levelTitle = transform.Find("LevelTitle").GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        levelTitle.text = Buttons.levelName;
    }
}
