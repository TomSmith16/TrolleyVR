using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour {

    public bool faded = false;

    public void FadeOut()
    {
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup.alpha == 0)
        {
            Debug.Log("Fade in");
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / 2;
                
                yield return null;
            }
            faded = false;
        }
        else
        {
             while (canvasGroup.alpha > 0)
             {
                 canvasGroup.alpha -= Time.deltaTime / 1;
                 yield return null;
             }
            faded = true;
        }
        canvasGroup.interactable = false;
        yield return null;
    }
}
