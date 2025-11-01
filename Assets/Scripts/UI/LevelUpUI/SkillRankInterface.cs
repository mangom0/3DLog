using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class SkillRankInterface : MonoBehaviour
{
    //스킬 관련 요소를 가져올 스킬매니저
    [SerializeField] public SkillManager _skillInterface;
    //고를 카드를 꺼내줄 전용 화면
    [SerializeField] public Canvas _selectCanvas;
    //스킬을 가지고 있을 플레이어
    [SerializeField] Player player;
    //레벨업 시 고를 스킬들을 보여줄 카드 4종
    [SerializeField] GameObject CardOne;
    [SerializeField] GameObject CardTwo;
    [SerializeField] GameObject CardThree;
    [SerializeField] GameObject CardFour;
    //카드들이 등장할 장소 1,2,3번
    [SerializeField] GameObject FirstCard;
    [SerializeField] GameObject SecondCard;
    [SerializeField] GameObject ThirdCard;
    //랭크 표기를 위한 채워진 별과 비워진 별
    [SerializeField] Sprite _obtainedRank;
    [SerializeField] Sprite _notObtainedRank;

    //자체적으로 확인할 레벨
    private int level;
    //각 카드들의 스킬값
    private int firstCard;
    private int secondCard;
    private int thirdCard;
    //카드 선택을 완료했는지 확인하기 위한 bool형 변수
    public bool isPlayerSelected = true;

    GameObject _First;
    GameObject _Second;
    GameObject _Third;


    private void Start()
    {
        //임시로 체크할 레벨을 플레이어 레벨과 동일하게 맞춤
        level = player.level;
        //레벨업 전용 캔버스를 일단 비활성화
        _selectCanvas.gameObject.SetActive(false);
        //자체적으로 쓸 게임 오브젝트 전용 위치에 배치
        _First = Instantiate(CardOne);
        _First.transform.position = FirstCard.transform.position;
        _Second = Instantiate(CardTwo);
        _Second.transform.position = SecondCard.transform.position;
        _Third = Instantiate(CardThree);
        _Third.transform.position = ThirdCard.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerLevelUp();
        PlayerChoose();
    }

    //플레이어 레벨업 시의 함수
    void PlayerLevelUp()
    {
        //기존 체크하던 레벨보다 플레이어 레벨이 높아지면
        if (player.level > level && isPlayerSelected == true)
        {
            if (_skillInterface._one._rank == 3 && _skillInterface._two._rank == 3 &&
                _skillInterface._three._rank == 3 && _skillInterface._four._rank == 3)
                return;
            isPlayerSelected = false;
            _selectCanvas.gameObject.SetActive(true);
            //중복 체크를 제한하기 위해 일단 레벨부터 동일화
            level = player.level;
            
            
        }
    }

    void PlayerChoose()
    {
        if(isPlayerSelected == true)
        {
            ShieldRankCheck();
            FireRainRankCheck();
            IceFieldRankCheck();
            TornadoRankCheck();
        }
    }
    //실드 카드 랭크 설정
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
            CardOne.gameObject.SetActive(false);
        }
    }
    //화염비 카드 랭크 설정
    void FireRainRankCheck()
    {
        //랭크가 1 이상이면
        if (_skillInterface._two._rank >= 1)
        {
            //첫 번째 별 들어갈 자리 확인하고
            Transform firstStar = CardTwo.transform.Find("Rank1");
            //첫 번째 별 들어갈 자리의 이미지 가져와서
            Image rankOne = firstStar.GetComponent<Image>();
            //그 스프라이트를 채워넣는다
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
            CardTwo.gameObject.SetActive(false);
        }
    }
    //빙결지대 카드 랭크 설정
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
            CardThree.gameObject.SetActive(false);
        }
    }
    //질풍검 카드 랭크 설정
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
            CardFour.gameObject.SetActive(false);
        }
    }
}
