using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool move = false;
    private bool isGrounded = false;

    public Rigidbody2D rb;

    public float speed = 20f;
    public float rotationSpeed = 20f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            move = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            move = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (move == true)
        {
            if (isGrounded)
            {
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else
            {
                rb.AddTorque(rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}
