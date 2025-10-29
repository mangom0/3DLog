using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void LookAt(Vector3 lookpoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookpoint.x, transform.position.y, lookpoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
    public void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
