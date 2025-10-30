using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [Header("UI Panel")]

    // GameOver Panel (��Ȱ�� ���·� ����)
    [SerializeField] private GameObject gameOverPanel;

    void Start()
    {
        if (gameOverPanel != null)

            // ���� �� ����
            gameOverPanel.SetActive(false);
    }

    // �׽�Ʈ��: ��ư Ŭ������ GameOver ȭ�� ǥ��
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // ���� ����
        Time.timeScale = 0f; 
    }

    // �׽�Ʈ��: GameOver ȭ�� �ݱ�
    public void HideGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        // ���� �簳
        Time.timeScale = 1f; 
    }
}

