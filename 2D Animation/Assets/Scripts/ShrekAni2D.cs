using UnityEngine;

public class ShrekAni2D: MonoBehaviour 
{
    public float moveSpeed = 5f;

private Rigidbody2D rb;
private Animator animator;
private Vector2 movement;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
}

void Update()
{
    // Reset movement
    movement = Vector2.zero;

    if (Input.GetKey(KeyCode.D))
    {
        movement.x = 1;
        animator.SetFloat("Run", 1);
        animator.SetFloat("Dance", 0);
        animator.SetFloat("Onion", 0);
        animator.SetFloat("Idle", 0);
    }
    else if (Input.GetKey(KeyCode.A))
    {
        animator.SetFloat("Dance", 1);
        animator.SetFloat("Run", 0);
        animator.SetFloat("Onion", 0);
        animator.SetFloat("Idle", 0);
    }
    else if (Input.GetKey(KeyCode.S))
    {
        animator.SetFloat("Onion", 1);
        animator.SetFloat("Run", 0);
        animator.SetFloat("Dance", 0);
        animator.SetFloat("Idle", 0);
    }
    else
    {
        animator.SetFloat("Idle", 1);
        animator.SetFloat("Run", 0);
        animator.SetFloat("Dance", 0);
        animator.SetFloat("Onion", 0);
    }
}

void FixedUpdate()
{
    rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
}
}
