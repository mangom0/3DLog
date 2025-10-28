using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRain : MonoBehaviour, ISkill
{
    //스킬의 판정 범위를 지정해줄 Collider
    [SerializeField] BoxCollider _collider;
    //해당 스킬 사용 시의 설정값
    [SerializeField] float _value = 5f;
    //해당 효과가 지속될 시간
    [SerializeField] float _duration = 5f;
    //쿨타임
    [SerializeField] float _cooldown = 15f;
    //시각적으로 보이는 해당 스킬 이펙트
    [SerializeField] GameObject _fireRainEffect;
    //떨어지도록 구현할 대상이 되어줄 플레이어
    [SerializeField] Player player;

    //내부적으로 사용할, 현재 시점의 쿨타임 및 지속시간
    float curDuration;
    float curCooldown;
    //시간 경과를 체크하기 위한 변수
    float _timeFlow = 0;
    //강화 단계
    float _rank = 1;
    //파이어레인 마법이 발동되었는지 체크해줄 bool형 변수
    bool _isActive = false;
    //내부에 들어온 적에게 일정 주기마다 입힐 데미지
    float _damage = 0;
    //적에게 입힐 데미지의 주기
    float _time = 0.5f;
    //주기를 확인하기 위한 임시 시간변수
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
