using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Player player;            // Player ����
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
        //  ���ӿ��� UI ǥ��
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // LevelUp ĵ���� ��Ȱ��ȭ
        if (levelUpCanvas != null)
            levelUpCanvas.SetActive(false);


        // ���� ���߱�
        Time.timeScale = 0f;

        // Ÿ�̸� ����
        if (TimeManager.Instance != null)
            TimeManager.Instance.stopTimer();
        
    }

}

