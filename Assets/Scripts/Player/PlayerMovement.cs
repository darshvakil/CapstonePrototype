using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jump = false;
    bool crouch = false;

    void Update()
    {
        // Get horizontal input (A/D or Left/Right Arrow) and apply speed
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetBool("IsMoving", horizontalMove != 0);

        // Check for jump input (Space by default)
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping",true);
        }

        if (Input.GetButtonDown("crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping",false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);   
    }

    void FixedUpdate()
    {
        // Move the character (physics-based movement)
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false; // Reset jump after applying it
    }
}