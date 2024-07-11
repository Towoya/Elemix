using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject panel; // Reference to the panel to be closed

    // Method to close the panel
    public void CloseCurrentPanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}

