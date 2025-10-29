using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("상점 UI")]
    public GameObject shopBackground; // BackGround 연결
    public Text goldText;

    [Header("현재 스탯 표시")]
    public Text damageStatText;
    public Text speedStatText;
    public Text healthStatText;
    public Text regenStatText;
    public Text expStatText;
    public Text magnetStatText;

    [Header("버튼들")]
    public Button damageButton;
    public Button speedButton;
    public Button healthButton;
    public Button regenButton;
    public Button expButton;
    public Button magnetButton;

    [Header("버튼 텍스트")]
    public Text damageButtonText;
    public Text speedButtonText;
    public Text healthButtonText;
    public Text regenButtonText;
    public Text expButtonText;
    public Text magnetButtonText;

    [Header("업그레이드 레벨")]
    private int damageLevel = 0;
    private int speedLevel = 0;
    private int healthLevel = 0;
    private int regenLevel = 0;
    private int expLevel = 0;
    private int magnetLevel = 0;

    [Header("기본 비용")]
    public int damageCostBase = 100;
    public int speedCostBase = 220;
    public int healthCostBase = 150;
    public int regenCostBase = 180;
    public int expCostBase = 250;
    public int magnetCostBase = 200;

    // 임시 변수들 (플레이어로 스탯 옮겨야 함)
    private float Gold = 10000f; // 테스트용 골드
    private float expAdd = 1f; // 경험치 배율
    private float regenHp = 0f; // 체력 재생 (초당)
    private float regenTimer = 0f; // 재생 타이머

    private Player player;
    private bool isShopOpen = false;

    void Start()
    {
        player = FindObjectOfType<Player>();

        if (shopBackground != null) // 상점 숨기기 
        {
            shopBackground.SetActive(false);
        }

        // 버튼 클릭 연결
        damageButton.onClick.AddListener(BuyDamage);
        speedButton.onClick.AddListener(BuySpeed);
        healthButton.onClick.AddListener(BuyHealth);
        regenButton.onClick.AddListener(BuyRegen);
        expButton.onClick.AddListener(BuyExp);
        magnetButton.onClick.AddListener(BuyMagnet);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // B버튼 
        {
            ToggleShop();
        }

        // ESC키로도 닫기
        if (Input.GetKeyDown(KeyCode.Escape) && isShopOpen)
        {
            CloseShop();
        }

        // 상점 열려있으면 UI 업데이트
        if (isShopOpen)
        {
            UpdateAllUI();
        }

        // 임시 체젠, 체력 재생 (player.cs에서 구현해야 할 듯) 
        if (regenHp > 0 && Time.timeScale > 0)
        {
            regenTimer += Time.deltaTime;
            if (regenTimer >= 1f) // 1초마다
            {
                player.Heal(regenHp);
                regenTimer = 0f;
            }
        }

    }
    // 비용 계산 
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

    // UI 업데이트
    void UpdateAllUI()
    {
        if (player == null) return;

        // 골드 표시
        goldText.text = "Gold : " + (int)Gold;

        // 현재 스탯 표시
        damageStatText.text = "현재 공격력 : " + (int)player.damage;
        speedStatText.text = "현재 속도 : " + player.moveSpeed.ToString("F1");
        healthStatText.text = "현재 최대 체력 : " + (int)player.maxHp;
        regenStatText.text = "현재 체력 재생률 : " + regenHp.ToString("F1") + "%";
        expStatText.text = "현재 exp배율 : " + (int)(expAdd * 100) + "%";
        magnetStatText.text = "현재 자석 범위 : " + player.magnetRange.ToString("F1");

        // 버튼 텍스트 
        damageButtonText.text = "공격력 증가 +5\n(" + GetDamageCost() + "골드)";
        speedButtonText.text = "속도 증가 +1\n(" + GetSpeedCost() + "골드)";
        healthButtonText.text = "최대 체력 증가 +10\n(" + GetHealthCost() + "골드)";
        regenButtonText.text = "체력 재생률 +1%\n(" + GetRegenCost() + "골드)";
        expButtonText.text = "EXP 배율 +5%\n(" + GetExpCost() + "골드)";
        magnetButtonText.text = "자석 범위 증가 +1\n(" + GetMagnetCost() + "골드)";
    }

    // 구매 함수들
    void BuyDamage()
    {
        int cost = GetDamageCost();

        if (Gold >= cost)
        {
            Gold -= cost;
            player.damage += 5;
            damageLevel++;
            UpdateAllUI();
        }
    }

    void BuySpeed()
    {
        int cost = GetSpeedCost();

        if (Gold >= cost)
        {
            Gold -= cost;
            player.moveSpeed += 1f;
            speedLevel++;
            UpdateAllUI();
        }
    }

    void BuyHealth()
    {
        int cost = GetHealthCost();

        if (Gold >= cost)
        {
            Gold -= cost;
            player.maxHp += 10;
            player.currentHp += 10; // 현재 체력도 증가
            healthLevel++;
            UpdateAllUI();
        }

    }

    void BuyRegen()
    {
        int cost = GetRegenCost();

        if (Gold >= cost)
        {
            Gold -= cost;
            regenHp += 1f; // 초당 1 체력 회복
            regenLevel++;
            UpdateAllUI();
        }
    }

    void BuyExp()
    {
        int cost = GetExpCost();

        if (Gold >= cost)
        {
            Gold -= cost;
            expAdd += 0.05f; // 5% 증가
            expLevel++;
            UpdateAllUI();
        }
     }

    void BuyMagnet()
    {
        int cost = GetMagnetCost();

        if (Gold >= cost)
        {
            Gold -= cost;
            player.magnetRange += 1f;
            magnetLevel++;
            UpdateAllUI();
        }
    }

    // 상점 열기/닫기 토글
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
        shopBackground.SetActive(true); // 배경 보이기 
        Time.timeScale = 0f; // 게임 멈춤 
        isShopOpen = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        UpdateAllUI();
    }

    public void CloseShop()
    {
        shopBackground.SetActive(false); // 배경 숨기기
        Time.timeScale = 1f; // 게임 재개
        isShopOpen = false;
    }
}