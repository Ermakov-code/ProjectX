using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour
{
    public float speed = 1500f;

    public bool move = false;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move = Input.GetButton("Fire1");
    }

    private void FixedUpdate()
    {
        if (move)
        {
            rb.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode2D.Force);
            //frontWheel.motor = new JointMotor2D {motorSpeed = -speed, maxMotorTorque = frontWheel.motor.maxMotorTorque};
            //backWheel.motor = new JointMotor2D {motorSpeed = -speed, maxMotorTorque = backWheel.motor.maxMotorTorque};
        }
        else
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
    }
}
