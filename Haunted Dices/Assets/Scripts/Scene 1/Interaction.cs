using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField, Range(1f, 15f)]
    private float sqrDistance;

    [SerializeField]
    private Transform player;
    private CharacterMoving playerMoving;

    [SerializeField]
    private Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField]
    private GameObject hintPoint;

    void Awake()
    {
        playerMoving = player.GetComponent<CharacterMoving>();
    }

    void Update() { }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }

    void OnMouseOver()
    {
        Debug.Log((player.position - transform.position).sqrMagnitude);
        if (
            Input.GetKeyDown(KeyCode.Mouse1)
            && (player.position - transform.position).sqrMagnitude < sqrDistance * sqrDistance
        )
        {
            Pause.s_dof.active = true;
            hintPoint.SetActive(true);
            playerMoving.enabled = false;
            CharacterMoving.rb.velocity = new Vector2(0, 0);
        }
    }

    public void CloseHint()
    {
        hintPoint.SetActive(false);
        Pause.s_dof.active = false;
        playerMoving.enabled = true;
    }
}
