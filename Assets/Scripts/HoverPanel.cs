using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPanel : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public GameObject textPanel;
    public GameObject hoverPanel;
    public void OnPointerClick(PointerEventData eventData)
    {
        textPanel.SetActive(true);
        hoverPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textPanel.SetActive(false);
        hoverPanel.SetActive(false);
    }
}

