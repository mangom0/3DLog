using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리

public class StartUI : MonoBehaviour
{
    //특정 씬으로 이동하는 함수
    public void startGame()
    {
        // 씬을 로드하는 역할
        SceneManager.LoadScene("SampleScene");
    }
}
