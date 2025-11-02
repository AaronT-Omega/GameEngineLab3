using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Subject
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public LayerMask groundLayer;
    private bool isGrounded;

    private Rigidbody rb;
    private CapsuleCollider cc;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement Input
        float horizontalInput = Input.GetAxis("Horizontal");


        Vector3 moveDirection = transform.right * horizontalInput;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Manages grounded state for jumping
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
