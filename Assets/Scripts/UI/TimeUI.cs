using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;  // Canvas �� TMP Text ����
    private Recorder recorder;

    private void Start()
    {
        recorder = FindObjectOfType<Recorder>();

        if (TimeManager.Instance != null)
        {
            // �̺�Ʈ ����
            TimeManager.Instance.onTimeChanged += updateTimerText;
            // Ÿ�̸� �ڵ� ����
            TimeManager.Instance.startTimer();
        }

        // ���� �÷��� �ð� �ҷ�����
        if (recorder != null)
        {
            float previousTime = recorder.loadPlayTime();
            Debug.Log("���� ���� �÷��� �ð�: " + previousTime.ToString("F2") + "��");
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

