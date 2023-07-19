using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YandexAD : MonoBehaviour
{
    void Start()
    {
        ShowAd();
    }

    void Update() { }

    public void ShowAd()
    {
        Application.ExternalCall("ShowAd");
    }
}
