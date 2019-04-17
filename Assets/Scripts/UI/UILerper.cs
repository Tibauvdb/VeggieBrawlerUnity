using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILerper : MonoBehaviour
{
    /// <summary>
    /// Lerp UI to certain Place
    /// </summary>
    /// <param name="lerpThis">UI object you want to lerp</param>
    /// <param name="targetPos">End Position of Lerp</param>
    /// <param name="lerpSpeed">Speed of lerp</param>
    public static void LerpUI(RectTransform lerpThis, Vector2 targetPos, float lerpSpeed)
    {
        lerpThis.anchoredPosition = Vector2.Lerp(lerpThis.anchoredPosition, targetPos, Time.deltaTime * lerpSpeed);
    }

    /// <summary>
    /// Lerp opacity of color
    /// </summary>
    /// <param name="col">Color</param>
    /// <param name="endValue">End opacity value</param>
    /// <param name="lerpSpeed">speed of lerp</param>
    public static Color LerpOpacity(Color col, float endValue, float lerpSpeed)
    {
        col.a = Mathf.Lerp(col.a, endValue, lerpSpeed);
        return col;
    }
}
