using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsTextUI : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    void Start()
    {
        // Windows �⺻ �ѱ� ��Ʈ (���� ���)
        Font systemFont = Font.CreateDynamicFontFromOSFont("Malgun Gothic", 40);

        if (systemFont != null)
        {
            // TMP�� ��Ʈ ���� ����
            TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(systemFont);

            // �ѱ� �۸��� �߰� (��-�R)
            string koreanRange = "";
            for (int i = 0xAC00; i <= 0xD7A3; i++) // �����ڵ� �ѱ� ����
                koreanRange += (char)i;

            fontAsset.TryAddCharacters(koreanRange);

            // TMP�� ��Ʈ ����
            tmpText.font = fontAsset;

            // �׽�Ʈ�� ����
            tmpText.text = "�ѱ��� ������ �� ���Դϴ�!";
        }
        else
        {
            tmpText.text = "�ý��� ��Ʈ�� �ҷ����� ���߽��ϴ�!";
        }
    }

}
