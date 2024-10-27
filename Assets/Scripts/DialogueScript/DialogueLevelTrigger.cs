using UnityEngine;

public class DialogueLevelTrigger : MonoBehaviour
{
    public DialogueLevelManager dialogueManager; // Reference to the DialogueManager in the scene
    public string[] dialogues;                   // Array of dialogues for this specific trigger
    public float typingSpeed = 0.05f;            // Typing speed for this dialogue

    private bool hasTriggered = false;           // Flag to check if dialogue has already been triggered

    // When the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // Start the dialogue sequence with the specified dialogues and typing speed
            dialogueManager.StartDialogue(dialogues, typingSpeed);

            // Set the flag to true so it won't trigger again
            hasTriggered = true;

            // Optionally, destroy the trigger after dialogue is shown once
            Destroy(gameObject);  // If you want the trigger to be removed after interaction
        }
    }
}

