using Unity.Collections;
using UnityEditor.Build;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerState currentState;
    private PlayerMoviment playerMoviment;
    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private bool justEnteredJump = false;

    void Start()
    {
       playerMoviment = GetComponent<PlayerMoviment>();  
       animator = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
       sprite = GetComponent<SpriteRenderer>();
       ChangeState(PlayerState.Idle);
       
    }
    public enum PlayerState
    {
        Idle,
        Run,
        Attack,
        Jump,
        
    }

    void Update()
    {
        FlipSprite();
        animator.SetFloat("linearVelocityY", rb.linearVelocity.y);
        switch (currentState)
        {
            case PlayerState.Idle:
                Idle();
                break;
            case PlayerState.Run:
                Run();
                break;
            case PlayerState.Jump:
                Jump();
                break;
            
        }
    }
    void FlipSprite()
    {
        if(playerMoviment.x != 0)
            sprite.flipX = playerMoviment.x < 0;
    }

    void Idle()
    {
        if(playerMoviment.x != 0 && playerMoviment.isGrounded )
        {
            ChangeState(PlayerState.Run);
        }
        if (Input.GetMouseButtonDown(0))
        {
            ChangeState(PlayerState.Attack);
        }
    
        if(!playerMoviment.isGrounded && rb.linearVelocity.y >= 0f)
            ChangeState(PlayerState.Jump);
    
    }
    void Run()
    {
        if(playerMoviment.x == 0 && playerMoviment.isGrounded)
        {
            ChangeState(PlayerState.Idle);
        }
        if (Input.GetMouseButtonDown(0))
        {
            ChangeState(PlayerState.Attack);
        }
        if(!playerMoviment.isGrounded && rb.linearVelocity.y >= 0f)
            ChangeState(PlayerState.Jump);
        }
    void Jump()
{
        if(justEnteredJump)
        {
            justEnteredJump = false;
            return; 
        }
    
        if(playerMoviment.x != 0 && playerMoviment.isGrounded)
            ChangeState(PlayerState.Run);

        if(playerMoviment.x == 0 && playerMoviment.isGrounded)
            ChangeState(PlayerState.Idle);

        if(Input.GetMouseButtonDown(0))
            ChangeState(PlayerState.Attack);
        }

    

    void ChangeState(PlayerState newState)
    {
        if(currentState == newState) return;
        ExitState();
        currentState = newState;
        EnterState(newState);
    }
    void EnterState(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Idle:
                animator.SetBool("isRunning", false);
                break;
            case PlayerState.Run:
                animator.SetBool("isRunning", true);
                break;
            case PlayerState.Attack:
                animator.SetTrigger("attack");
                break;
            case PlayerState.Jump:
                justEnteredJump = true;
                animator.SetBool("isJumping", true);
                break;
            
        }
    }
    void ExitState()
    {
        switch (currentState)
        {
            case PlayerState.Run:
                animator.SetBool("isRunning", false);
                break;
        
            case PlayerState.Jump:
                animator.SetBool("isJumping", false);
                break;
           
            
        }
    }
    void EndAttackAnimation()
    {
        if(currentState != PlayerState.Attack) return;

        if(playerMoviment.x != 0)
        {
            ChangeState(PlayerState.Run);
        }
        else if(playerMoviment.x == 0)
        {
            ChangeState(PlayerState.Idle);
        }
    }
}
