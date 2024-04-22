using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image img; //The image overlays the entire screen (in editor).

    public void Awake()
    {
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime) //Fade the image until it is completely transparent.
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}
