using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] float _period = 0.5f;
    float cooldown = 0;
    //해당 스킬들의 기본적인 피해량. 즉 플레이어의 공격력에 영향을 받지 않았을 때의 피해량.
    [SerializeField] float _baseDamage;
    //플레이어의 공격력을 받아올 변수값
    public float _value = 5;
    //받아온 값에 적용하여 실제로 입히는 피해를 계산하기 위한 배율
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
