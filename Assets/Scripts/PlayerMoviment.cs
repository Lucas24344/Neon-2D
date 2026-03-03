using Unity.Collections;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float velocidade = 8f;
    private float x;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    bool isGrounded;

    private float jumpForce = 6f;
    private int maxJumps = 2;
    private int jumpCount;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    
    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            jumpCount = 0;
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpCount++;
    }

    void RunAnimation(float x)
    {
        animator.SetBool("isRunning", x != 0);
        if(x != 0)
        {
            spriteRenderer.flipX = x < 0;
        }
        
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        CheckGround();

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump();
        }
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x * velocidade, rb.linearVelocity.y);
        RunAnimation(x);
    }
    void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
}
    
}
