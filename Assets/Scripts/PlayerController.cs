using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool move = false;
    private bool jump = false;
    private bool isGrounded = false;

    public Rigidbody2D rb;

    public float speed = 20f;
    public float jumpSpeed = 100f;
    public float rotationSpeed = 20f;
    public float backRotationSpeed = 10f;


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

        if (Input.GetMouseButtonDown(0))
        {
            jump = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            jump = false;
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
        }

        if (jump && isGrounded)
        {
            rb.AddForce(transform.up * jumpSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
        }
        if (!isGrounded)
        {
            if (move)
            {
                rb.AddTorque(-rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else
            {
                //transform.Rotate(new Vector3(0 ,0 ,backRotationSpeed * Time.fixedDeltaTime * 100f));
                rb.AddTorque(backRotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("true");
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
