using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("���� UI")]
    public GameObject shopBackground; // BackGround ����

    private bool isShopOpen = false;

    void Start()
    {
        if (shopBackground != null) // ���� ����� 
        {
            shopBackground.SetActive(false);
        }
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

    }

    public void CloseShop()
    {
        shopBackground.SetActive(false); // ��� �����
        Time.timeScale = 1f; // ���� �簳
        isShopOpen = false;

    }
}