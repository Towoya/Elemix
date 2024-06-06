using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
     public GameObject panel; // Assign your panel object in the Unity Editor

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
