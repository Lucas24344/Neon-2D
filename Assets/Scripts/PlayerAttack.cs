

using UnityEngine;
public class PlayerAttack : MonoBehaviour{
private int comboSteps = 1;
private Animator animator;
private bool isAttack;
private float bufferTime = 0.8f;
private float bufferCount;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
             
            bufferCount = bufferTime;
               
        }
        if(bufferCount > 0)
        {
            bufferCount -= Time.deltaTime;
        }
        if(bufferCount > 0 && !isAttack)
        {
            
            isAttack = true;
            bufferCount = 0;
            RunAnimation();
            
            Invoke(nameof(ResetAttack), 0.6f);
        }
        
    }
    void RunAnimation()
    {
         Debug.Log(comboSteps);
               animator.SetInteger("attackClickCount",comboSteps);
            animator.SetTrigger("attack");
            comboSteps++;
         
            
            if(comboSteps > 2)
            {
                comboSteps =1;
            }
            
    }
    void ResetAttack()
    {
        isAttack = false;
    }

}