using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 100; 
    public void TakeDamage(int dano)
    {
        health -= dano;
        if(health <= 0)
        {
           Destroy(gameObject); 
        }
        
    }
}
