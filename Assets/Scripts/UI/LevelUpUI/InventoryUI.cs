using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //각 스킬들의 원본
    [SerializeField] SkillManager _skillManager;
    //관리해야 하는 이미지
    [SerializeField] GameObject ShieldImage;
    [SerializeField] GameObject FireRainImage;
    [SerializeField] GameObject IceFieldImage;
    [SerializeField] GameObject TornadoImage;
    //랭크에 따른 표기용 채워진 별
    [SerializeField] Sprite _obtainedRank;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShieldRankUpdate();
        FireRainRankUpdate();
        IceFieldRankUpdate();
        TornadoRankUpdate();
        ShieldCooldownCheck();
        FireRainCooldownCheck();
        IceFieldCooldownCheck();
        TornadoActiveCheck();
    }

    void ShieldRankUpdate()
    {
        if (_skillManager._one._rank >= 1)
        {
            Transform firstStar = ShieldImage.transform.Find("Rank1");
            Image rankOne = firstStar.GetComponent<Image>();
            rankOne.sprite = _obtainedRank;
        }
        if (_skillManager._one._rank >= 2)
        {
            Transform secondStar = ShieldImage.transform.Find("Rank2");
            Image rankTwo = secondStar.GetComponent<Image>();
            rankTwo.sprite = _obtainedRank;
        }
        if (_skillManager._one._rank >= 3)
        {
            Transform thirdStar = ShieldImage.transform.Find("Rank3");
            Image rankThree = thirdStar.GetComponent<Image>();
            rankThree.sprite = _obtainedRank;
        }
    }
    void FireRainRankUpdate()
    {
        if (_skillManager._two._rank >= 1)
        {
            Transform firstStar = FireRainImage.transform.Find("Rank1");
            Image rankOne = firstStar.GetComponent<Image>();
            rankOne.sprite = _obtainedRank;
        }
        if (_skillManager._two._rank >= 2)
        {
            Transform secondStar = FireRainImage.transform.Find("Rank2");
            Image rankTwo = secondStar.GetComponent<Image>();
            rankTwo.sprite = _obtainedRank;
        }
        if (_skillManager._two._rank >= 3)
        {
            Transform thirdStar = FireRainImage.transform.Find("Rank3");
            Image rankThree = thirdStar.GetComponent<Image>();
            rankThree.sprite = _obtainedRank;
        }
    }
    void IceFieldRankUpdate()
    {
        if (_skillManager._three._rank >= 1)
        {
            Transform firstStar = IceFieldImage.transform.Find("Rank1");
            Image rankOne = firstStar.GetComponent<Image>();
            rankOne.sprite = _obtainedRank;
        }
        if (_skillManager._three._rank >= 2)
        {
            Transform secondStar = IceFieldImage.transform.Find("Rank2");
            Image rankTwo = secondStar.GetComponent<Image>();
            rankTwo.sprite = _obtainedRank;
        }
        if (_skillManager._three._rank >= 3)
        {
            Transform thirdStar = IceFieldImage.transform.Find("Rank3");
            Image rankThree = thirdStar.GetComponent<Image>();
            rankThree.sprite = _obtainedRank;
        }
    }
    void TornadoRankUpdate()
    {
        if (_skillManager._four._rank >= 1)
        {
            Transform firstStar = TornadoImage.transform.Find("Rank1");
            Image rankOne = firstStar.GetComponent<Image>();
            rankOne.sprite = _obtainedRank;
        }
        if (_skillManager._four._rank >= 2)
        {
            Transform secondStar = TornadoImage.transform.Find("Rank2");
            Image rankTwo = secondStar.GetComponent<Image>();
            rankTwo.sprite = _obtainedRank;
        }
        if (_skillManager._four._rank >= 3)
        {
            Transform thirdStar = TornadoImage.transform.Find("Rank3");
            Image rankThree = thirdStar.GetComponent<Image>();
            rankThree.sprite = _obtainedRank;
        }
    }
    void ShieldCooldownCheck()
    {
        if(_skillManager._one._isActive == false)
        {
            Transform Cooldown = ShieldImage.transform.Find("NonActive_Cooldown");
            Image CooltimeCheck = Cooldown.GetComponent<Image>();
            CooltimeCheck.fillAmount = ((_skillManager._one.curCooldown - _skillManager._one._timeFlow) / _skillManager._one._cooldown);
        }
    }
    void FireRainCooldownCheck()
    {
        if(_skillManager._two._isActive == false)
        {
            Transform Cooldown = FireRainImage.transform.Find("NonActive_Cooldown");
            Image CooltimeCheck = Cooldown.GetComponent<Image>();
            CooltimeCheck.fillAmount = ((_skillManager._two._cooldown - _skillManager._two._timeFlow) / _skillManager._two._cooldown);
        }
    }
    void IceFieldCooldownCheck()
    {
        if(_skillManager._three._isActive == false)
        {
            Transform Cooldown = IceFieldImage.transform.Find("NonActive_Cooldown");
            Image CooltimeCheck = Cooldown.GetComponent<Image>();
            CooltimeCheck.fillAmount = ((_skillManager._three.curCooldown - _skillManager._three._timeFlow) / _skillManager._three._cooldown);
        }
    }
    void TornadoActiveCheck()
    {
        if(_skillManager._four._rank > 0)
        {
            TornadoImage.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
    }
}
