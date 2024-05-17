using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPanel : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject textPanel;
    public GameObject hoverPanel;
    public void OnPointerClick(PointerEventData eventData)
    {
        textPanel.SetActive(true);
        hoverPanel.SetActive(true);
        AudioManager.Instance.PlaySFX("ButtonClick");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textPanel.SetActive(false);
        hoverPanel.SetActive(false);
        transform.localScale = new Vector2(1f, 1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySFX("ButtonHover");
        transform.localScale = new Vector2(1.2f, 1.2f);
    }
}

