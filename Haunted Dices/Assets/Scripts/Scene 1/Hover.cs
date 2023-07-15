using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField]
    private Texture2D pointer;

    [SerializeField]
    private Transform playerTrans;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField]
    private HoverPoint[] pointsHover;
    public static int indexOfPoint = 0;

    private int GetIndexOfPoint()
    {
        int indexOfPoint = 0;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject obj = hit.collider.gameObject;
            for (int i = 0; i < pointsHover.Length; i++)
            {
                if (obj == pointsHover[i].gameObject)
                {
                    indexOfPoint = i;
                    break;
                }
            }
        }
        return indexOfPoint;
    }

    void Update()
    {
        if (pointsHover[indexOfPoint].isCursorEnter)
            Cursor.SetCursor(pointer, hotSpot, CursorMode.Auto);
        else
            Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }

    void OnMouseOver()
    {
        indexOfPoint = GetIndexOfPoint();
        pointsHover[indexOfPoint].isCursorEnter = pointsHover[indexOfPoint].isDistance()
            ? true
            : false;
    }

    void OnMouseExit()
    {
        pointsHover[indexOfPoint].isCursorEnter = false;
    }
}
