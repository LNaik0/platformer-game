using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementInputDirection;
    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool canJump;

    private Rigidbody2D rb;
    private Animator anim;
    public float movementSpeed = 10.0f;
    
    public float jumpforce = 16.0f;
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {

        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();



    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }
    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }
    
    
    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0) {
            Flip();
        
        }
        else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
        if(rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

    }
    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);

    }
    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }
    }
    private void Jump()
    {
        if(canJump) {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        
    }
    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);

    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
