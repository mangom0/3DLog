using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public float timeElapsed = 0f;  // 경과 시간
    public bool isRunning = false;   // 타이머 작동 여부

    public event Action<float> onTimeChanged; // UI 갱신용 이벤트

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            onTimeChanged?.Invoke(timeElapsed);
        }
    }

    // 타이머 시작
    public void startTimer() => isRunning = true;

    // 타이머 정지
    public void stopTimer() => isRunning = false;

    // 타이머 초기화
    public void resetTimer()
    {
        timeElapsed = 0f;
        onTimeChanged?.Invoke(timeElapsed);
    }
}
