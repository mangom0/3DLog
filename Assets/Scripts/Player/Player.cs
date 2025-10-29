using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] FireBall fireBall;
    [SerializeField] Shield shield;
    PlayerMove controller;

    Camera veiwCamera;

    [Header("UI")]
    [SerializeField] private HealthBarUI healthBarUI;
    [SerializeField] private ExpBarUI expBarUI;

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

    //��ų �ر� ����
    public bool _skillOneLearned = false;
    public bool _skillTwoLearned = false;
    public bool _skillThreeLearned = false;
    public bool _skillFourthLearned = false;
    public bool isShieldActive = false;

    void Start()
    {
        currentHp = maxHp;

        //ī�޶� /��Ʈ�ѷ� ����
        controller = GetComponent<PlayerMove>();
        veiwCamera = Camera.main;

        if (healthBarUI != null)
        {
            healthBarUI.UpdateBar();
        }
        if (expBarUI != null)
        {
            expBarUI.UpdateBar(); // ����ġ�� / ���� �ؽ�Ʈ ó�� ���� �ݿ�
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

    //�Է�ó��
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
    // ������ �ޱ�
    public void TakeDamage(float amount)
    {
        if(isShieldActive == true)
        {
            shield._shieldEffect.ShieldTakeDamage(amount);
        }
        else
        {
            currentHp -= amount;
        }
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

    // ȸ��
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

    // ����ġ ȹ��
    public void GainExp(float amount)
    {
        currentExp += amount;

        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }

        if (expBarUI != null)
        {
            expBarUI.UpdateBar();
        }
    }

    void LevelUp()
    {
        level++;

        // ������ ����
        maxHp += 10f;
        currentHp = maxHp;

        expToNextLevel *= 1.2f;

        // UI ����
        if (healthBarUI != null)
        {
            healthBarUI.UpdateBar();
        }
        if (expBarUI != null)
        {
            expBarUI.UpdateBar(); // �� ���� ���� expToNextLevel / levelText �ݿ�
        }

    }

    void Die()
    {
        Debug.Log("Player Dead");
        // TODO: ���ӿ��� ó��, ������ ��
    }

}
