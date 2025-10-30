using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsUI : MonoBehaviour
{
    [SerializeField] private GameObject creditPanel; // ũ���� �г�

    // ũ���� ��ư�� ������ ����
    public void OnCreditButtonClicked()
    {
        creditPanel.SetActive(true); // ũ���� â Ȱ��ȭ
    }

    // �ݱ� ��ư(�г� ���� ��ư)
    public void OnCloseCreditButtonClicked()
    {
        creditPanel.SetActive(false); // ũ���� â ��Ȱ��ȭ
    }
}
