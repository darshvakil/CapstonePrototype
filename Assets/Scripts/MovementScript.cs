using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumpForce = 7f; // Adjust as needed
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    public bool IsMoving { get; private set; }
    public bool IsJumping { get; private set; } // New jump tracking variable

    void Update()
    {
        // Get horizontal movement input
        horizontal = Input.GetAxisRaw("Horizontal");

        // Determine movement state (only when not attacking or jumping)
        IsMoving = Mathf.Abs(horizontal) > 0.1f;
        animator.SetBool("IsMoving", IsMoving && !IsJumping);

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)
        {
            Jump();
        }

        // Attack input (e.g., pressing J key)
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }

        // Flip character if needed
        Flip();
    }

    private void Attack()
    {
        animator.SetTrigger("Attack"); // Trigger attack animation
    }

    private void FixedUpdate()
    {
        // Move the character
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        IsJumping = true;
        animator.SetBool("IsJumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Assume platform is the ground
        IsJumping = false;
        animator.SetBool("IsJumping", false);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
