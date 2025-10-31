using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichProjectile : MonoBehaviour
{
   Player player;
   [SerializeField] float moveSpeed = 7.5f;
   [SerializeField] float damage;
   float createdTime = 5f;
   float spawnTime;


    private void Start()
    {
        spawnTime = Time.time;
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if ((Time.time > spawnTime + createdTime))
        {
            Destroy(gameObject);
            Debug.Log("시간이 지나서 사라짐");
            return;
        }

        transform.Translate(Vector3.forward * moveSpeed*  Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
            Debug.Log("플레이어 투사체 맞음" + player.currentHp);

            Destroy(gameObject);
        }
    }

}
