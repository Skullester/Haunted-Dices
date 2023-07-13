using UnityEngine;
using TMPro;
using System;
using System.Collections;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
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

    [SerializeField]
    private GameObject gameOverObj;
    private bool isDistanceAccept;

    [SerializeField, TextArea]
    private string[] textsOfPoints;

    [SerializeField]
    private TMP_Text textDice;

    public static bool isButtonClicked;
    private int indexSkillButton;

    [SerializeField]
    private GameObject[] keyPointsObjects;

    private float sqrDistancePlayer = 3;

    [SerializeField]
    private Transform player;
    private CharacterMoving playerMoving;

    [SerializeField]
    private Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField]
    private GameObject hintPoint;
    private TMP_Text textHint;

    void Awake()
    {
        playerMoving = player.GetComponent<CharacterMoving>();
        textHint = hintPoint.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        isDistanceAccept =
            (player.position - transform.position).sqrMagnitude
            < sqrDistancePlayer * sqrDistancePlayer;
    }

    void OnMouseEnter()
    {
        if (isDistanceAccept)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }

    #region cringe
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && isDistanceAccept)
        {
            CallHintMenu();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isDistanceAccept)
        {
            if (isButtonClicked)
                UseSkill(indexSkillButton);
            else
                CallHintMenu("Для взаимодействия с точкой сначала выберите умение персонажа!");
        }
    }

    private void UseSkill(int indexSkillButton)
    {
        int randomNumber = Dice.GetRandomNumber();
        textDice.text = randomNumber.ToString();
        StartCoroutine(TimerDice(randomNumber));
        Action<int, int> action = EventTree.eventDict[GetIndexOfPoint()];
        action.Invoke(SwitchingCharacter.indexOfCharacter, indexSkillButton);
    }

    public void CallHintMenu(string textHint = "")
    {
        hintPoint.SetActive(true);
        LockMovement();
        if (textHint == string.Empty)
        {
            this.textHint.text = textsOfPoints[GetIndexOfPoint()];
            return;
        }
        this.textHint.text = textHint;
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
        Pause.s_dof.active = false;
        playerMoving.enabled = true;
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
        this.indexSkillButton = indexButton;
        isButtonClicked = true;
        s_buttonIndex = indexButton;
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
        }
    }

    public void LockMovement()
    {
        Pause.s_dof.active = true;
        playerMoving.enabled = false;
        characterMoving.rb.velocity = new Vector2(0, 0);
    }
    #endregion
}
