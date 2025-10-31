using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider hpSlider; // ���� ������(Filled Image)
    [SerializeField] private Player player;   // Player ����

    void Start()
    {
        // ������ �� �����̴� �ʱ�ȭ
        if (player != null && hpSlider != null)
        {
            hpSlider.minValue = 0f;
            hpSlider.maxValue = player.maxHp;
            hpSlider.value = player.currentHp;
        }

        UpdateBar(); // �ؽ�Ʈ ���� �ʱ� ����
    }

    // Player ü�� ������ �о ä�� �ִ� �Լ�
    public void UpdateBar()
    {
        if (player == null || hpSlider == null) return;

        // �����̴� �� �ݿ�
        hpSlider.maxValue = player.maxHp;
        hpSlider.value = player.currentHp;

        // �ؽ�Ʈ�� �����ϰ� ������
        //if (hpText != null)
        //{
        //    hpText.text = $"{Mathf.CeilToInt(player.currentHp)} / {Mathf.CeilToInt(player.maxHp)}";
        //}
    }
}
