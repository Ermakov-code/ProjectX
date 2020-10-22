using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

  [SerializeField] private List<GameObject> prefabs;
  
  public Transform target;
  public float smoothSpeed = 0.125f;

  public Vector3 offset;

  private void FixedUpdate()
  {
    Vector3 desiredPosition = target.position + offset;
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
    transform.position = smoothedPosition;
    
    
    // Vector3 newPos  = target.position + offset;
    // newPos.z = transform.position.z;
    //
    // transform.position = newPos;
  }
}
