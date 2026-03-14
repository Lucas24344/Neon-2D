using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocityX = 0.9f;
    public Transform pontoA;
    public Transform pontoB;
    public float direction = 1f;
    private Transform pontoAtual;
    private EnemyHealth enemyHealth;
    enum State
    {
        Patrol
    }
    State currentState = State.Patrol;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pontoAtual = pontoB;
        enemyHealth = GetComponent<EnemyHealth>();
    }
    void FixedUpdate()
    {
        switch(currentState)
        {
            case State.Patrol:
                Patrulhar();
                break;
        }
    }
    void Patrulhar()
    {
        if (!enemyHealth.isKnockback)
        {
            rb.linearVelocity = new Vector2(velocityX * direction, rb.linearVelocity.y);
            if(Vector2.Distance(transform.position, pontoAtual.position) < 0.5f)
            {
                direction *= -1;
                pontoAtual = pontoAtual == pontoB ? pontoA : pontoB;
            }
            
        }
        
        
    }
}
