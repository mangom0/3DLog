using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ����

public class StartUI : MonoBehaviour
{
    //Ư�� ������ �̵��ϴ� �Լ�
    public void startGame()
    {
        // ���� �ε��ϴ� ����
        SceneManager.LoadScene("SampleScene");
    }
}
