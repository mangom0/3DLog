using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillCard : MonoBehaviour
{
    //해당 카드가 나타내줄 스킬의 종류
    [SerializeField] int skill;
    //카드를 골랐을 때 창을 닫도록 만들어줄 스킬랭크인터페이스
    [SerializeField] public SkillRankInterface _selector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_selector.isPlayerSelected == true)
            gameObject.SetActive(false);
    }
    //이 카드를 골랐을 경우
    public void Chosen()
    {
        _selector._skillInterface.RankUp(skill);
        _selector.isPlayerSelected = true;
        _selector._selectCanvas.gameObject.SetActive(false);
    }
}
