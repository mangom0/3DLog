using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscUI : MonoBehaviour
{
    // ���� ������Ʈ�� ������ ���� 
    public GameObject escPanel;

    private bool isPaused = false;

    void Update()
    {
        // ESC Ű �Է� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                // �Ͻ� ���� �����̸� ������ �簳
                ResumeGame();
            }
            else
            {
                // �Ͻ� ���� ���°� �ƴϸ� ������ �Ͻ� ����
                PauseGame();
            }
        }
    }

    // �ݱ� ��ư�� ������ ���� �簳 �ϴ� �Լ�
    public void OnCloseButtonClick()
    {
        // ESC Ű�� ������ ���� �����ϰ� ���� �簳
        ResumeGame();
    }

    // ��Ϲ��� ��� UI ��ư ������ �� �޴� Ȱ��ȭ �Լ�
    public void OnMenuButtonClick()
    {
        // �Ͻ� ���� �� ESC �г� Ȱ��ȭ
        PauseGame();
    }

    public void ResumeGame()
    {
        // ESC Canvas ��Ȱ��ȭ
        escPanel.SetActive(false);

        // ���� �ð� ���� �ӵ��� 
        Time.timeScale = 1f;

        // ���� ������Ʈ
        isPaused = false;


        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.startTimer();
        }
    }

    private void PauseGame()
    {
        // ESC Canvas Ȱ��ȭ
        escPanel.SetActive(true);

        // ���� �ð� ����
        Time.timeScale = 0f;

        // ���� ������Ʈ
        isPaused = true;

        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.stopTimer();
        }
    }


}
