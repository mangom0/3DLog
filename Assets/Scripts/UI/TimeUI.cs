using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;  // Canvas 안 TMP Text 연결
    private Recorder recorder;

    private void Start()
    {
        recorder = FindObjectOfType<Recorder>();

        if (TimeManager.Instance != null)
        {
            // 이벤트 구독
            TimeManager.Instance.onTimeChanged += updateTimerText;
            // 타이머 자동 시작
            TimeManager.Instance.startTimer();
        }

        // 이전 플레이 시간 불러오기
        if (recorder != null)
        {
            float previousTime = recorder.loadPlayTime();
            Debug.Log("이전 세션 플레이 시간: " + previousTime.ToString("F2") + "초");
        }
    }

    private void OnDisable()
    {
        if (TimeManager.Instance != null)
            TimeManager.Instance.onTimeChanged -= updateTimerText;
    }

    private void updateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timeText.text = $"{minutes:00}:{seconds:00}";
    }
}

