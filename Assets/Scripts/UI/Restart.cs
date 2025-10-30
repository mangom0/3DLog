using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        // 게임 시간이 멈춰있다면 돌려놓기
        Time.timeScale = 1f;

        SceneManager.LoadScene("SampleScene");
    }
}
