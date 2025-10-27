using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private const string playTimeKey = "playerPlayTime";

    // 플레이 시간 저장
    public void savePlayTime(float time)
    {
        PlayerPrefs.SetFloat(playTimeKey, time);
        PlayerPrefs.Save();
        Debug.Log($"플레이 시간 저장됨: {time:F2}초");
    }

    // 플레이 시간 불러오기
    public float loadPlayTime()
    {
        float time = PlayerPrefs.GetFloat(playTimeKey, 0f);
        Debug.Log($"저장된 플레이 시간: {time:F2}초");
        return time;
    }

    // 저장된 기록 초기화
    public void resetPlayTime()
    {
        PlayerPrefs.DeleteKey(playTimeKey);
        Debug.Log("플레이 시간 초기화");
    }
}

