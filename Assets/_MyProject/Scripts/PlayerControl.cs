using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public Vector3 groundCheckBoxSize;
    public LayerMask groundLayer; 
    float horizontalInput;
    Rigidbody rb;

    bool isGrounded;

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

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, 0);
    }

}
