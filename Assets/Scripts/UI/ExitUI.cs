using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitUI : MonoBehaviour
{
    public void exitGame()
    {
        // ����Ƽ���� �����ϴ� ����(���ø����̼�) ���� �ϴ� �Լ�
        Application.Quit();

        // ����Ƽ ȯ�濡���� �����ϱ� ���� ��ġ
        #if UNITY_EDITOR
            // ����Ƽ������ ���� ����
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
