using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillCard : MonoBehaviour
{
    //�ش� ī�尡 ��Ÿ���� ��ų�� ����
    [SerializeField] int skill;
    //ī�带 ����� �� â�� �ݵ��� ������� ��ų��ũ�������̽�
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
    //�� ī�带 ����� ���
    public void Chosen()
    {
        _selector._skillInterface.RankUp(skill);
        _selector.isPlayerSelected = true;
        _selector._selectCanvas.gameObject.SetActive(false);
    }
}
