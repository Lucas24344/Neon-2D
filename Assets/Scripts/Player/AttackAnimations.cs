
using UnityEngine;
public class AttackAnimations : MonoBehaviour{
private int comboSteps = 1;
private Animator animator;
private bool isAttack;
private bool queue;
private PlayerMoviment playerMoviment;
private Rigidbody2D rb;
public Collider2D hitBox;
private float cooldownTime;
private float timeToNextAttack = 0.5f;
private bool inCooldown;
private int lastAttack;
private CameraShake cameraShake;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMoviment = GetComponent<PlayerMoviment>();
        cameraShake = FindObjectOfType<CameraShake>();
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
                Attack();  
            }
            
            else if(isAttack && !queue)
            {
                queue = true;
            }     
        }

    }

    void Attack()
    {
        cameraShake.Shake(0.8f, 0.2f);
        isAttack = true;
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
            Attack(); 
        }
        else
        {
            
            comboSteps = 1;
            isAttack = false;
        } 
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