using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // 싱글톤 인스턴스 - 다른 스크립트에서 TimeManager.Instance로 접근 가능
    public static TimeManager Instance;

    // 경과 시간
    public float timeElapsed = 0f;

    // 타이머 작동 여부
    public bool isRunning = false;

    // UI 갱신용 이벤트
    // floot 은 현재 경과 시간(timeElapsed)
    public event Action<float> onTimeChanged; 

    private void Awake()
    {
        //싱글톤 패턴 구현
        // 인스턴스가 없으면 현재 오브젝트를 Instance로 지정
        if (Instance == null)
            Instance = this;
        else
            // 이미 존재하는 경우, 중복 생성 막기위 파괴
            Destroy(gameObject);
    }

    private void Update()
    {
        // 타이머가 작동 중일 때만 시간 증가 처리
        if (isRunning)
        {
            // 경과 시간 누적
            timeElapsed += Time.deltaTime;

            // 이벤트를 호출하여 타이머 갱신
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

        // UI에서 즉시 갱신되도록 이벤트 호출
        onTimeChanged?.Invoke(timeElapsed); 
    }
}
