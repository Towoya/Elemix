using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPanel : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject textPanel;
    public GameObject hoverPanel;

    
    private static GameObject currentActiveTextPanel = null;
    private static GameObject currentActiveHoverPanel = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Deactivate the currently active panels
        if (currentActiveTextPanel != null && currentActiveTextPanel != textPanel)
        {
            currentActiveTextPanel.SetActive(false);
        }

        if (currentActiveHoverPanel != null && currentActiveHoverPanel != hoverPanel)
        {
            currentActiveHoverPanel.SetActive(false);
        }

        // Activate the new panels
        textPanel.SetActive(true);
        hoverPanel.SetActive(true);

        // Update the currently active panels
        currentActiveTextPanel = textPanel;
        currentActiveHoverPanel = hoverPanel;

        AudioManager.Instance.PlaySFX("ButtonClick");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Optional: Uncomment these lines if you want the panel to hide on pointer exit
        //textPanel.SetActive(false);
        //hoverPanel.SetActive(false);
        transform.localScale = new Vector2(1f, 1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySFX("ButtonHover");
        transform.localScale = new Vector2(1.2f, 1.2f);
    }
}