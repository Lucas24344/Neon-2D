using UnityEngine;
public class PlayerAttack : MonoBehaviour{
private int comboSteps = 1;
private Animator animator;
private bool isAttack;
private bool queue;

private PlayerMoviment playerMoviment;
private Rigidbody2D rb;
private bool firstAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMoviment = GetComponent<PlayerMoviment>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!isAttack)
            {
                RunAnimation();  
            }
            else if(!queue)
            {
                queue = true;
            }     
        }
        if (playerMoviment.isGrounded)
        {
            firstAttack = false;
        }
        if (!firstAttack && !playerMoviment.isGrounded)
        {
            attackSuspensionInAir();
        } 
    }

    void attackSuspensionInAir()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            firstAttack = true;
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.zero;
            Invoke(nameof(ResetGravity), 0.2f);
        }
    }

    void RunAnimation()
    {
        Debug.Log(comboSteps);
        isAttack = true;
               animator.SetInteger("attackClickCount",comboSteps);
            animator.SetTrigger("attack");
            comboSteps++;
            if(comboSteps > 2)
            {
                comboSteps =1;
            }      
    }

    void CloseComboWindow()
    {
        if (queue)
        {
            queue = false;
            RunAnimation(); 
        }
        else
        {
            comboSteps = 1;
            isAttack = false;
        } 
    }
    void ResetGravity()
    {
        rb.gravityScale = 2;
    }
}