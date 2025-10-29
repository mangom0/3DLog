using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivation : MonoBehaviour
{
    //�ش� ��ų ��� ���� ������
    [SerializeField] float _value = 5f;
    [SerializeField] Player _player;

    //�ǵ��� ü��
    public float _shieldHp;

    private void Start()
    {
        _shieldHp = _value;
    }

    public void ShieldTakeDamage(float _damage)
    {
        _shieldHp -= _damage;
        Debug.Log("���� �ܿ� ��ȣ�� ��ġ : " + _shieldHp);
        _player.isShieldActive = false;
    }

}
