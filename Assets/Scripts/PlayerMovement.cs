using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[Header("Movement")] public float moveSpeed;

    //public Transform orientation;

    public Animator playerAnimator;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    private Rigidbody rb;

    public float speed;

    public bool isJumping;
    public float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, 0);
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalInput));
        // if (horizontalInput < 0)
        // {
        //     // Rotate the object 180 degrees around the Y axis
        //     transform.rotation = Quaternion.Euler(0, 180, 0);
        //     moveDirection = new Vector3(horizontalInput * -1, 0, 0);
        // }
        // else
        // {
        //     // Reset the rotation to its original state
        //     transform.rotation = Quaternion.Euler(0, 0, 0);
        // }

        moveDirection.Normalize();
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}