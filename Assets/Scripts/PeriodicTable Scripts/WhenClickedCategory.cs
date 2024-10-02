using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenClickedCategory : MonoBehaviour
{
    public GameObject Category, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9;

    public float transparentAlpha = 0.2f; // Set this to the desired transparency level
    public float opaqueAlpha = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disablecategorybtn()
    {
        GameObject[] categories = { Category, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9 };

        foreach (GameObject category in categories)
        {
            CanvasGroup canvasGroup = category.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = category.AddComponent<CanvasGroup>();
            }

            if (canvasGroup.alpha == opaqueAlpha)
            {
                canvasGroup.alpha = transparentAlpha;
                canvasGroup.interactable = false; // Make the button non-interactable
                canvasGroup.blocksRaycasts = false; // Prevent the button from receiving click events
            }
            else
            {
                canvasGroup.alpha = opaqueAlpha;
                canvasGroup.interactable = true; // Make the button interactable again
                canvasGroup.blocksRaycasts = true; // Allow the button to receive click events
            }
        }
    }
}