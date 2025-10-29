using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("���� UI")]
    public GameObject shopBackground; // BackGround ����
    public Text goldText;

    [Header("���� ���� ǥ��")]
    public Text damageStatText;
    public Text speedStatText;
    public Text healthStatText;
    public Text regenStatText;
    public Text expStatText;
    public Text magnetStatText;

    [Header("��ư��")]
    public Button damageButton;
    public Button speedButton;
    public Button healthButton;
    public Button regenButton;
    public Button expButton;
    public Button magnetButton;

    [Header("��ư �ؽ�Ʈ")]
    public Text damageButtonText;
    public Text speedButtonText;
    public Text healthButtonText;
    public Text regenButtonText;
    public Text expButtonText;
    public Text magnetButtonText;

    [Header("���׷��̵� ����")]
    private int damageLevel = 0;
    private int speedLevel = 0;
    private int healthLevel = 0;
    private int regenLevel = 0;
    private int expLevel = 0;
    private int magnetLevel = 0;

    [Header("�⺻ ���")]
    public int damageCostBase = 100;
    public int speedCostBase = 220;
    public int healthCostBase = 150;
    public int regenCostBase = 180;
    public int expCostBase = 250;
    public int magnetCostBase = 200;

    // �ӽ� ������ (�÷��̾�� ���� �Űܾ� ��)
    private float expAdd = 1f; // ����ġ ����
    private float regenHp = 0f; // ü�� ��� (�ʴ�)
    private float regenTimer = 0f; // ��� Ÿ�̸�

    private Player player;
    private bool isShopOpen = false;

    void Start()
    {
        player = FindObjectOfType<Player>();

        if (shopBackground != null) // ���� ����� 
        {
            shopBackground.SetActive(false);
        }

        // ��ư Ŭ�� ����
        damageButton.onClick.AddListener(BuyDamage);
        speedButton.onClick.AddListener(BuySpeed);
        healthButton.onClick.AddListener(BuyHealth);
        regenButton.onClick.AddListener(BuyRegen);
        expButton.onClick.AddListener(BuyExp);
        magnetButton.onClick.AddListener(BuyMagnet);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // B��ư 
        {
            ToggleShop();
        }

        // ESCŰ�ε� �ݱ�
        if (Input.GetKeyDown(KeyCode.Escape) && isShopOpen)
        {
            CloseShop();
        }

        // ���� ���������� UI ������Ʈ
        if (isShopOpen)
        {
            UpdateAllUI();
        }

        // �ӽ� ü��, ü�� ��� (player.cs���� �����ؾ� �� ��) 
        if (regenHp > 0 && Time.timeScale > 0f && player != null)
        {
            regenTimer += Time.deltaTime;
            if (regenTimer >= 1f) // 1�ʸ���
            {
                player.Heal(regenHp);
                regenTimer = 0f;
            }
        }

    }
    // ��� ��� 
    int GetDamageCost()
    {
        return damageCostBase + (damageLevel * 10);
    }

    int GetSpeedCost()
    {
        return speedCostBase + (speedLevel * 10);
    }

    int GetHealthCost()
    {
        return healthCostBase + (healthLevel * 10);
    }

    int GetRegenCost()
    {
        return regenCostBase + (regenLevel * 10);
    }

    int GetExpCost()
    {
        return expCostBase + (expLevel * 10);
    }

    int GetMagnetCost()
    {
        return magnetCostBase + (magnetLevel * 10);
    }

    // UI ������Ʈ
    void UpdateAllUI()
    {
        if (player == null) return;

        // ��� ǥ��
        goldText.text = "Gold : " + player.gold;

        // ���� ���� ǥ��
        damageStatText.text = "���� ���ݷ� : " + (int)player.damage;
        speedStatText.text = "���� �ӵ� : " + player.moveSpeed.ToString("F1");
        healthStatText.text = "���� �ִ� ü�� : " + (int)player.maxHp;
        regenStatText.text = "���� ü�� ����� : " + regenHp.ToString("F1") + "%";
        expStatText.text = "���� exp���� : " + (int)(expAdd * 100) + "%";
        magnetStatText.text = "���� �ڼ� ���� : " + player.magnetRange.ToString("F1");

        // ��ư �ؽ�Ʈ 
        damageButtonText.text = "���ݷ� ���� +5\n(" + GetDamageCost() + "���)";
        speedButtonText.text = "�ӵ� ���� +1\n(" + GetSpeedCost() + "���)";
        healthButtonText.text = "�ִ� ü�� ���� +10\n(" + GetHealthCost() + "���)";
        regenButtonText.text = "ü�� ����� +1%\n(" + GetRegenCost() + "���)";
        expButtonText.text = "EXP ���� +5%\n(" + GetExpCost() + "���)";
        magnetButtonText.text = "�ڼ� ���� ���� +1\n(" + GetMagnetCost() + "���)";
    }

    // ���� �Լ���
    void BuyDamage()
    {
        int cost = GetDamageCost();

        if (player.SpendGold(cost)) // �����: Gold üũ ��� player.SpendGold()
        {
            player.damage += 5f;
            damageLevel++;
            UpdateAllUI();
        }
        else
        {
            Debug.Log("��� ���� (���ݷ� ���׷��̵� ����)");
        }
    }

    void BuySpeed()
    {
        int cost = GetSpeedCost();

        if (player.SpendGold(cost))
        {
            player.moveSpeed += 1f;
            speedLevel++;
            UpdateAllUI();
        }
        else
        {
            Debug.Log("��� ���� (�̵��ӵ� ���׷��̵� ����)");
        }
    }

    void BuyHealth()
    {
        int cost = GetHealthCost();
        if (player.SpendGold(cost))
        {
            // �ִ� ü�� �ø��� ���� ü�µ� ���� �÷���
            player.maxHp += 10f;
            player.currentHp += 10f;
            if (player.currentHp > player.maxHp)
            {
                player.currentHp = player.maxHp;
            }

            // ü�¹� ��� ���� (Player �ʿ� HealthBarUI.UpdateBar() ���� �Լ� ������ ȣ�����൵ ��)
            // ��: player.UpdateHpUI(); ��� �Լ��� ������ ���⼭ �ҷ�.

            healthLevel++;
            UpdateAllUI();
        }
        else
        {
            Debug.Log("��� ���� (ü�� ���׷��̵� ����)");
        }

    }

    void BuyRegen()
    {
        int cost = GetRegenCost();

        if (player.SpendGold(cost))
        {
            regenHp += 1f; // �ʴ� ü�� ����� +1
            regenLevel++;
            UpdateAllUI();
        }
        else
        {
            Debug.Log("��� ���� (ü�� ��� ���׷��̵� ����)");
        }
    }

    void BuyExp()
    {
        int cost = GetExpCost();

        if (player.SpendGold(cost))
        {
            expAdd += 0.05f; // ����ġ ȹ�淮 5% ����
            expLevel++;
            UpdateAllUI();

            // ���߿� player.GainExp() ���ο��� expAdd�� ���ؼ�
            // ����ġ �������� �� ���� �ִ� ������ ������ �� ����
            // (��: player.AddExpMultiplier(expAdd); �̷� ������)
        }
        else
        {
            Debug.Log("��� ���� (EXP ���׷��̵� ����)");
        }
    }

    void BuyMagnet()
    {
        int cost = GetMagnetCost();

        if (player.SpendGold(cost))
        {
            player.magnetRange += 1f;
            magnetLevel++;
            UpdateAllUI();
        }
        else
        {
            Debug.Log("��� ���� (���׳� ���׷��̵� ����)");
        }
    }

    // ���� ����/�ݱ� ���
    void ToggleShop()
    {
        if (isShopOpen)
        {
            CloseShop();
        }
        else
        {
            OpenShop();
        }
    }

    public void OpenShop()
    {
        shopBackground.SetActive(true); // ��� ���̱� 
        Time.timeScale = 0f; // ���� ���� 
        isShopOpen = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        UpdateAllUI();
    }

    public void CloseShop()
    {
        shopBackground.SetActive(false); // ��� �����
        Time.timeScale = 1f; // ���� �簳
        isShopOpen = false;
    }
}