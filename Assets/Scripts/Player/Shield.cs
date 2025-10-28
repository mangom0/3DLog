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
    //�ð������� ���̴� �ش� ��ų ����Ʈ
    [SerializeField] GameObject _shieldEffect;
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
    //�ǵ� ������ �ߵ��Ǿ��� ��� �ش� �ǵ尡 ������ �� �ִ� �ִ� ���ط�
    float _shieldHp;
    private void Awake()
    {
        if(player._skillOneLearned == false)
        {
            _shieldEffect.SetActive(false);
        }
        else
        {
            _shieldEffect.SetActive(true);
        }

        curDuration = _duration;
        curCooldown = _cooldown;
        _shieldHp = _value;
    }

    private void Update()
    {
        Effect();
        _timeFlow += Time.deltaTime;
    }

    public void Effect()
    {
        if (_isActive == false)
        {
            if (curCooldown <= _timeFlow)
            {
                _isActive = true;
                _shieldHp = _value;
                _shieldEffect.SetActive(true);
                _timeFlow = 0;
            }
        }
        else if (_isActive == true)
        {
            if (_shieldHp <= 0 || curDuration <= _timeFlow)
            {
                _isActive = false;
                _shieldEffect.SetActive(false);
                _timeFlow = 0;

            }
        }

    }

}
