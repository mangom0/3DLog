using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitUI : MonoBehaviour
{
    public void exitGame()
    {
        // 유니티에서 지원하는 게임(애플리케이션) 종료 하는 함수
        Application.Quit();

        // 유니티 환경에서만 실행하기 위한 장치
        #if UNITY_EDITOR
            // 유니티에서만 실행 중지
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
