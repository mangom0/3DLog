using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] FireBall fireBall;
    PlayerMove controller;

    Camera veiwCamera;

    [Header("UI")]
    [SerializeField] private HealthBarUI healthBarUI;

    [Header("Health")]
    public float maxHp = 100f;
    public float currentHp;

    [Header("Combat / Move")]
    public float damage = 1f;
    public float moveSpeed = 5f;

    [Header("XP / Level")]
    public int level = 1;
    public float currentExp = 0f;
    public float expToNextLevel = 100f;

    [Header("Etc")]
    public float magnetRange = 3f;

    //스킬 해금 여부
    public bool _skillOneLearned = false;
    public bool _skillTwoLearned = false;
    public bool _skillThreeLearned = false;
    public bool _skillFourthLearned = false;

    void Start()
    {
        currentHp = maxHp;

        //카메라 /컨트롤러 세팅
        controller = GetComponent<PlayerMove>();
        veiwCamera = Camera.main;

        if (healthBarUI != null)
        {
            healthBarUI.UpdateBar();
        }
    }

    void Update()
    {
        MoveInput();
        LookInput();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isMoving", true);
        }
        else
            _animator.SetBool("isMoving", false);

        if (Input.GetMouseButton(0))
        {
            _animator.SetBool("isAttack", true);
            fireBall.Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("isAttack", false);
        }
    }

    //입력처리
    void MoveInput()
    {
        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
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
    // 데미지 받기
    public void TakeDamage(float amount)
    {
        currentHp -= amount;
        if (currentHp < 0f)
        {
            currentHp = 0f;
        }

        if (healthBarUI != null)
        {
            healthBarUI.UpdateBar();
        }

        if (currentHp <= 0f)
        {
            Die();
        }
    }

    // 회복
    public void Heal(float amount)
    {
        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        if (healthBarUI != null)
        {
            healthBarUI.UpdateBar();
        }
    }

    // 경험치 획득
    public void GainExp(float amount)
    {
        currentExp += amount;

        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }

        // TODO: 경험치바 UI 갱신
    }

    void LevelUp()
    {
        level++;

        // 레벨업 할 때 원하는 보상들
        maxHp += 10f;
        currentHp = maxHp;

        expToNextLevel *= 1.2f;

        // TODO: 레벨 텍스트, 효과, 사운드 등
    }

    void Die()
    {
        Debug.Log("Player Dead");
        // TODO: 게임오버 처리, 리스폰 등
    }

}
