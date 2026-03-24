

using UnityEngine;

public class Animations : MonoBehaviour
{
    private StateMachine stateMachine;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private EnemyHealth enemyHealth;
    private Rigidbody2D rb;
    
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(stateMachine.direction == 0)
        {
            IdleAnimation();
        }
        if(stateMachine.direction != 0 )
        {
            WalkAnimation();
        }
        if (stateMachine.attack)
        {
            AttackAnimation();
        }
        if (enemyHealth.isKnockback)
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isAttack", false);
            animator.SetBool("isHurt", true);
        }
        else
        {
            animator.SetBool("isHurt", false);
        }
        
    }
    void IdleAnimation()
    {
        animator.SetBool("isIdle", true);
        animator.SetBool("isWalk", false);
        animator.SetBool("isAttack", false);
        
    }
    void WalkAnimation()
    {
        animator.SetBool("isWalk", false);
        animator.SetBool("isAttack", false);
        animator.SetBool("isWalk", true);
        spriteRenderer.flipX = stateMachine.direction > 0;
    }
    void AttackAnimation()
    {
        animator.SetBool("isHurt", false);
        animator.SetBool("isWalk", false);
        animator.SetBool("isAttack", true);
        
    }
}
