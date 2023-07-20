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

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (SceneManager.GetActiveScene().buildIndex != 1 && outline != null)
            outline.enabled = true;
        switch (this.gameObject.tag)
        {
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
                    textHint.text = "Бескостный язык\nПоможет разговорить кого/что угодно";
                else
                    textHint.text = "Идеальная отмычка\nПоможет вскрыть что/кого угодно";
                break;
            case "Btn2":
                if (SwitchingCharacter.indexOfCharacter == 1)
                    textHint.text =
                        "Призрачная связь\nСпособность связаться с потусторонним миром через что/кого угодно";
                else
                    textHint.text = "Орлиный глаз\nПодмечает всевозможные детали на чем/ком угодно";
                break;
        }
        if (objText != null)
        {
            objText.transform.position = Input.mousePosition;
            objText?.SetActive(true);
        }
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        print("JointDrive");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (SceneManager.GetActiveScene().buildIndex != 1 && outline != null)
            outline.enabled = false;
        if (objText != null)
            objText.SetActive(false);
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }
}
