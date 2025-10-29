using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscUI : MonoBehaviour
{
    // 게임 오브젝트를 연결할 변수 
    public GameObject escPanel;

    private bool isPaused = false;

    void Update()
    {
        // ESC 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                // 일시 정지 상태이면 게임을 재개
                ResumeGame();
            }
            else
            {
                // 일시 정지 상태가 아니면 게임을 일시 정지
                PauseGame();
            }
        }
    }

    // 닫기 버튼에 연결해 게임 재개 하는 함수
    public void OnCloseButtonClick()
    {
        // ESC 키를 눌렀을 때와 동일하게 게임 재개
        ResumeGame();
    }

    // 톱니바퀴 모양 UI 버튼 눌렀을 때 메뉴 활성화 함수
    public void OnMenuButtonClick()
    {
        // 일시 정지 및 ESC 패널 활성화
        PauseGame();
    }

    public void ResumeGame()
    {
        // ESC Canvas 비활성화
        escPanel.SetActive(false);

        // 게임 시간 정상 속도로 
        Time.timeScale = 1f;

        // 상태 업데이트
        isPaused = false;


        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.startTimer();
        }
    }

    
    private void PauseGame()
    {
        // ESC Canvas 활성화
        escPanel.SetActive(true);

        // 게임 시간 멈춤
        Time.timeScale = 0f;

        // 상태 업데이트
        isPaused = true;

        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.stopTimer();
        }
    }


}
