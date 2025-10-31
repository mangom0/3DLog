using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlade : MonoBehaviour, ISkill
{
    [SerializeField] GameObject _moverPrefab;
    [SerializeField] private Transform _wayPoint;
    [SerializeField] private float _spawnDelay;

    [SerializeField] public GameObject _rankOneSpawn;
    [SerializeField] GameObject _rankTwoSpawn;
    [SerializeField] GameObject _rankThreeSpawnA;
    [SerializeField] GameObject _rankThreeSpawnB;
    public float _rank = 0;
    private float _prev;
    
    private WaitForSeconds _delay;
    private GameObject _rankTwoStorm;

    private void Start()
    {
        Instantiate(_moverPrefab, _rankOneSpawn.transform);
        _rankTwoStorm = _moverPrefab;
        _delay = new WaitForSeconds(_spawnDelay);
        _prev = _rank;
    }

    private void Update()
    {
        _wayPoint.transform.Rotate(Vector3.up, 90f *  Time.deltaTime);
    }

    public void Effect()
    {
        
    }

    public void RankUpCheck()
    {
            _rank++;
        if (_prev != _rank && _rank == 1)
        {
            _rankOneSpawn.gameObject.SetActive(true);
            _prev++;
        }
        if (_prev != _rank && _rank == 2)
        {
            Instantiate(_rankTwoStorm, _rankTwoSpawn.transform);
            _prev++;
        }
        else if (_prev != _rank && _rank == 3)
        {
            Destroy(_rankTwoSpawn.gameObject);
            Instantiate(_moverPrefab, _rankThreeSpawnA.transform);
            Instantiate(_moverPrefab, _rankThreeSpawnB.transform);
            _prev++;
        }
    }
}
