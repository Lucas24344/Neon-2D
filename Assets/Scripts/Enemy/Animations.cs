
using UnityEngine;

public class Animations : MonoBehaviour
{
    private StateMachine stateMachine;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if(stateMachine.direction != 0)
        {
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = stateMachine.direction > 0;
        }
        
    }
}
