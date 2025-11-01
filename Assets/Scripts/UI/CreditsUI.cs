using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsUI : MonoBehaviour
{
    [SerializeField] private GameObject creditPanel; // 크레딧 패널

    // 크레딧 버튼을 누르면 실행
    public void OnCreditButtonClicked()
    {
        creditPanel.SetActive(true); // 크레딧 창 활성화
    }

    // 닫기 버튼(패널 안쪽 버튼)
    public void OnCloseCreditButtonClicked()
    {
        creditPanel.SetActive(false); // 크레딧 창 비활성화
    }
}
