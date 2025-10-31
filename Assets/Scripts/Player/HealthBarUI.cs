using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider hpSlider; // 빨간 게이지(Filled Image)
    [SerializeField] private Player player;   // Player 참조

    void Start()
    {
        // 시작할 때 슬라이더 초기화
        if (player != null && hpSlider != null)
        {
            hpSlider.minValue = 0f;
            hpSlider.maxValue = player.maxHp;
            hpSlider.value = player.currentHp;
        }

        UpdateBar(); // 텍스트 포함 초기 세팅
    }

    // Player 체력 비율을 읽어서 채워 넣는 함수
    public void UpdateBar()
    {
        if (player == null || hpSlider == null) return;

        // 슬라이더 값 반영
        hpSlider.maxValue = player.maxHp;
        hpSlider.value = player.currentHp;

        // 텍스트도 갱신하고 싶으면
        //if (hpText != null)
        //{
        //    hpText.text = $"{Mathf.CeilToInt(player.currentHp)} / {Mathf.CeilToInt(player.maxHp)}";
        //}
    }
}
