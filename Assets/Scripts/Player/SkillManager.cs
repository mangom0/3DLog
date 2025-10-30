using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    //��ų�� ȹ���ߴ��� Ȯ���ϱ� ���� ��� "�÷��̾�"
    [SerializeField] Player player;
    //1�� ��ų �ǵ�
    [SerializeField] public Shield _one;
    //2�� ��ų ȭ����
    [SerializeField] public FireRain _two;
    //3�� ��ų ��������
    [SerializeField] public IceField _three; 
    //4�� ��ų ��ǳ��
    [SerializeField] public WindBlade _four;

    private void Start()
    {
        gameObject.SetActive(true);
        if(_one._rank == 0)
        _one._shieldEffect.gameObject.SetActive(false);
        if(_two._rank == 0)
        _two._fireRainEffect.gameObject.SetActive(false);
        if(_three._rank == 0)
        _three._iceFieldEffect.gameObject.SetActive(false);
        if(_four._rank == 0)
        _four._rankOneSpawn.gameObject.SetActive(false);
    }

    private void Update()
    {
        GetSkill();
    }

    void GetSkill()
    {
        if (_one._rank >= 1)
        {
            player._skillOneLearned = true;
            _one.gameObject.SetActive(true);
        }
        if(_two._rank >= 1)
        {
            player._skillTwoLearned = true;
            _two.gameObject.SetActive(true);
        }
        if(_three._rank >= 1)
        {
            player._skillThreeLearned = true;
            _three.gameObject.SetActive(true);
        }
        if(_four._rank >= 1)
        {
            player._skillFourthLearned = true;
            _four.gameObject.SetActive(true);
        }
    }

    public void RankUp(int skillNum)
    {
        switch(skillNum)
        {
            case 1:
                _one.RankUpCheck();
                break;
            case 2:
                _two.RankUpCheck();
                break;
            case 3:
                _three.RankUpCheck();
                break;
            case 4:
                _four.RankUpCheck();
                break;

        }
    }




}
