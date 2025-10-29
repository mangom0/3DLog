using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ� - �ٸ� ��ũ��Ʈ���� TimeManager.Instance�� ���� ����
    public static TimeManager Instance;

    // ��� �ð�
    public float timeElapsed = 0f;

    // Ÿ�̸� �۵� ����
    public bool isRunning = false;

    // UI ���ſ� �̺�Ʈ
    // floot �� ���� ��� �ð�(timeElapsed)
    public event Action<float> onTimeChanged; 

    private void Awake()
    {
        //�̱��� ���� ����
        // �ν��Ͻ��� ������ ���� ������Ʈ�� Instance�� ����
        if (Instance == null)
            Instance = this;
        else
            // �̹� �����ϴ� ���, �ߺ� ���� ������ �ı�
            Destroy(gameObject);
    }

    private void Update()
    {
        // Ÿ�̸Ӱ� �۵� ���� ���� �ð� ���� ó��
        if (isRunning)
        {
            // ��� �ð� ����
            timeElapsed += Time.deltaTime;

            // �̺�Ʈ�� ȣ���Ͽ� Ÿ�̸� ����
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

        // UI���� ��� ���ŵǵ��� �̺�Ʈ ȣ��
        onTimeChanged?.Invoke(timeElapsed); 
    }
}
