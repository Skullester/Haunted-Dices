using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField, TextArea, Space(1)]
    private string[] textsOfPoints;

    //private static int s_indexOfInteractedPoint;

    [SerializeField]
    private GameObject[] keyPointsObjects;

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
    private TMP_Text textHint;

    void Awake()
    {
        playerMoving = player.GetComponent<CharacterMoving>();
        textHint = hintPoint.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
    }

    void OnMouseEnter()
    {
        if ((player.position - transform.position).sqrMagnitude < sqrDistance * sqrDistance)
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }

    void OnMouseOver()
    {
        if (
            Input.GetKeyDown(KeyCode.Mouse1)
            && (player.position - transform.position).sqrMagnitude < sqrDistance * sqrDistance
        )
        {
            CallHintMenu();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bool isSomething = false;
            if (isSomething)
                Debug.Log("dsada");
            else
                CallHintMenu("Для взаимодействия с точкой сначала выберите умение персонажа!");
        }
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
}
