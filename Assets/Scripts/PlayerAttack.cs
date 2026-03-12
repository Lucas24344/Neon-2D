


using UnityEngine;
public class PlayerAttack : MonoBehaviour{
private int comboSteps = 1;
private Animator animator;
private bool isAttack;
private bool queue;

    void Start()
    {
        animator = GetComponent<Animator>();
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

}