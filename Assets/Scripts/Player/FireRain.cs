using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRain : MonoBehaviour, ISkill
{
    //��ų�� ���� ������ �������� Collider
    [SerializeField] BoxCollider _collider;
    //�ش� ��ų ��� ���� ������
    [SerializeField] float _value = 5f;
    //�ش� ȿ���� ���ӵ� �ð�
    [SerializeField] float _duration = 5f;
    //��Ÿ��
    [SerializeField] float _cooldown = 15f;
    //�ð������� ���̴� �ش� ��ų ����Ʈ
    [SerializeField] GameObject _fireRainEffect;
    //���������� ������ ����� �Ǿ��� �÷��̾�
    [SerializeField] Player player;

    //���������� �����, ���� ������ ��Ÿ�� �� ���ӽð�
    float curDuration;
    float curCooldown;
    //�ð� ����� üũ�ϱ� ���� ����
    float _timeFlow = 0;
    //��ȭ �ܰ�
    float _rank = 1;
    //���̾�� ������ �ߵ��Ǿ����� üũ���� bool�� ����
    bool _isActive = false;
    //���ο� ���� ������ ���� �ֱ⸶�� ���� ������
    float _damage = 0;
    //������ ���� �������� �ֱ�
    float _time = 0.5f;
    //�ֱ⸦ Ȯ���ϱ� ���� �ӽ� �ð�����
    float curTime = 0;

    private void Awake()
    {

        if (player._skillTwoLearned == false)
        {
            _fireRainEffect.SetActive(false);
        }
        else
        {
            _fireRainEffect.SetActive(true);
        }

        curDuration = _duration;
        curCooldown = _cooldown;
        _damage = _value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            MonsterBase enemy = other.gameObject.GetComponent<MonsterBase>();
            if (enemy != null)
            {
                if(_isActive == true)
                {
                    curTime += Time.deltaTime;
                    if (curTime > _time)
                    {
                        curTime = 0;
                        enemy.MonsterDamageTaken(_value);
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
            _fireRainEffect.transform.position = player.transform.position;
            if (curCooldown <= _timeFlow)
            {
                _isActive = true;
                
                _fireRainEffect.SetActive(true);
                _timeFlow = 0;
            }
        }
        else if (_isActive == true)
        {
            
            if (curDuration <= _timeFlow)
            {
                _isActive = false;
                _fireRainEffect.SetActive(false);
                _timeFlow = 0;

            }
        }

    }
}
