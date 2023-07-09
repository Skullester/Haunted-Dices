using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingCharacter : MonoBehaviour
{
    private static int s_characterNumbers = 2;
    private int indexOfCharacter;
    private Button btnFirstCharacter;
    private Button btnSecondCharacter;
    private Sprite firstSprite;

    [SerializeField]
    private Sprite secondSprite;

    [SerializeField]
    private SpriteRenderer sRenderer;
    private Animator[] animButtons = new Animator[s_characterNumbers];

    private Transform[] characters = new Transform[s_characterNumbers];

    void Awake()
    {
        firstSprite = sRenderer.sprite;
        characters[0] = transform.Find("Character 1 BTN");
        characters[1] = transform.Find("Character 2 BTN");
        animButtons[0] = characters[0].gameObject.GetComponent<Animator>();
        animButtons[1] = characters[1].gameObject.GetComponent<Animator>();
        btnFirstCharacter = characters[0].gameObject.GetComponent<Button>();
        btnSecondCharacter = characters[1].gameObject.GetComponent<Button>();
    }

    public void ChangeCardsOfCharacter(int buttonIndex)
    {
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
        if (indexOfCharacter == s_characterNumbers)
            indexOfCharacter = 0;
        characters[indexOfCharacter++].SetAsFirstSibling();
        switch (buttonIndex)
        {
            case 0:
                sRenderer.sprite = firstSprite;
                btnFirstCharacter.interactable = false;
                btnSecondCharacter.interactable = true;
                break;
            case 1:

                sRenderer.sprite = secondSprite;
                btnSecondCharacter.interactable = false;
                btnFirstCharacter.interactable = true;
                break;
        }
    }
}
