using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;
    public float damage = 10f;
    private Transform player;
    private float attackTimer = 0f;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < attackRange)
        {
            Attack();
        }
        else
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        if (animator != null)
        {
            animator.SetFloat("Speed", moveSpeed);
        }
    }

    void Attack()
    {
        if (attackTimer <= 0f)
        {
            Debug.Log("Enemy attacks!");

            // Logica del daño

            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }

            attackTimer = attackCooldown;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
