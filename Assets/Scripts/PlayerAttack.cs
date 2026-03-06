using UnityEngine;



public class PlayerAttack : MonoBehaviour{
private int comboSteps = 0;
private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Ataque");
            
            animator.SetInteger("attackClickCount",comboSteps);
            animator.SetTrigger("attack");
            comboSteps++;
            if(comboSteps > 2)
            {
                comboSteps = 0;
            }
        }
    }

}