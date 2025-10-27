using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField] private GameObject spawnMonster;
    [SerializeField] private Transform transforms;
    [SerializeField] private float spawnDelay;

    private WaitForSeconds delay;

    private void Start()
    {
        delay = new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawner());
    }



    private IEnumerator Spawner()
    {
        for(int a = 0; a < 10; a++)
        {

         yield return delay;

          GameObject newMonster = Instantiate(spawnMonster,transforms);

        }

    }
}
