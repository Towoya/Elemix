using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public TutorialManager tutorialManager; // Reference to the TutorialManager
    [TextArea(3, 10)]
    public string[] specificDialogues; // Array of specific dialogues for this trigger

    private bool hasTriggered = false; // To prevent the dialogue from playing multiple times

    // When the player enters the trigger
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player") && !hasTriggered)
    {
        hasTriggered = true;
        tutorialManager.SetDialogues(specificDialogues);
        
        // Disable player movement immediately when entering the trigger
        tutorialManager.DisablePlayerMovement(); // Use this to disable movement in the manager
        
        tutorialManager.DisplayDialogue();
    }
}
}
