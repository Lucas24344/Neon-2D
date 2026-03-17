
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    private int health = 100; 
    private Rigidbody2D rb;
    public bool isKnockback;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(int dano, float knockbackForceX, float knockbackForceY)
    {
        isKnockback = true;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Impulse);
        health -= dano;
        if(health <= 0)
        {
           Destroy(gameObject);
        } 
        Invoke(nameof(DisableKnockback), 0.3f); 
    } 
    void DisableKnockback()
    {
        isKnockback = false;
    }
}
