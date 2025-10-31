using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] float _period = 0.5f;
    float cooldown = 0;
    //�ش� ��ų���� �⺻���� ���ط�. �� �÷��̾��� ���ݷ¿� ������ ���� �ʾ��� ���� ���ط�.
    [SerializeField] float _baseDamage;
    //�÷��̾��� ���ݷ��� �޾ƿ� ������
    public float _value = 5;
    //�޾ƿ� ���� �����Ͽ� ������ ������ ���ظ� ����ϱ� ���� ����
    [SerializeField] float _multiplyer;
    [SerializeField] Player _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 8)
        {
            MonsterBase enemy = other.gameObject.GetComponent<MonsterBase>();
            
            enemy.MonsterDamageTaken(_baseDamage + (_value * _multiplyer));

        }
    }
    private void OnTriggerStay(Collider other)
    {
        cooldown += Time.deltaTime;
        if (other.gameObject.layer == 7 || other.gameObject.layer == 8)
        {
            if(cooldown > _period)
            {
                MonsterBase enemy = other.gameObject.GetComponent<MonsterBase>();
                enemy.MonsterDamageTaken(_baseDamage + (_value * _multiplyer));
                cooldown = 0;
            }
        }
    }
    private void Update()
    {
        if(_player == null)
        {
            _player = FindObjectOfType<Player>();
        }
        _value = _player.damage;
    }
}
