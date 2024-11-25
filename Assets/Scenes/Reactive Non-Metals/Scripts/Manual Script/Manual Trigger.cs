using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTrigger : MonoBehaviour
{
    public Canvas manualCanvas;
    void Start()
    {
        if (manualCanvas != null)
        {
            manualCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Target Canvas is not assigned.");
        }
    }

    private void OnMouseDown()
    {
        if (manualCanvas != null)
        {
            manualCanvas.gameObject.SetActive(!manualCanvas.gameObject.activeSelf);
        }
    }
}