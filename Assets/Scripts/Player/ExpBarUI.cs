using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBarUI : MonoBehaviour
{
    [SerializeField] private Slider xpSlider; // �Ķ� ������ ���� XP �����̴�
    [SerializeField] private TMP_Text levelText; // "Lv 3" �̷� ��
    [SerializeField] private Player player; // Player ����

    void Start()
    {
        if (player != null && xpSlider != null)
        {
            xpSlider.minValue = 0f;
            xpSlider.maxValue = player.expToNextLevel;   // �̹� �������� �ʿ��� �ѷ�
            xpSlider.value = player.currentExp;          // ���� ������ ����ġ
        }

        UpdateBar();
    }

    public void UpdateBar()
    {
        if (player == null || xpSlider == null) return;

        // �����̴� �� �ݿ�
        xpSlider.maxValue = player.expToNextLevel; // ������ �� �ʿ䷮�� �ٲ�Ƿ� ��� ����
        xpSlider.value = player.currentExp;

        if (levelText != null)
        {
            levelText.text = "Lv " + player.level;
        }
    }
}
