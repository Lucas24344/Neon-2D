using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   private int enemyDamage = 25;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().PlayerTakeDamage(enemyDamage);
        }
    }
}
