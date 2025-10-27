using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed = 5;

    Camera veiwCamera;
    PlayerMove controller;
    void Start()
    {
        controller = GetComponent<PlayerMove>();
        veiwCamera = Camera.main;
    }

    void Update()
    {
        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * movespeed;
        controller.Move(moveVelocity);

        //Look input
        Ray ray = veiwCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point,Color.red);
            controller.LookAt(point);
        }
    }
}
