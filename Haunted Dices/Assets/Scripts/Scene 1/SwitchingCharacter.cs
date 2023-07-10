using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class SwitchingCharacter : MonoBehaviour
{
    private static int s_characterNumbers = 2;
    public static int indexOfCharacter;

    [SerializeField]
    private Image[] skillBtnsImgs;

    [SerializeField]
    private Sprite[] skillsSprites;
    private Button btnFirstCharacter;
    private Button btnSecondCharacter;
    private Sprite firstSpriteCharacter;

    [SerializeField, FormerlySerializedAs("secondSprite")]
    private Sprite secondSpriteCharacter;

    [SerializeField]
    private SpriteRenderer sRenderer;
    private Animator[] animButtons = new Animator[s_characterNumbers];

    private Transform[] characters = new Transform[s_characterNumbers];

    void Awake()
    {
        firstSpriteCharacter = sRenderer.sprite;
        characters[0] = transform.Find("Character 1 BTN");
        characters[1] = transform.Find("Character 2 BTN");
        animButtons[0] = characters[0].gameObject.GetComponent<Animator>();
        animButtons[1] = characters[1].gameObject.GetComponent<Animator>();
        btnFirstCharacter = characters[0].gameObject.GetComponent<Button>();
        btnSecondCharacter = characters[1].gameObject.GetComponent<Button>();
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
        switch (buttonIndex)
        {
            case 0:
                for (int i = 0; i < skillBtnsImgs.Length; i++)
                {
                    skillBtnsImgs[i].sprite = skillsSprites[i];
                }
                sRenderer.sprite = firstSpriteCharacter;
                btnFirstCharacter.interactable = false;
                btnSecondCharacter.interactable = true;
                break;
            case 1:
                for (int i = 0; i < skillBtnsImgs.Length; i++)
                {
                    skillBtnsImgs[i].sprite = skillsSprites[i + 2];
                }
                sRenderer.sprite = secondSpriteCharacter;
                btnSecondCharacter.interactable = false;
                btnFirstCharacter.interactable = true;
                break;
        }
    }
}
