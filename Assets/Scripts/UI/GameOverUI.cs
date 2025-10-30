using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [Header("UI Panel")]

    // GameOver Panel (비활성 상태로 시작)
    [SerializeField] private GameObject gameOverPanel;

    void Start()
    {
        if (gameOverPanel != null)

            // 시작 시 숨김
            gameOverPanel.SetActive(false);
    }

    // 테스트용: 버튼 클릭으로 GameOver 화면 표시
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // 게임 정지
        Time.timeScale = 0f; 
    }

    // 테스트용: GameOver 화면 닫기
    public void HideGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        // 게임 재개
        Time.timeScale = 1f; 
    }
}

