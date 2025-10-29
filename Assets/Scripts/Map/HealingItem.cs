using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public float healAdd = 20f; // 회복량

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (player.currentHp <= 0) // 플레이어 체력이 0 되서 죽으면 작동 안 됨
                {
                    return; 
                }
              
                player.currentHp += healAdd;

                if (player.currentHp > 100f) // 100f 대체 playerStatus.maxhp
                {
                    player.currentHp = 100f;  
                }

                Debug.Log("HP 회복! 체력 : " + player.currentHp);

                Destroy(gameObject);
            }
        }
    }
}