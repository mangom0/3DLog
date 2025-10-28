using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("상점 UI")]
    public GameObject shopBackground; // BackGround 연결

    private bool isShopOpen = false;

    void Start()
    {
        if (shopBackground != null) // 상점 숨기기 
        {
            shopBackground.SetActive(false);
        }
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

    }

    public void CloseShop()
    {
        shopBackground.SetActive(false); // 배경 숨기기
        Time.timeScale = 1f; // 게임 재개
        isShopOpen = false;

    }
}