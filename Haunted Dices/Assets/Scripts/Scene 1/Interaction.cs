using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    private bool isDistanceAccept;

    [SerializeField, TextArea, Space(1)]
    private string[] textsOfPoints;

    [SerializeField]
    private TMP_Text textDice;

    //private static int s_indexOfInteractedPoint;
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
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
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
                UseSkill(indexSkillButton);
            else
                CallHintMenu("Для взаимодействия с точкой сначала выберите умение персонажа!");
        }
    }

    private void UseSkill(int indexSkillButton)
    {
        Debug.Log(
            $"{SwitchingCharacter.indexOfCharacter + 1} перс и {indexSkillButton + 1} кнопка"
        );
        textDice.text = Dice.GetRandomNumber().ToString();
    }

    private void CallHintMenu(string textHint = "")
    {
        if (textHint == string.Empty)
        {
            this.textHint.text = textsOfPoints[GetIndexOfPoint()];
        }
        else
            this.textHint.text = textHint;
        Pause.s_dof.active = true;
        hintPoint.SetActive(true);
        playerMoving.enabled = false;
        CharacterMoving.rb.velocity = new Vector2(0, 0);
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
        this.indexSkillButton = indexButton;
        isButtonClicked = true;
    }
}
