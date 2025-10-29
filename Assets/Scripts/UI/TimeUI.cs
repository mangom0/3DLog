using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    // Canvas �� TMP Text ����
    public TextMeshProUGUI timeText; 

    // ���� �÷��̽ð� ��� �����ϴ� Recorder ��ũ��Ʈ ����
    private Recorder recorder;

    private void Start()
    {
        // �� ������ Recorder ������Ʈ ã�� ���� (������ null)
        recorder = FindObjectOfType<Recorder>();

        //TimeManager �̱��� �ν��Ͻ� ���� Ȯ��
        if (TimeManager.Instance != null)
        {
            // Ÿ�̸� �ð��� ����� ������ UI ������Ʈ�ϵ��� �̺�Ʈ ����
            TimeManager.Instance.onTimeChanged += updateTimerText;

            // Ÿ�̸� �ڵ� ����
            TimeManager.Instance.startTimer();
        }

        // Recorder�� ������ ���� �÷��� �ð� �ҷ�����
        if (recorder != null)
        {
            float previousTime = recorder.loadPlayTime();
            Debug.Log("���� ���� �÷��� �ð�: " + previousTime.ToString("F2") + "��");
        }
    }

    // ����Ƽ �����ֱ� �Լ�
    private void OnDisable()
    {
        // �̺�Ʈ ���� ����(�޸� ���� ����)
        if (TimeManager.Instance != null)
            TimeManager.Instance.onTimeChanged -= updateTimerText;
    }

    // Ÿ�̸� �ð��� ����� �� ȣ��Ǵ� �ݹ� �Լ�
    // float time�� TimManager���� ���޵� ���� ��� �ð�
    private void updateTimerText(float time)
    {
        // ��� �ð��� �а� �� ������ ��ȯ
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        // TextMeshPro �ؽ�Ʈ���� ��:�� �������� ǥ��
        timeText.text = $"{minutes:00}:{seconds:00}";
    }
}

