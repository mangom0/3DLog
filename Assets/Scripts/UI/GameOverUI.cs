using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Player player;            // Player ÂüÁ¶
    [SerializeField] private GameObject gameOverPanel; // GameOverPanel
    [SerializeField] private TimeManager timeManager; // timeManager

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
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (TimeManager.Instance != null)
            TimeManager.Instance.stopTimer();
        
    }

}

