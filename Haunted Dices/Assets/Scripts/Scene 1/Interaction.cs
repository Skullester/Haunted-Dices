using UnityEngine;
using TMPro;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private AudioClip diceSound;

    [SerializeField]
    private Sprite[] skillsSprites;
    public static int s_buttonIndex;

    [SerializeField]
    private Image[] skillBtnsImgs;

    [SerializeField]
    private Sprite[] skillsSpritesActive;
    private Characters[] characters = new Characters[SwitchingCharacter.s_characterNumbers];

    [SerializeField]
    private CharacterMoving characterMoving;

    [SerializeField]
    private HpSystem hpSystem;

    [SerializeField]
    private AudioSource audioSourceSounds;

    [SerializeField]
    private AudioClip audioClipHPLost;

    public GameObject gameOverObj;
    private bool isDistanceAccept;

    [SerializeField, TextArea]
    private string[] textsOfPoints;

    [SerializeField]
    private TMP_Text textDice;

    public static bool isButtonClicked;
    private static int indexSkillButton;

    [SerializeField]
    private GameObject[] keyPointsObjects;

    private float sqrDistancePlayer = 3.5f;

    [SerializeField]
    private Transform player;
    private CharacterMoving playerMoving;

    [SerializeField]
    private Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

    public GameObject hintPoint;
    private TMP_Text textHint;

    [SerializeField]
    private RectTransform scale;

    [SerializeField]
    private Image[] imgChar;

    [SerializeField]
    private EventTree imageEnd;

    private int tempChar = -1;

    [SerializeField]
    private Animator animDice;
    private bool isCursorEnter;
    public static bool isSkillUsed;

    void Awake()
    {
        playerMoving = player.GetComponent<CharacterMoving>();
        textHint = hintPoint.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
    }

    void Update()
    {
        isDistanceAccept =
            (player.position - transform.position).sqrMagnitude
            < sqrDistancePlayer * sqrDistancePlayer;
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && isDistanceAccept)
        {
            CallHintMenu();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isDistanceAccept)
        {
            if (isButtonClicked)
                UseSkill();
            else
                CallHintMenu("Хм...\nИнтересно, может стоит потратить пару душ?");
        }
    }

    public void ChooseSkill(int indexButton)
    {
        if (SwitchingCharacter.indexOfCharacter == 0)
        {
            if (s_buttonIndex != indexButton)
                skillBtnsImgs[s_buttonIndex].sprite = skillsSprites[s_buttonIndex];
            skillBtnsImgs[indexButton].sprite = skillsSpritesActive[indexButton];
        }
        if (SwitchingCharacter.indexOfCharacter == 1)
        {
            if (s_buttonIndex != indexButton)
                skillBtnsImgs[s_buttonIndex].sprite = skillsSprites[s_buttonIndex + 2];
            skillBtnsImgs[indexButton].sprite = skillsSpritesActive[indexButton + 2];
        }
        indexSkillButton = indexButton;
        isButtonClicked = true;
        s_buttonIndex = indexButton;
    }

    private void UseSkill()
    {
        if (!EventTree.isTimePassed)
            return;
        animDice.SetTrigger("Rotate");
        int randomNumber = Dice.GetRandomNumber();
        audioSourceSounds.PlayOneShot(diceSound);
        textDice.text = randomNumber.ToString();
        StartCoroutine(TimerDice(randomNumber));
        Action<int, int> action = EventTree.eventDict[GetIndexOfPoint()];
        action.Invoke(SwitchingCharacter.indexOfCharacter, indexSkillButton);
    }

    public void CallHintMenu(string textHint = "")
    {
        Transform textTransorm = this.hintPoint.transform.Find("Text (TMP)");
        if (SwitchingCharacter.indexOfCharacter == 0)
        {
            ChangeScaleHint(0, textTransorm, tempChar);
        }
        else if (SwitchingCharacter.indexOfCharacter == 1)
        {
            ChangeScaleHint(1, textTransorm, tempChar);
        }

        LockMovement();
        if (textHint == string.Empty)
        {
            this.textHint.text = textsOfPoints[GetIndexOfPoint()];
            return;
        }
        this.textHint.text = textHint;
        this.tempChar = SwitchingCharacter.indexOfCharacter;
    }

    private void ChangeScaleHint(int indexChar, Transform textTransorm, int tempChar)
    {
        imgChar[indexChar].gameObject.SetActive(true);
        if (indexChar != tempChar)
        {
            scale.localScale = new Vector3(
                scale.localScale.x * -1,
                scale.localScale.y,
                scale.localScale.z
            );
            textTransorm.localScale = new Vector3(
                textTransorm.localScale.x * -1,
                textTransorm.localScale.y,
                textTransorm.localScale.z
            );
        }
        hintPoint.SetActive(true);
    }

    private int GetIndexOfPoint()
    {
        int indexOfPoint = 0;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject obj = hit.collider.gameObject;
            for (int i = 0; i < keyPointsObjects.Length; i++)
            {
                if (obj == keyPointsObjects[i])
                {
                    indexOfPoint = i;
                    break;
                }
            }
        }
        return indexOfPoint;
    }

    public void CloseHint()
    {
        hintPoint.SetActive(false);
        // Pause.s_dof.active = false;
        playerMoving.enabled = true;
        if (SwitchingCharacter.indexOfCharacter == 0)
            GameObject.Find("MartinDialog").SetActive(false);
        else
            GameObject.Find("SheronDialog").SetActive(false);
    }

    IEnumerator TimerDice(int randomNumber)
    {
        yield return new WaitForSeconds(2f);
        hpSystem.ChangeNumberSouls(randomNumber);
        audioSourceSounds.PlayOneShot(audioClipHPLost);
        if (Characters.Hp == 0)
        {
            LockMovement();
            gameOverObj.SetActive(true);
            isButtonClicked = false;
            imageEnd.imgGameOver[1].enabled = true;
            EventTree.eventDict.Clear();
        }
        yield return new WaitForSeconds(4f);
        textDice.text = string.Empty;
    }

    public void LockMovement()
    {
        CharacterMoving.animCharacter.SetBool("isRunning", false);
        //  Pause.s_dof.active = true;
        playerMoving.enabled = false;
        characterMoving.rb.velocity = new Vector2(0, 0);
    }
}
