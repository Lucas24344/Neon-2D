using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   private int enemyDamage = 25;
   public float knockbackForceX = 3f;
   public float knockbackForceY = 0.9f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 direcao = (other.transform.position - transform.position).normalized;
            other.GetComponent<PlayerHealth>().PlayerTakeDamage(enemyDamage, direcao.x * knockbackForceX, knockbackForceY);
        }
    }
}
