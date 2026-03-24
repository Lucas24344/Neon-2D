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
    public bool isGrounded;

    private float jumpForce = 5f;
    private int maxJumps = 2;
    private int jumpCount;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerHealth playerHealth;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>();
    }
    
    void Update()
    {
        animator.SetBool("isGrounded", isGrounded);
        x = Input.GetAxisRaw("Horizontal");

         CheckGround();

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump(); 
        }
            JumpAnimation();
            JumpFallAnimaion();
            RunAnimation(x);
    }
    
    void FixedUpdate()
    {
        if (!playerHealth.playerIsKnockback)
        {
            rb.linearVelocity = new Vector2(x * velocidade, rb.linearVelocity.y);
            
        }
        
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
        animator.SetBool("isRunning",x != 0 && isGrounded);
        if(x != 0)
        {
            spriteRenderer.flipX = x < 0;
        }
    }

    void JumpAnimation()
    { 
        bool jumping = !isGrounded && rb.linearVelocity.y > 0f && !playerHealth.playerIsKnockback;
        animator.SetBool("isJumping", jumping);
    }
    void JumpFallAnimaion()
    {
        animator.SetBool("isJumpFall", !isGrounded && rb.linearVelocity.y < -0.1f);
        
    }

    
}
