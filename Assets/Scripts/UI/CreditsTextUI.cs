using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsTextUI : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    void Start()
    {
        // Windows ±âº» ÇÑ±Û ÆùÆ® (¸¼Àº °íµñ)
        Font systemFont = Font.CreateDynamicFontFromOSFont("Malgun Gothic", 40);

        if (systemFont != null)
        {
            // TMP¿ë ÆùÆ® ¿¡¼Â »ý¼º
            TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(systemFont);

            // ÇÑ±Û ±Û¸®ÇÁ Ãß°¡ (°¡-ÆR)
            string koreanRange = "";
            for (int i = 0xAC00; i <= 0xD7A3; i++) // À¯´ÏÄÚµå ÇÑ±Û ¹üÀ§
                koreanRange += (char)i;

            fontAsset.TryAddCharacters(koreanRange);

            // TMP¿¡ ÆùÆ® Àû¿ë
            tmpText.font = fontAsset;

            // Å×½ºÆ®¿ë ¹®Àå
            tmpText.text = "ÇÑ±ÛÀÌ ÀÌÁ¦´Â Àß º¸ÀÔ´Ï´Ù!";
        }
        else
        {
            tmpText.text = "½Ã½ºÅÛ ÆùÆ®¸¦ ºÒ·¯¿ÀÁö ¸øÇß½À´Ï´Ù!";
        }
    }

}
