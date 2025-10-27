using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public float timeElapsed = 0f;  // ��� �ð�
    public bool isRunning = false;   // Ÿ�̸� �۵� ����

    public event Action<float> onTimeChanged; // UI ���ſ� �̺�Ʈ

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

    // Ÿ�̸� ����
    public void startTimer() => isRunning = true;

    // Ÿ�̸� ����
    public void stopTimer() => isRunning = false;

    // Ÿ�̸� �ʱ�ȭ
    public void resetTimer()
    {
        timeElapsed = 0f;
        onTimeChanged?.Invoke(timeElapsed);
    }
}
