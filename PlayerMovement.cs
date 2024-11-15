using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for the EventSystem

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to rigid boy component
    private Animator anim; // Reference to animator component
    private SpriteRenderer sr; // Reference to sprite renderer component 
    private BoxCollider2D coll; // Reference to box collider component 

    // Enumeration for different movement states
    private enum MovementState { idle, running, jumping, falling }

    public float directionX; // Current movement direction
    [SerializeField] public float moveSpeed = 7f; // Movement speed
    [SerializeField] private float jumpForce = 14f; // Jump force
    [SerializeField] private LayerMask jumpableGround; // Layer mask to identify the ground
    [SerializeField] private AudioSource jumpSound; // Reference to audio source

    // Added variables to handle button-based movement
    private bool moveLeft = false;
    private bool moveRight = false;

    private void Start()
    {
        // Initialize components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Handle movement direction based on both keyboard and button inputs
        directionX = 0f;
        if (moveLeft)
        {
            directionX -= 1f;
        }
        if (moveRight)
        {
            directionX += 1f;
        }
        
        // Add keyboard input to directionX
        directionX += Input.GetAxisRaw("Horizontal");
        
        // Update player velocity based on directionX
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        // Check for jump input
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        // Update player animation based on movement state
        UpdateAnimation();
    }

    // Method for player jump
    public void Jump()
    {
        if (IsGrounded())
        {
            jumpSound.Play(); // Play jump sound
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force
        }
    }

    // Reference: https://github.com/codinginflow/2DPlatformerBeginner/blob/master/Assets/Scripts/PlayerMovement.cs
    private void UpdateAnimation()
    {
        MovementState state;

        // Determine movement state based on directionX and player's vertical velocity
        if (directionX > 0f)
        {
            state = MovementState.running;
            sr.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sr.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

     // Check if the player is grounded
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

     // Methods to handle movement with UI buttons
    public void StartMovingLeft()
    {
        moveLeft = true;
    }

    public void StopMovingLeft()
    {
        moveLeft = false;
    }

    public void StartMovingRight()
    {
        moveRight = true;
    }

    public void StopMovingRight()
    {
        moveRight = false;
    }
}
