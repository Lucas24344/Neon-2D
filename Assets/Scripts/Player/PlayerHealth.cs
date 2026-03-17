
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 100;
    private Rigidbody2D rb;
    public bool playerIsKnockback;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void PlayerTakeDamage(int damage, float knockbackForceX, float knockbackForceY)
    {
        playerIsKnockback = true;
        rb.linearVelocity = Vector2.zero;
        rb.linearVelocity = new Vector2(knockbackForceX, knockbackForceY);
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
        Invoke(nameof(DisablePlayerKnockback), 0.3f);
        
    }

    void DisablePlayerKnockback()
    {
        playerIsKnockback = false;
    }
}
