using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
   
    [SerializeField] GameObject _SpawnPrefab;
   
    [SerializeField] float _SpawnDelay;

    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_SpawnDelay);
        StartCoroutine(Spawner());
    }


    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return _delay;
          
                System.Random rnd = new System.Random();
                GameObject newObj = Instantiate(_SpawnPrefab, transform);
            //박스 랜덤 생성
                newObj.transform.position = new Vector3(rnd.Next(-73, 74), 0, rnd.Next(-73, 74));
            

        }
    }
}
