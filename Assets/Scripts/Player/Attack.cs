
using UnityEngine;

public class Attack : MonoBehaviour
{
    private int damage = 10;
    public float knockbackForceX = 2f;
    public float knockbackForceY = 0.6f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector2 direcao = (other.transform.position - transform.position).normalized;
            other.GetComponent<EnemyHealth>().TakeDamage(damage, direcao.x * knockbackForceX,knockbackForceY );
        }
    }
}
