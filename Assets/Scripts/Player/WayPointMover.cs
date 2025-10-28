using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _value = 5f;
    private int _currentTargetIndex = 0;
    private Transform _wayPointBox;

    public void SetWayPoint(Transform waypoint)
    {
        _wayPointBox = waypoint;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            MonsterBase monsterTrf = other.gameObject.GetComponent<MonsterBase>();
            monsterTrf.MonsterDamageTaken(_value);
        }
        if (other.CompareTag("WayPointChecker"))
        {
            if (_wayPointBox == null)
                return;

            _currentTargetIndex++;
            if(_currentTargetIndex >= _wayPointBox.childCount -1)
                _currentTargetIndex = 0;
        }
    }
    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {
        if (_wayPointBox == null)
            return;

        Transform targetTrf = _wayPointBox.GetChild(_currentTargetIndex);
        Vector3 direction = (targetTrf.position - transform.position).normalized;
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }
}
