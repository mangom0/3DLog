using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceField : MonoBehaviour
{
    //��ų�� ���� ������ �������� Collider
    [SerializeField] SphereCollider _collider;
    //�ش� ��ų ��� ���� ������
    [SerializeField] float _value = 5f;
    //�ش� ȿ���� ���ӵ� �ð�
    [SerializeField] float _duration = 5f;
    //��Ÿ��
    [SerializeField] float _cooldown = 10f;
    //�ð������� ���̴� �ش� ��ų ����Ʈ
    [SerializeField] GameObject _iceFieldEffect;
    //���������� ������ ����� �Ǿ��� �÷��̾�
    [SerializeField] Player player;

    //���������� �����, ���� ������ ��Ÿ�� �� ���ӽð�
    float curDuration;
    float curCooldown;
    //�ð� ����� üũ�ϱ� ���� ����
    float _timeFlow = 0;
    //��ȭ �ܰ�
    float _rank = 1;
    //���̽��ʵ� ������ �ߵ��Ǿ����� üũ���� bool�� ����
    bool _isActive = false;
    //���ο� ���� ������ ���� �ֱ⸶�� ���� ������
    float _damage = 0;
    //������ ���� �������� �ֱ�
    float _time = 0.5f;
    //�ֱ⸦ Ȯ���ϱ� ���� �ӽ� �ð�����
    float curTime = 0;

    private void Awake()
    {

        if (player._skillThreeLearned == false)
        {
            _iceFieldEffect.SetActive(false);
        }
        else
        {
            _iceFieldEffect.SetActive(true);
        }

        curDuration = _duration;
        curCooldown = _cooldown;
        _damage = _value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            MonsterBase enemy = other.gameObject.GetComponent<MonsterBase>();
            if (enemy != null)
            {
                if (_isActive == true)
                {
                    curTime += Time.deltaTime;
                    if (curTime > _time)
                    {
                        curTime = 0;
                        //enemy.gameObject.MonsterDamageTaken();
                    }
                }
            }
        }
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

                _iceFieldEffect.SetActive(true);
                _timeFlow = 0;
            }
        }
        else if (_isActive == true)
        {

            if (curDuration <= _timeFlow)
            {
                _isActive = false;
                _iceFieldEffect.SetActive(false);
                _timeFlow = 0;

            }
        }

    }
}
