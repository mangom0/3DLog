using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItem : MonoBehaviour
{
    [Header("�⺻ ����")]
    public float expAdd = 5f; // ȹ�� ����ġ

    [Header("�ڼ� ����")]
    public float magnetSpeed = 10f; // �ڼ� �ӵ�
    public float autoMagnetRange = 3f; // �ڼ� ����  // ������ ���� �ƴ϶�� ���� ���� ����

    private Transform player;
    //private Player playerScript; //  public float MagnetRange = 3f; �� Player.cs�� �߰� �ɽ� �÷��̾� ���� 
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
            // playerScript = playerObj.GetComponent<Player>(); // Player.cs ������Ʈ ��������
        }
    }

    private void Update()
    {
        if (player == null) return; // (player == null || playerScript == null)

        // �÷��̾���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, player.position);

        // �ڵ� ��� 
        if (distance <= autoMagnetRange) //(ExpItem�� autoMagnetRange ���) // (distance <= playerScript.magneticRange)
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
            Player playerScript = other.GetComponent<Player>();

            if (playerScript != null)
            {
                // ����ġ ����
                playerScript.levelExp += expAdd;
                Debug.Log("Exp ȹ��! ���� Exp: " + playerScript.levelExp);

                // ������ ����
                Destroy(gameObject);
            }
        }
    }
}