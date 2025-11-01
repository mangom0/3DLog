using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리

public class Lobby : MonoBehaviour
{
    public void returnToLobby()
    {
        //일시정지 해제
        Time.timeScale = 1f;

        // 씬을 로드하는 역할
        SceneManager.LoadScene("MainScene");
    }
}
