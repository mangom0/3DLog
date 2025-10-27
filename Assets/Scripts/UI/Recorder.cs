using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private const string playTimeKey = "playerPlayTime";

    // �÷��� �ð� ����
    public void savePlayTime(float time)
    {
        PlayerPrefs.SetFloat(playTimeKey, time);
        PlayerPrefs.Save();
        Debug.Log($"�÷��� �ð� �����: {time:F2}��");
    }

    // �÷��� �ð� �ҷ�����
    public float loadPlayTime()
    {
        float time = PlayerPrefs.GetFloat(playTimeKey, 0f);
        Debug.Log($"����� �÷��� �ð�: {time:F2}��");
        return time;
    }

    // ����� ��� �ʱ�ȭ
    public void resetPlayTime()
    {
        PlayerPrefs.DeleteKey(playTimeKey);
        Debug.Log("�÷��� �ð� �ʱ�ȭ");
    }
}

