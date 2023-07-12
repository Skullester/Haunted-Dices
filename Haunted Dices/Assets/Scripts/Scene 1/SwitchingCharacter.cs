using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System;

public class SwitchingCharacter : MonoBehaviour
{
    public static int s_characterNumbers = 2;
    public static int indexOfCharacter;

    [SerializeField]
    private Image[] skillBtnsImgs;

    [SerializeField]
    private Sprite[] skillsSprites;
    private Button[] btnCharacters = new Button[s_characterNumbers];

    [SerializeField]
    private Sprite[] spritesCharacters;

    [SerializeField]
    private SpriteRenderer sRenderer;
    private Animator[] animButtons = new Animator[s_characterNumbers];

    private Transform[] characters = new Transform[s_characterNumbers];

    void Awake()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i] = transform.Find($"Character {i + 1} BTN");
            animButtons[i] = characters[i].gameObject.GetComponent<Animator>();
            btnCharacters[i] = characters[i].gameObject.GetComponent<Button>();
        }
        characters[1].SetAsFirstSibling();
    }

    public void ChangeCardsOfCharacter(int buttonIndex)
    {
        Interaction.isButtonClicked = false;
        for (int i = 0; i < animButtons.Length; i++)
        {
            bool animBtnBool = animButtons[i].GetBool("Selected");
            animButtons[i].SetBool("Selected", !animBtnBool);
        }
        StartCoroutine(DelayAnim(buttonIndex));
    }

    IEnumerator DelayAnim(int buttonIndex)
    {
        yield return new WaitForSeconds(0.5f);
        characters[indexOfCharacter++].SetAsFirstSibling();
        if (indexOfCharacter == s_characterNumbers)
            indexOfCharacter = 0;
        ChangeCharacter(buttonIndex);
    }

    void ChangeCharacter(int buttonIndex)
    {
        for (int i = 0; i < skillBtnsImgs.Length; i++)
        {
            skillBtnsImgs[i].sprite = skillsSprites[i + buttonIndex + 1];
            btnCharacters[i].interactable = !btnCharacters[i].interactable;
        }
        sRenderer.sprite = spritesCharacters[buttonIndex];
    }
}
