using UnityEngine;

public class SprizeSize : MonoBehaviour
{
    private Vector3 transformPos;
    private Vector3 transformScale;
    private Vector3 transform2;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResizeSprite();
    }

    private void ResizeSprite()
    {
        bool isScreen = false;
        Vector3 scale = spriteRenderer.transform.localScale;
        if (Screen.width > 1920)
        {
            transformPos = new Vector3(-62.2514f, transform.position.y, transform.position.z);
            transformScale = new Vector3(3.135089f, transform.localScale.y, transform.localScale.z);
            isScreen = true;
        }
        if (Screen.width <= 1920)
        {
            transformPos = new Vector3(-62.2514f, transform.position.y, transform.position.z);
            transformScale = new Vector3(3.135089f, transform.localScale.y, transform.localScale.z);
            isScreen = true;
        }
        if (!isScreen)
            return;
        spriteRenderer.transform.position = transformPos;
        spriteRenderer.transform.localScale = transformScale;
    }
}
