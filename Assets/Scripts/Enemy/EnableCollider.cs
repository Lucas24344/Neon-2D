using UnityEngine;

public class EnableCollider : MonoBehaviour
{
     public Collider2D hitbox;
    void EnableEnemyCollider()
    {
        hitbox.enabled = true;
    }
    void DisableEnemyCollider()
    {
        hitbox.enabled = false;
    }
}
