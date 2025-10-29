using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour, ISkill
{
    //��ų�� ���� ������ �������� Collider
    [SerializeField] SphereCollider _collider;
    //�ش� ��ų ��� ���� ������
    [SerializeField] float _value = 5f;
    //�ش� ȿ���� ���ӵ� �ð�
    [SerializeField] float _duration = 5f;
    //��Ÿ��
    [SerializeField] float _cooldown = 5f;
    //���� �� �ǵ�μ� ����� ������Ʈ
    [SerializeField] ShieldActivation _shieldEffect;
    [SerializeField] Player player;

    //���������� �����, ���� ������ ��Ÿ�� �� ���ӽð�
    float curDuration;
    float curCooldown;
    //�ð� ����� üũ�ϱ� ���� ����
    float _timeFlow = 0;
    //��ȭ �ܰ�
    float _rank = 1;
    //�ǵ� ������ �ߵ��Ǿ����� üũ���� bool�� ����
    bool _isActive = false;
    private void Awake()
    {
        curDuration = _duration;
        curCooldown = _cooldown;
        player.ShieldHP = _value;
    }

    private void Update()
    {
        Effect();
        _timeFlow += Time.deltaTime;
        RankUpCheck();
    }

    public void Effect()
    {
        if (_isActive == false)
        {
            player.isShieldActive = false;
            if (curCooldown <= _timeFlow)
            {
                _isActive = true;
                player.ShieldHP = _value;
                Instantiate(_shieldEffect, player.gameObject.transform);
                _timeFlow = 0;
            }
        }
        else if (_isActive == true)
        {
            player.isShieldActive = true;
            if (_shieldEffect._shieldHp <= 0 || curDuration <= _timeFlow)
            {
                if(_shieldEffect._shieldHp > 0)
                    _shieldEffect.ShieldTakeDamage(_shieldEffect._shieldHp + 1);
                _isActive = false;
                _timeFlow = 0;

            }
        }

    }
    public void RankUpCheck()
    {
        if(Input.GetKeyDown(KeyCode.Slash))
        {
            _rank++;
            _isActive = false;
            _timeFlow = 0;
            if(_rank == 2)
            {
                _value += 5;
            }
            else if (_rank == 3)
            {
                _value += 8;
            }
        }
    }

}
