using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    private float speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveY = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector2(moveX, moveY);
    }
}
