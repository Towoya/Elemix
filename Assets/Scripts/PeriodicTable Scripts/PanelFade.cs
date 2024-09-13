using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 0.5f; // Duration of the fade effect

    private bool isFadingIn = false;
    private bool isFadingOut = false;

    void Start()
    {
        // Initialize panel as invisible
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void ToggleFade()
    {
        if (canvasGroup.alpha == 0)
        {
            // If panel is invisible, fade in
            if (!isFadingIn)
                StartCoroutine(FadeIn());
        }
        else
        {
            // If panel is visible, fade out
            if (!isFadingOut)
                StartCoroutine(FadeOut());
        }
    }

    private System.Collections.IEnumerator FadeIn()
    {
        isFadingIn = true;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        isFadingIn = false;
    }

    private System.Collections.IEnumerator FadeOut()
    {
        isFadingOut = true;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        isFadingOut = false;
    }
}
