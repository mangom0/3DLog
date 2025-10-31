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
    [SerializeField] public GameObject _fireRainEffect;
    //���������� ������ ����� �Ǿ��� �÷��̾�
    [SerializeField] Player player;

    //���������� �����, ���� ������ ��Ÿ�� �� ���ӽð�
    float curDuration;
    float curCooldown;
    //�ð� ����� üũ�ϱ� ���� ����
    float _timeFlow = 0;
    //��ȭ �ܰ�
    public float _rank = 0;
    //���̾�� ������ �ߵ��Ǿ����� üũ���� bool�� ����
    bool _isActive = false;
    //��ũ ��¿� ���� ���� Ƚ��.
    float _spawnTime;
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
        _spawnTime = _rank;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            MonsterBase enemy = other.gameObject.GetComponent<MonsterBase>();

            enemy.MonsterDamageTaken(_value);

        }
    }

    private void Update()
    {
        if(_rank >= 1)
        {
            Effect();
            _timeFlow += Time.deltaTime;
        }
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
                if (_spawnTime > 0)
                {
                    _spawnTime--;
                    _fireRainEffect.transform.position = player.transform.position;
                    _timeFlow = 0;
                }
                else
                {
                    _isActive = false;
                    _fireRainEffect.SetActive(false);
                    _timeFlow = 0;
                    _spawnTime = _rank;
                }

            }
        }


    }
    public void RankUpCheck()
    {
            _rank++;
            _isActive = false;
            _fireRainEffect.SetActive(false);
        if (_rank == 2)
        {
            _cooldown -= _duration;
        }
        else if (_rank == 3)
        {
            _cooldown -= _duration;
        }
    }
}
