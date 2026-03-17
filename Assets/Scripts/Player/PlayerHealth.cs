
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 100;
    public void PlayerTakeDamage(int damage)
    {
        Debug.Log(playerHealth);
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
