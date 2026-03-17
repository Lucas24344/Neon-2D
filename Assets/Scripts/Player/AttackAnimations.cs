
using UnityEngine;
public class AttackAnimations : MonoBehaviour{
private int comboSteps = 1;
private Animator animator;
private bool isAttack;
private bool queue;
private PlayerMoviment playerMoviment;
private Rigidbody2D rb;
private bool firstAttack;
public Collider2D hitBox;
private float cooldownTime;
private float timeToNextAttack = 0.2f;
private bool inCooldown;
private int lastAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMoviment = GetComponent<PlayerMoviment>();
    }
    void Update()
    {
        if (inCooldown)
        {
            cooldownTime -= Time.deltaTime;

            if(cooldownTime <= 0)
            {
                inCooldown = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            if (!isAttack && !inCooldown)
            {
                RunAnimation();  
            }
            
            else if(isAttack && !queue)
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
        isAttack = true;
        Debug.Log(comboSteps);
        lastAttack = comboSteps;
        animator.SetInteger("attackClickCount",comboSteps);
        animator.SetTrigger("attack");
        comboSteps++;
        if(comboSteps > 4)
        {
            
            comboSteps =1;
        }      
    }

    void CloseComboWindow()
    {
        if(lastAttack == 3)
        {
            inCooldown = true;
            cooldownTime = timeToNextAttack;
            comboSteps = 1;
            isAttack = false;
            queue = false;
            return;

            }

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

    void EnableCollider()
    {
        hitBox.enabled = true;
    }

    void DisableCollider()
    {
        hitBox.enabled = false;
    } 
}