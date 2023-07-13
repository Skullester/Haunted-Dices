using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TMP_Text textHint;

    [SerializeField]
    private GameObject objText;
    private Outline outline;

    [SerializeField]
    private Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

    private void Update()
    {
        /*  if (objText.gameObject.transform.position != Input.mousePosition)
             objText.transform.position = Input.mousePosition; */
    }

    private void Awake()
    {
        outline = GetComponent<Outline>() ?? null;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
            outline.enabled = true;
        switch (this.gameObject.tag)
        {
            case "Yes":

            case "Radio":
                textHint.text = "Настройки";
                break;
            case "Board":
                textHint.text = "Играть";
                break;
            case "Magazine":
                textHint.text = "Об игре";
                break;
            case "Lamp":
                textHint.text = "Выйти";
                break;
            case "Btn1":
                if (SwitchingCharacter.indexOfCharacter == 0)
                {
                    textHint.text = "Бескостный язык\nПоможет разговорить кого/что угодно";
                    // textSkill.text = "";
                }
                else
                {
                    textHint.text = "Идеальная отмычка\nПоможет вскрыть что/кого угодно";
                    //textSkill.text = "Призрачная связь";
                }
                break;
            case "Btn2":
                if (SwitchingCharacter.indexOfCharacter == 1)
                {
                    textHint.text =
                        "Призрачная связь\nСпособность связаться с потусторонним миром через что/кого угодно";
                    // textSkill.text = "Орлиный глаз";
                }
                else
                {
                    textHint.text = "Орлиный глаз\nПодмечает всевозможные детали на чем/ком угодно";
                    //textSkill.text = "Идеальная отмычка";
                }
                break;
        }
        objText.transform.position = Input.mousePosition;
        objText.SetActive(true);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
            outline.enabled = false;
        objText.SetActive(false);
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }
}
