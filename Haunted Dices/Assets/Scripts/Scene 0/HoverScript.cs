using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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
        outline = GetComponent<Outline>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
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
        }
        objText.transform.position = Input.mousePosition;
        objText.SetActive(true);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        objText.SetActive(false);
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
        outline.enabled = false;
    }
}
