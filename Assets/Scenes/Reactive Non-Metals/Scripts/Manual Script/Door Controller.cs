using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public DoorParent doorParent;
    public Canvas manualCanvas;
    public GameObject manualTrigger;
    public void OnButtonClick()
    {
        if (doorParent != null)
        {
            doorParent.doorOpened = true;
            manualCanvas.gameObject.SetActive(false);
            GameObject.Destroy(manualTrigger);
        }
    }
}