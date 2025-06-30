using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playerControls;
    float direction = 0;
    public Animator animator;
    public float speed = 400;
    public float jumpForce = 5;
    bool playerRight = true;
    bool ground = true;
    public Transform isGround;
    public LayerMask groundLayer;
    public Rigidbody2D playerRB;
    int jumpNumber = 0;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();

        playerControls.Land.Move.performed += context =>
        {
            direction = context.ReadValue<float>();
        };

        playerControls.Land.Jump.performed += context => {
            Jump();
        };
    }

    void FixedUpdate()
    {
        ground = Physics2D.OverlapCircle(isGround.position, 0.2f, groundLayer);

        playerRB.linearVelocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.linearVelocity.y);

        animator.SetFloat("speed", Mathf.Abs(direction));
        animator.SetBool("isGround", ground);

        if (playerRight && direction < 0 || !playerRight && direction > 0)
        {
            Flip();
        }

        if (transform.position.y < -30f)
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        playerRight = !playerRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (playerRB != null)
        {
            if (ground)
            {
                playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpForce);
                AudioManager.instance.Play("Jump1");
                jumpNumber = 0;
            }
            else if (jumpNumber == 0)
            {
                playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpForce);
                jumpNumber++;
                AudioManager.instance.Play("Jump2");
            }
        }
    }
}
