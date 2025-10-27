using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Status playerStatus;
    public float levelExp = 0.0f;
    Camera veiwCamera;
    PlayerMove controller;
    void Start()
    {
        playerStatus.hp = 100.0f;
        playerStatus.damage = 1.0f;
        playerStatus.moveSpeed = 5f;
        controller = GetComponent<PlayerMove>();
        veiwCamera = Camera.main;
    }

    void Update()
    {
        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * playerStatus.moveSpeed;
        controller.Move(moveVelocity);

        //Look input
        Ray ray = veiwCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            controller.LookAt(point);
        }
    }
}
