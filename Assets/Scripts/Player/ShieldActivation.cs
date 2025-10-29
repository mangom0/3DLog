using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivation : MonoBehaviour
{
    //해당 스킬 사용 시의 설정값
    [SerializeField] float _value = 5f;
    [SerializeField] Player _player;

    //실드의 체력
    public float _shieldHp;

    private void Start()
    {
        _shieldHp = _value;
    }

    public void ShieldTakeDamage(float _damage)
    {
        _shieldHp -= _damage;
        Debug.Log("현재 잔여 보호막 수치 : " + _shieldHp);
        _player.isShieldActive = false;
    }

}
