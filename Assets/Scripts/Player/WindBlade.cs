using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlade : MonoBehaviour
{
    [SerializeField] GameObject _moverPrefab;
    [SerializeField] private Transform _wayPoint;
    [SerializeField] private float _spawnDelay;
    
    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnMover());
    }

    private IEnumerator SpawnMover()
    {
        if(_wayPoint == null )
            yield break;

        GameObject newMoverObj = Instantiate(_moverPrefab, transform);
        WayPointMover newMover = newMoverObj.GetComponent<WayPointMover>();
        newMover?.SetWayPoint(_wayPoint);

        yield return new WaitForSeconds(_spawnDelay);
        
    }


}
