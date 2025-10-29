using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBarUI : MonoBehaviour
{
    [SerializeField] private Slider xpSlider; // 파란 게이지 같은 XP 슬라이더
    [SerializeField] private TMP_Text levelText; // "Lv 3" 이런 거
    [SerializeField] private Player player; // Player 연결

    void Start()
    {
        if (player != null && xpSlider != null)
        {
            xpSlider.minValue = 0f;
            xpSlider.maxValue = player.expToNextLevel;   // 이번 레벨업에 필요한 총량
            xpSlider.value = player.currentExp;          // 지금 누적된 경험치
        }

        UpdateBar();
    }

    public void UpdateBar()
    {
        if (player == null || xpSlider == null) return;

        // 슬라이더 값 반영
        xpSlider.maxValue = player.expToNextLevel; // 레벨업 후 필요량이 바뀌므로 계속 갱신
        xpSlider.value = player.currentExp;

        if (levelText != null)
        {
            levelText.text = "Lv " + player.level;
        }
    }
}
