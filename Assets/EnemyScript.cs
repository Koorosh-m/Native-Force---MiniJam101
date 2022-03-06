using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Animator anim;
    [SerializeField] Transform player;
    [SerializeField] float walkSpeed = 1f;
    Rigidbody2D rb2d;
    public Transform attackPoint;
    public float attackRange;
    public int damage;
    public LayerMask playerLayer;
    float timeBtwAttacks;
    public float attackTimer;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        timeBtwAttacks -= Time.deltaTime;        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer < 0.9f){
            anim.SetBool("Walking", false);
            rb2d.velocity = new Vector2(0, 0);
            if (timeBtwAttacks <= 0) {
                EnemyAttack();
            }
        } else {
            ChasePlayer();
            }

    }

    void ChasePlayer(){
        anim.SetBool("Walking", true);
        if (transform.position.x < player.position.x) {
            rb2d.velocity = new Vector2 (walkSpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        } else {
            rb2d.velocity = new Vector2(-walkSpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void EnemyAttack(){
        
        anim.SetTrigger("Attack");
        Collider2D colliderInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        colliderInfo.GetComponent<PlayerMovement>().TakeDamage(damage);
        timeBtwAttacks = attackTimer;
    }   

    // private void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    // }
}
