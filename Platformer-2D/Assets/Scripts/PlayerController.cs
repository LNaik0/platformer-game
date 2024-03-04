using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementInputDirection;
    private Rigidbody2D rb;
    public float movementSpeed = 10.0f;
    

    // Start is called before the first frame update
    private void Start()
    {
       

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
    }
    private void FixedUpdate()
    {
        ApplyMovement();
    }
    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
    }
    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);

    }
}
