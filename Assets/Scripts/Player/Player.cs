using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _animator;
    public Status playerStatus;
    public float levelExp = 0.0f;
    public float MagnetRange = 3f;
    Camera veiwCamera;
    PlayerMove controller;
    public bool _skillOneLearned = false;
    public bool _skillTwoLearned = false;
    public bool _skillThreeLearned = false;

    [SerializeField] FireBall fireBall;
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
        MoveInput();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isMoving", true);
        }
        else
            _animator.SetBool("isMoving", false);
        LookInput();
        if(Input.GetMouseButton(0))
        {
            _animator.SetBool("isAttack", true);
            fireBall.Shoot();
        }
        if(Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("isAttack", false);
        }
    }

    void MoveInput()
    {
        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * playerStatus.moveSpeed;
        controller.Move(moveVelocity);
    }

    void LookInput()
    {
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
