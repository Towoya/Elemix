using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string content;
    [Multiline()]
    public string header;
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(content, header); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }

    public void OnMouseEnter()
    {
        TooltipSystem.Show(content, header); 
    }

    public void OnMouseExit()
    {
        TooltipSystem.Hide();  
    }
}
    
