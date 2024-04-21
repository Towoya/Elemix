using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public GameObject panel;
    public void Interact()
    {
        Debug.Log("Interact!");
        Destroy(gameObject);

        panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            panel.SetActive(false);
        }
    }
}
