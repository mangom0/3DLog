using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerRight : MonoBehaviour
{

    [SerializeField] private GameObject spawnMonster;
    //[SerializeField] private Transform transforms;
    [SerializeField] private float spawnDelay;

    private WaitForSeconds delay;

    private void Start()
    {
        delay = new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawner());
    }



    private IEnumerator Spawner()
    {
        for(int a = 0; a < 50; a++)
        {

          yield return delay;
          System.Random rnd = new System.Random();
            Vector3 spawn = new Vector3(74, 0, rnd.Next(-74, 74));
            Instantiate(spawnMonster, spawn, Quaternion.identity);



        }

    }
}
