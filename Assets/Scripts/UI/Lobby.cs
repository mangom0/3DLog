using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ����

public class Lobby : MonoBehaviour
{
    public void returnToLobby()
    {
        //�Ͻ����� ����
        Time.timeScale = 1f;

        // ���� �ε��ϴ� ����
        SceneManager.LoadScene("MainScene");
    }
}
