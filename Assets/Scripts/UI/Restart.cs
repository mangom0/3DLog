using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ����

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        // ���� �ð��� �����ִٸ� ��������
        Time.timeScale = 1f;

        SceneManager.LoadScene("SampleScene");
    }
}
