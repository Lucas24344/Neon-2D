
using UnityEngine;
public class StateMachine : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocityX = 1.3f;
    public Transform pontoA;
    public Transform pontoB;
    public float direction = 1f;
    private Transform pontoAtual;
    private EnemyHealth enemyHealth;
    public bool attack;
    private float timeToNextAttack = 0f;
    private float attackInterval = 0.8f;
    public Collider2D collider2D;
    public LayerMask playerLayer;
    enum State
    {
        Patrol,
        Attack
    }
    State currentState = State.Patrol;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pontoAtual = pontoB;
        enemyHealth = GetComponent<EnemyHealth>();
      
    }
    void Update()
    {
        PlayerDetected();
    }
    void FixedUpdate()
    {
        switch(currentState)
        {
            case State.Patrol:
                Patrulhar();
                break;
            case State.Attack:
                Atacar();
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
                TogglePosition();
            }     
        }
    }
    void TogglePosition()
    {
        direction *= -1;
        pontoAtual = pontoAtual == pontoB ? pontoA : pontoB;
        Vector3 pos = collider2D.transform.localPosition;
        collider2D.transform.localPosition = new Vector3(Mathf.Abs(pos.x) * direction, pos.y, pos.z);
    }
    void Atacar()
    {
        timeToNextAttack -= Time.deltaTime;
        if( timeToNextAttack <= 0)
        {
            attack = true;
            rb.linearVelocity = Vector2.zero;

            timeToNextAttack = attackInterval;            
        }
        else
        {
            attack = false;
        } 
    }
    void PlayerDetected()
    {
        RaycastHit2D hitForward = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 5f, playerLayer);
        RaycastHit2D hitBack = Physics2D.Raycast(transform.position, new Vector2(-direction, 0), 5f, playerLayer);
        if(hitForward.collider != null && hitForward.distance < 0.8f )
        {
            currentState = State.Attack;
        }
        else if(hitBack.collider != null && hitBack.distance < 0.8f)
        {
            TogglePosition();
            currentState = State.Attack;
        }
        else
        {
            attack = false;
            currentState = State.Patrol;
        }
    }
}
