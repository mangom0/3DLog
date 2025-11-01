using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerBottom : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnMonster;
    [SerializeField] private float spawnDelay;

    private WaitForSeconds delay;

    private void Start()
    {
        delay = new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawner());
    }



    private IEnumerator Spawner()
    {
        while(true)
        {

            yield return delay;
            System.Random rnd = new System.Random();

            if(Time.time <= 60)
            {
            Vector3 spawn = new Vector3 (rnd.Next(-71,71), 0, 71);
            Instantiate(spawnMonster[0], spawn, Quaternion.identity);

            }
            if (Time.time > 60 && Time.time <= 120)
            {
                Vector3 spawn = new Vector3(rnd.Next(-71, 71), 0, 71);
                Instantiate(spawnMonster[1], spawn, Quaternion.identity);
            }
            if(Time.time>120 && Time.time <= 180)
            {
                Vector3 spawn = new Vector3(rnd.Next(-71, 71), 0, 71);
                Instantiate(spawnMonster[2], spawn, Quaternion.identity);
            }
            if(Time.time>180)
            {
                Vector3 spawn = new Vector3(rnd.Next(-71, 71), 0, 71);
                delay = new WaitForSeconds(spawnDelay = 2);
                Instantiate(spawnMonster[Random.Range(0, 3)],  spawn, Quaternion.identity);
            }



        }

    }
}
