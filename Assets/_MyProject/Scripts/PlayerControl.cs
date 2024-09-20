using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Control")]
    public float speed = 5f;
    public float jumpForce = 10f;
    
    [Header("Ground Check")]
    public Transform groundCheck;
    public Vector3 groundCheckBoxSize;
    public LayerMask groundLayer; 
    public Color gizmoColor;
    float horizontalInput;
    Rigidbody rb;

    bool isGrounded;
    bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics.CheckBox(groundCheck.position,groundCheckBoxSize, Quaternion.identity, groundLayer);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector3.up * jumpForce;
        }

        if(horizontalInput > 0f && isFacingRight == false )
        {
            FlipPlayer();
        }
        else if(horizontalInput < 0f && isFacingRight == true)
        {
            FlipPlayer();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(groundCheck.position, groundCheckBoxSize);
    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}

