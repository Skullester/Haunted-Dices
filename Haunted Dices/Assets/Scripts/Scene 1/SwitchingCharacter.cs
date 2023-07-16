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

    [SerializeField]
    private Animator[] animSkills = new Animator[s_characterNumbers];

    private Transform[] characters = new Transform[s_characterNumbers];

    void Awake()
    {
        Debug.Log(indexOfCharacter);
        indexOfCharacter = 0;

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
        for (int i = 0; i < animSkills.Length; i++)
        {
            animSkills[i].SetTrigger("Anim");
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < skillBtnsImgs.Length; i++)
        {
            btnCharacters[i].interactable = !btnCharacters[i].interactable;
        }
        characters[indexOfCharacter++].SetAsFirstSibling();
        if (indexOfCharacter == s_characterNumbers)
            indexOfCharacter = 0;
        CharacterMoving.animCharacter.SetInteger("isWoman", indexOfCharacter);
        yield return new WaitForSeconds(1f);
        ChangeCharacter(buttonIndex);
    }

    void ChangeCharacter(int buttonIndex)
    {
        int index = 0;
        for (int i = 0; i < skillBtnsImgs.Length; i++)
        {
            if (buttonIndex == 1)
                index = 1;
            skillBtnsImgs[i].sprite = skillsSprites[i + buttonIndex + index];
        }
        sRenderer.sprite = spritesCharacters[buttonIndex];
    }
}
