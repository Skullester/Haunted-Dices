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
    private Animator animBtn1;
    private Animator animBtn2;

    private Transform[] characters = new Transform[s_characterNumbers];

    void Awake()
    {
        firstSprite = sRenderer.sprite;
        characters[0] = transform.Find("Character 1 BTN");
        characters[1] = transform.Find("Character 2 BTN");
        animBtn1 = characters[0].gameObject.GetComponent<Animator>();
        animBtn2 = characters[1].gameObject.GetComponent<Animator>();
        btnFirstCharacter = characters[0].gameObject.GetComponent<Button>();
        btnSecondCharacter = characters[1].gameObject.GetComponent<Button>();
    }

    public void ChangeCardsOfCharacter(int buttonIndex)
    {
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
        animBtn1.SetBool("IsChanging", true);
        animBtn2.SetBool("IsChanging", true);
        StartCoroutine(DelayAnim());
    }

    IEnumerator DelayAnim()
    {
        yield return new WaitForSeconds(0.5f);
        if (indexOfCharacter == s_characterNumbers)
            indexOfCharacter = 0;
        characters[indexOfCharacter++].SetAsFirstSibling();
    }
}
