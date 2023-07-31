using UnityEngine;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private AudioClip chooseSound;

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

    private bool tempChar = false;

    [SerializeField]
    private Animator animDice;
    private bool isCursorEnter;
    public static bool isSkillUsed;

    public static Dictionary<(int, int, int), bool> SkillsUsed =
        new Dictionary<(int, int, int), bool>();

    void Awake()
    {
        playerMoving = player.GetComponent<CharacterMoving>();
        textHint = hintPoint.transform.Find("HintPoint").GetComponentInChildren<TMP_Text>();
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
            if (
                isButtonClicked
                && SkillsUsed[
                    (SwitchingCharacter.indexOfCharacter, indexSkillButton, GetIndexOfPoint())
                ] == false
            )
                UseSkill();
            else if (
                isButtonClicked
                && SkillsUsed[
                    (SwitchingCharacter.indexOfCharacter, indexSkillButton, GetIndexOfPoint())
                ]
            )
                CallHintMenu(
                    "*Эта способность уже была использована для этой точки*\n А ведь голос в моей голове мне не лжет!"
                );
            else
                CallHintMenu(
                    "*Для взаимодействия с этим необходимо сначала выбрать умение*\nЧто?! Откуда этот голос в моей голове?"
                );
        }
    }

    public void ChooseSkill(int indexButton)
    {
        audioSourceSounds.PlayOneShot(chooseSound);
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
        Transform textTransorm = this.textHint.transform;
        ChangeScaleHint(SwitchingCharacter.indexOfCharacter, textTransorm, tempChar);
        LockMovement();
        if (textHint == string.Empty)
        {
            this.textHint.text = textsOfPoints[GetIndexOfPoint()];
            return;
        }
        this.textHint.text = textHint;
    }

    private void ChangeScaleHint(int indexChar, Transform textTransorm, bool tempChar)
    {
        imgChar[indexChar].gameObject.SetActive(true);
        if (indexChar != Convert.ToInt32(tempChar))
        {
            this.tempChar = !tempChar;
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
        if (Characters.Hp == 0 || EventTree.isEND)
        {
            LockMovement();
            gameOverObj.SetActive(true);
            isButtonClicked = false;
            imageEnd.imgGameOver[2].enabled = true;
        }
        hintPoint.SetActive(false);
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
        yield return new WaitForSeconds(5f);
        textDice.text = string.Empty;
    }

    public void LockMovement()
    {
        CharacterMoving.animCharacter.SetBool("isRunning", false);
        playerMoving.enabled = false;
        characterMoving.rb.velocity = new Vector2(0, 0);
    }
}
