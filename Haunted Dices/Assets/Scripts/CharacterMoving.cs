using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    private float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake() { }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveY = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector2(moveX, moveY);
    }
}
