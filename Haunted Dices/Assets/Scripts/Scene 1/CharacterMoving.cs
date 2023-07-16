using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    [SerializeField]
    private float Timer = 0.35f;
    private float TimerDown = 0.0001f;
    private AudioSource audioSourceSounds;

    [SerializeField]
    private AudioClip[] footsteps;

    [SerializeField, Range(1f, 10f)]
    private float speed;

    [HideInInspector]
    public Rigidbody2D rb;

    public static Animator animCharacter;

    void Start()
    {
        audioSourceSounds = GetComponent<AudioSource>();
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

    private void Footsteps()
    {
        if (TimerDown > 0)
        {
            TimerDown -= Time.deltaTime;
        }
        if (TimerDown < 0)
        {
            audioSourceSounds.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
            TimerDown = Timer;
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveY = Input.GetAxis("Vertical") * speed;
        if (moveX != 0 || moveY != 0)
            Footsteps();
        if (moveX == 0 && moveY == 0)
        {
            animCharacter.SetBool("isRunning", false);
        }
        else
            animCharacter.SetBool("isRunning", true);
        rb.velocity = new Vector2(moveX, moveY);
    }
}
