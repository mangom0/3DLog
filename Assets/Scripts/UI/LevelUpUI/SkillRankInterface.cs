using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillRankInterface : MonoBehaviour
{
    //��ų ���� ��Ҹ� ������ ��ų�Ŵ���
    [SerializeField] public SkillManager _skillInterface;
    //�� ī�带 ������ ���� ȭ��
    [SerializeField] public Canvas _selectCanvas;
    //��ų�� ������ ���� �÷��̾�
    [SerializeField] Player player;
    //������ �� �� ��ų���� ������ ī�� 4��
    [SerializeField] GameObject CardOne;
    [SerializeField] GameObject CardTwo;
    [SerializeField] GameObject CardThree;
    [SerializeField] GameObject CardFour;
    //ī����� ������ ��� 1,2,3��
    [SerializeField] GameObject FirstCard;
    [SerializeField] GameObject SecondCard;
    [SerializeField] GameObject ThirdCard;
    //��ũ ǥ�⸦ ���� ä���� ���� ����� ��
    [SerializeField] Sprite _obtainedRank;
    [SerializeField] Sprite _notObtainedRank;

    //��ü������ Ȯ���� ����
    private int level;
    //�� ī����� ��ų��
    private int firstCard;
    private int secondCard;
    private int thirdCard;
    //ī�� ������ �Ϸ��ߴ��� Ȯ���ϱ� ���� bool�� ����
    public bool isPlayerSelected = true;
    //���� ��ȭ�� ���� ī�� ������ �̷���� ������ Ȯ���ϱ� ���� bool�� ����
    private bool isShuffled = false;


    private void Start()
    {
        //�ӽ÷� üũ�� ������ �÷��̾� ������ �����ϰ� ����
        level = player.level;
        //������ ���� ĵ������ �ϴ� ��Ȱ��ȭ
        _selectCanvas.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        PlayerLevelUp();
    }

    //�÷��̾� ������ ���� �Լ�
    void PlayerLevelUp()
    {
        //���� üũ�ϴ� �������� �÷��̾� ������ ��������
        if (player.level > level && isPlayerSelected == true)
        {
            isPlayerSelected = false;
            _selectCanvas.gameObject.SetActive(true);
            //�ߺ� üũ�� �����ϱ� ���� �ϴ� �������� ����ȭ
            level = player.level;
            if (isShuffled == false)
            {
                //�� ������ ī�带 �켱 �̱�
                firstCard = Random.Range(0, 3);
                secondCard = Random.Range(0, 3);
                thirdCard = Random.Range(0, 3);
                //ù ��° ī�忡 �ش� ���� �´� ��ų �̹����� ���
                switch (firstCard)
                {
                    case 0:
                        FirstCard = Instantiate(CardOne);
                        ShieldRankCheck();
                        break;
                    case 1:
                        FirstCard = Instantiate(CardTwo);
                        FireRainRankCheck();
                        break;
                    case 2:
                        FirstCard = Instantiate(CardThree);
                        IceFieldRankCheck();
                        break;
                    case 3:
                        FirstCard = Instantiate(CardFour);
                        TornadoRankCheck();
                        break;
                }
                //�� ��° ī�忡��
                switch (secondCard)
                {
                    case 0:
                        SecondCard = Instantiate(CardOne);
                        ShieldRankCheck();
                        break;
                    case 1:
                        SecondCard = Instantiate(CardTwo);
                        FireRainRankCheck();
                        break;
                    case 2:
                        SecondCard = Instantiate(CardThree);
                        IceFieldRankCheck();
                        break;
                    case 3:
                        SecondCard = Instantiate(CardFour);
                        TornadoRankCheck();
                        break;
                }
                //�� ��° ī�忡��
                switch (thirdCard)
                {
                    case 0:
                        ThirdCard = Instantiate(CardOne);
                        ShieldRankCheck();
                        break;
                    case 1:
                        ThirdCard = Instantiate(CardTwo);
                        FireRainRankCheck();
                        break;
                    case 2:
                        ThirdCard = Instantiate(CardThree);
                        IceFieldRankCheck();
                        break;
                    case 3:
                        ThirdCard = Instantiate(CardFour);
                        TornadoRankCheck();
                        break;
                }
                isShuffled = true;
            }
            

        }
    }
    //�ǵ� ī�� ��ũ ����
    void ShieldRankCheck()
    {
        if (_skillInterface._one._rank >= 1)
        {
            Transform firstStar = CardOne.transform.Find("Rank1");
            Image rankOne = firstStar.GetComponent<Image>();
            rankOne.sprite = _obtainedRank;
        }
        if (_skillInterface._one._rank >= 2)
        {
            Transform secondStar = CardOne.transform.Find("Rank2");
            Image rankTwo = secondStar.GetComponent<Image>();
            rankTwo.sprite = _obtainedRank;
        }
        if (_skillInterface._one._rank >= 3)
        {
            Transform thirdStar = CardOne.transform.Find("Rank3");
            Image rankThree = thirdStar.GetComponent<Image>();
            rankThree.sprite = _obtainedRank;
        }
    }
    //ȭ���� ī�� ��ũ ����
    void FireRainRankCheck()
    {
        //��ũ�� 1 �̻��̸�
        if (_skillInterface._two._rank >= 1)
        {
            //ù ��° �� �� �ڸ� Ȯ���ϰ�
            Transform firstStar = CardTwo.transform.Find("Rank1");
            //ù ��° �� �� �ڸ��� �̹��� �����ͼ�
            Image rankOne = firstStar.GetComponent<Image>();
            //�� ��������Ʈ�� ä���ִ´�
            rankOne.sprite = _obtainedRank;
        }
        if (_skillInterface._two._rank >= 2)
        {
            Transform secondStar = CardTwo.transform.Find("Rank2");
            Image rankTwo = secondStar.GetComponent<Image>();
            rankTwo.sprite = _obtainedRank;
        }
        if (_skillInterface._two._rank >= 3)
        {
            Transform thirdStar = CardTwo.transform.Find("Rank3");
            Image rankThree = thirdStar.GetComponent<Image>();
            rankThree.sprite = _obtainedRank;
        }
    }
    //�������� ī�� ��ũ ����
    void IceFieldRankCheck()
    {
        if (_skillInterface._three._rank >= 1)
        {
            Transform firstStar = CardThree.transform.Find("Rank1");
            Image rankOne = firstStar.GetComponent<Image>();
            rankOne.sprite = _obtainedRank;
        }
        if (_skillInterface._three._rank >= 2)
        {
            Transform secondStar = CardThree.transform.Find("Rank2");
            Image rankTwo = secondStar.GetComponent<Image>();
            rankTwo.sprite = _obtainedRank;
        }
        if (_skillInterface._three._rank >= 3)
        {
            Transform thirdStar = CardThree.transform.Find("Rank3");
            Image rankThree = thirdStar.GetComponent<Image>();
            rankThree.sprite = _obtainedRank;
        }
    }
    //��ǳ�� ī�� ��ũ ����
    void TornadoRankCheck()
    {
        if (_skillInterface._four._rank >= 1)
        {
            Transform firstStar = CardFour.transform.Find("Rank1");
            Image rankOne = firstStar.GetComponent<Image>();
            rankOne.sprite = _obtainedRank;
        }
        if (_skillInterface._four._rank >= 2)
        {
            Transform secondStar = CardFour.transform.Find("Rank2");
            Image rankTwo = secondStar.GetComponent<Image>();
            rankTwo.sprite = _obtainedRank;
        }
        if (_skillInterface._four._rank >= 3)
        {
            Transform thirdStar = CardFour.transform.Find("Rank3");
            Image rankThree = thirdStar.GetComponent<Image>();
            rankThree.sprite = _obtainedRank;
        }
    }
}
