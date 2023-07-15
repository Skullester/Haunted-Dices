using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    private float speed;
    public Rigidbody2D rb;

    public static Animator animCharacter;

    void Start()
    {
        animCharacter = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.rotation = Quaternion.Euler(0, 0, -180);
        if (Input.GetKey(KeyCode.S))
            transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey(KeyCode.D))
            transform.rotation = Quaternion.Euler(0, 0, -270);
        if (Input.GetKey(KeyCode.A))
            transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveY = Input.GetAxis("Vertical") * speed;
        if (moveX == 0 && moveY == 0)
            animCharacter.SetBool("isRunning", false);
        else
            animCharacter.SetBool("isRunning", true);
        rb.velocity = new Vector2(moveX, moveY);
    }
}
