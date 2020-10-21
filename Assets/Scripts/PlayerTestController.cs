using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour
{
    public float speed = 1500f;
    public float rotationSpeed = 10f;
    public float jumpSpeed = 10f;
    public bool move = false;

 
    public WheelsColider wheelCol;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;
    
    private Rigidbody2D rb;

   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude < 10)
        {
                
        }
      
        
        move = Input.GetButton("Fire1");
    }

    private void FixedUpdate()
    {
        if (wheelCol.isGrounded)
        {
            //Debug.Log("run!");
            rb.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode2D.Force);
            //rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
            //rb.velocity = transform.right * speed;

        }
        if (!wheelCol.isGrounded)
        {
            
            if (move)
            {
                transform.RotateAround(transform.localPosition, Vector3.back, rotationSpeed *  Time.fixedDeltaTime);
              
            }
            else
            {
                transform.RotateAround(transform.localPosition, Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
                Debug.Log("backRotation");
            }
        }
        if (move && wheelCol.isGrounded)
        {
            rb.AddForce(transform.up * jumpSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            
        }
        
    }
    
}
