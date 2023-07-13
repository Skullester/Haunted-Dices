using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TMP_Text objText;
    private Outline outline;

    [SerializeField]
    private Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

    private void Update()
    {
        /*     Transform tmp = objText.transform;
            if (tmp.position != Input.mousePosition)
                objText.transform.position = Input.mousePosition; */
    }

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        objText.enabled = true;
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        objText.enabled = false;
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
        outline.enabled = false;
    }
}
