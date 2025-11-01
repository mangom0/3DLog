using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Player player;            // Player 참조
    [SerializeField] private GameObject gameOverPanel; // GameOverPanel
    [SerializeField] private TimeManager timeManager; // timeManager
    [SerializeField] private GameObject levelUpCanvas;  // LevelUp Canvas

    private bool isGameOver = false;

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (!isGameOver && player != null && player.currentHp <= 0)
        {
            isGameOver = true;
            onGameOver();
        }
    }

    private void onGameOver()
    {
        //  게임오버 UI 표시
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // LevelUp 캔버스 비활성화
        if (levelUpCanvas != null)
            levelUpCanvas.SetActive(false);


        // 게임 멈추기
        Time.timeScale = 0f;

        // 타이머 정지
        if (TimeManager.Instance != null)
            TimeManager.Instance.stopTimer();
        
    }

}

