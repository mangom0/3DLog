using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour, ISkill
{
    //스킬의 판정 범위를 지정해줄 Collider
    [SerializeField] SphereCollider _collider;
    //해당 스킬 사용 시의 설정값
    [SerializeField] float _value = 5f;
    //해당 효과가 지속될 시간
    [SerializeField] float _duration = 5f;
    //쿨타임
    [SerializeField] float _cooldown = 5f;
    //시각적으로 보이는 해당 스킬 이펙트
    [SerializeField] GameObject _shieldEffect;
    [SerializeField] Player player;

    //내부적으로 사용할, 현재 시점의 쿨타임 및 지속시간
    float curDuration;
    float curCooldown;
    //시간 경과를 체크하기 위한 변수
    float _timeFlow = 0;
    //강화 단계
    float _rank = 1;
    //실드 마법이 발동되었는지 체크해줄 bool형 변수
    bool _isActive = false;
    //실드 마법이 발동되었을 경우 해당 실드가 막아줄 수 있는 최대 피해량
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
