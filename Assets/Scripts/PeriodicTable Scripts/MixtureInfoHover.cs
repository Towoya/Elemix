using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MixtureInfoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Assign this in the Inspector
    public GameObject panel;

    // This method is called when the pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.SetActive(true);  // Show the panel
    }

    // This method is called when the pointer exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        panel.SetActive(false);  // Hide the panel
    }
}
