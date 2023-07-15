using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPoint : MonoBehaviour
{
    private bool isDistanceAccept;

    [SerializeField]
    private Transform playerTrans;
    private bool isCursorEnter;

    private Vector2 hotSpot = Vector2.zero;
    private float sqrDistancePlayer = 3.5f;

    [SerializeField]
    private Texture2D pointer;
    private bool isEntered;

    void Update()
    {
        Debug.Log(isDistanceAccept);
        isDistanceAccept =
            (playerTrans.position - transform.position).sqrMagnitude
            < sqrDistancePlayer * sqrDistancePlayer;
        if (isCursorEnter)
        {
            Cursor.SetCursor(pointer, hotSpot, CursorMode.Auto);
        }
        if (!isEntered && !isCursorEnter)
        {
            Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
        }
    }

    void OnMouseOver()
    {
        isCursorEnter = isDistanceAccept ? true : false;
    }

    void OnMouseExit()
    {
        isCursorEnter = false;
    }
}
