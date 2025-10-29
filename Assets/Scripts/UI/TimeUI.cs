using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    // Canvas 안 TMP Text 연결
    public TextMeshProUGUI timeText; 

    // 이전 플레이시간 기록 관리하는 Recorder 스크립트 참조
    private Recorder recorder;

    private void Start()
    {
        // 씬 내에서 Recorder 컴포넌트 찾아 참조 (없으면 null)
        recorder = FindObjectOfType<Recorder>();

        //TimeManager 싱글톤 인스턴스 존재 확인
        if (TimeManager.Instance != null)
        {
            // 타이머 시간이 변경될 때마다 UI 업데이트하도록 이벤트 구독
            TimeManager.Instance.onTimeChanged += updateTimerText;

            // 타이머 자동 시작
            TimeManager.Instance.startTimer();
        }

        // Recorder이 있으면 이전 플레이 시간 불러오기
        if (recorder != null)
        {
            float previousTime = recorder.loadPlayTime();
            Debug.Log("이전 세션 플레이 시간: " + previousTime.ToString("F2") + "초");
        }
    }

    // 유니티 생명주기 함수
    private void OnDisable()
    {
        // 이벤트 구독 해제(메모리 누수 방지)
        if (TimeManager.Instance != null)
            TimeManager.Instance.onTimeChanged -= updateTimerText;
    }

    // 타이머 시간이 변경될 때 호출되는 콜백 함수
    // float time은 TimManager에서 전달된 현재 경과 시간
    private void updateTimerText(float time)
    {
        // 경과 시간을 분과 초 단위로 변환
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        // TextMeshPro 텍스트에서 분:초 형식으로 표시
        timeText.text = $"{minutes:00}:{seconds:00}";
    }
}

