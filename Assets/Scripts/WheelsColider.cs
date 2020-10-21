using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsColider : MonoBehaviour
{
    public bool isGrounded = false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
