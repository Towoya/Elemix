using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            panel.SetActive(false);
            panel2.SetActive(true);
        }
    }   
}
