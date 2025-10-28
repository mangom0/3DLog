using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public float healAdd = 20f; // ȸ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (player.playerStatus.hp <= 0) // �÷��̾� ü���� 0 �Ǽ� ������ �۵� �� ��
                {
                    return; 
                }
              
                player.playerStatus.hp += healAdd;

                if (player.playerStatus.hp > 100f) // 100f ��ü playerStatus.maxhp
                {
                    player.playerStatus.hp = 100f;  
                }

                Debug.Log("HP ȸ��! ü�� : " + player.playerStatus.hp);

                Destroy(gameObject);
            }
        }
    }
}