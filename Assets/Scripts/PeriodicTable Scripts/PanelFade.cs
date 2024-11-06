using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this for UI elements

public class PanelFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 0.5f; // Duration of the fade effect
    public Button seeMixtureButton; // Reference to the "See Mixture" button

    private bool isFadingIn = false;
    private bool isFadingOut = false;

    void Start()
    {
        // Initialize panel as invisible
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // Assign the button's onClick event
        if (seeMixtureButton != null)
        {
            seeMixtureButton.onClick.AddListener(ToggleFade);
        }
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

    private IEnumerator FadeIn()
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

    private IEnumerator FadeOut()
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
