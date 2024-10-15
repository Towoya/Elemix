using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public TutorialManager tutorialManager; // Reference to the TutorialManager
    public bool arrowsAfterDialogue = false; // Optional: Set if arrows should appear after dialogue

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tutorialManager != null)
            {
                tutorialManager.DisplayDialogue(); // Show the next dialogue
            }
            else
            {
                Debug.LogError("TutorialManager reference not set in DialogueTrigger!");
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Optional: Handle what happens when the player leaves the trigger
            Debug.Log("Player exited the dialogue trigger zone.");
        }
    }
}