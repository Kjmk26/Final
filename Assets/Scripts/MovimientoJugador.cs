using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        bool isMoving = movement != Vector2.zero;
        animator.SetBool("isMoving", isMoving);
        Move();
    }

    void Move()
    {
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
