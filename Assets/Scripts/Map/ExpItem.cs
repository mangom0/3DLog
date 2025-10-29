using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItem : MonoBehaviour
{
    [Header("�⺻ ����")]
    public float expAdd = 5f; // ȹ�� ����ġ

    [Header("�ڼ� ����")]
    public float magnetSpeed = 10f; // �ڼ� �ӵ�
 
    private Transform player;
    private Player playerScript; 
    private bool isGlobalMagnetActive = false; // ���� �ڼ� Ȱ��ȭ
                                              
    public void ActivateGlobalMagnet()  // �ڼ� �������� �� �޼��� ȣ�� 
    {
        isGlobalMagnetActive = true;
    }

    private void Start()
    {
        // �÷��̾� ã��
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            playerScript = playerObj.GetComponent<Player>(); // Player.cs ������Ʈ ��������
        }
    }

    private void Update()
    {
        if (player == null || playerScript == null) return;

        // �÷��̾���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, player.position);

        // �ڵ� ��� 
        if (distance <= playerScript.magnetRange) // �÷��̾�.cs�� magnetRange ���
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                magnetSpeed * Time.deltaTime
            );
        }

        // ���� �ڼ� Ȱ��ȭ ��
        if (isGlobalMagnetActive)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                magnetSpeed * 2f * Time.deltaTime
            );
        }
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                // ����ġ ���� (������ �׳� currentExp += ... ���� GainExp ȣ��)
                player.GainExp(expAdd);
                Debug.Log("Exp ȹ��! ���� Exp: " + player.currentExp);

                Destroy(gameObject);
            }
        }
    }
}