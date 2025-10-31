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
    //습득 시 실드로서 기능할 오브젝트
    [SerializeField] public ShieldActivation _shieldEffect;
    [SerializeField] Player player;

    //내부적으로 사용할, 현재 시점의 쿨타임 및 지속시간
    float curDuration;
    float curCooldown;
    //시간 경과를 체크하기 위한 변수
    float _timeFlow = 0;
    //강화 단계
    public float _rank = 0;
    //실드 마법이 발동되었는지 체크해줄 bool형 변수
    bool _isActive = false;
    private void Awake()
    {
        curDuration = _duration;
        curCooldown = _cooldown;
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
            player.isShieldActive = false;
            if (curCooldown <= _timeFlow)
            {
                _isActive = true;
                _shieldEffect._shieldHp = _value;
                _shieldEffect.gameObject.SetActive(true);
                Debug.Log("현재 잔여 보호막 수치 : " + _shieldEffect._shieldHp);
                _timeFlow = 0;
            }
        }
        else if (_isActive == true)
        {
            _shieldEffect.transform.position = player.transform.position;
            player.isShieldActive = true;
            if (_shieldEffect._shieldHp <= 0 || curDuration <= _timeFlow)
            {
                if(_shieldEffect._shieldHp > 0)
                    _shieldEffect.ShieldTakeDamage(_shieldEffect._shieldHp + 1);
                _isActive = false;
                _shieldEffect.gameObject.SetActive(false);
                _timeFlow = 0;

            }
        }

    }
    public void RankUpCheck()
    {
            _rank++;
            _isActive = false;
        _shieldEffect.gameObject.SetActive(false);
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
