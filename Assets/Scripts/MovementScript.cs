using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    public bool IsMoving { get; private set; } // Default is false
    private bool facingRight = true; // To track player direction

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        Move();
        Jump();
        UpdateAnimation();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // -1 (left), 1 (right), 0 (idle)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Set IsMoving based on input
        IsMoving = (moveInput != 0);

        // Flip character if moving in a different direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void UpdateAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("IsMoving", IsMoving); // Update Animator parameter
        }
    }

    void Flip()
    {
        facingRight = !facingRight; // Toggle direction
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip sprite
        transform.localScale = scale;
    }
}
