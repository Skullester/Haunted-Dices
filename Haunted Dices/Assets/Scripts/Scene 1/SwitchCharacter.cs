using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField]
    private Sprite firstCharacter;
    private Sprite secondCharacter;

    [SerializeField]
    private SpriteRenderer sRenderer;

    [SerializeField]
    private Button firstCharacterBtn;

    [SerializeField]
    private Button secondCharacterBtn;

    void Awake()
    {
        secondCharacter = sRenderer.sprite;
    }

    public void ChangeSprite()
    {
        string textBtn = EventSystem.current.currentSelectedGameObject.transform
            .Find("Text (TMP)")
            .gameObject.GetComponent<TMP_Text>()
            .text;
        Debug.Log(textBtn);
        if (textBtn == "Character 1")
        {
            sRenderer.sprite = firstCharacter;
            secondCharacterBtn.interactable = true;
            firstCharacterBtn.interactable = false;
        }
        else if (textBtn == "Character 2")
        {
            sRenderer.sprite = secondCharacter;
            firstCharacterBtn.interactable = true;
            secondCharacterBtn.interactable = false;
        }
    }
}
