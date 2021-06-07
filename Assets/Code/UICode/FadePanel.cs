using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour
{
    public float fadingSpeed = 0.5f;
    private bool fadeboolLevel, fadeboolDeath = false;

    public void FadeDeathPanel() {
        var CanvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(CanvasGroup, CanvasGroup.alpha, fadeboolDeath ? 1 : 0));
        fadeboolDeath = !fadeboolDeath;

    }


    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end) {
        float counter = 0f;

        while (counter < fadingSpeed) {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / fadingSpeed);

            yield return null;
        }
    }
}
