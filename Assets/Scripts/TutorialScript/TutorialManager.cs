using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] arrows; // Array of arrow GameObjects to activate
    public TextMeshProUGUI dialogueText; // Reference to the UI Text component for dialogues
    public GameObject dialogueBox; // Reference to the dialogue box UI
    public float typingSpeed = 0.05f; // Speed at which dialogue types out
    public string[] dialogues; // Array of dialogues to display
    public PlayerMovement playerController; // Reference to the PlayerController script for movement control

    private int currentDialogueIndex = 0;
    private bool playerHasLearnedToMove = false; // Track if the player has completed the movement tutorial
    private bool isTyping = false; // To check if dialogue is currently typing
    private bool dialogueEndedOnce = false; // To track if the dialogue has ended for the first time
    private bool inTrigger = false; // To track if the player is in the trigger zone

    private void Start()
    {
        // Deactivate arrows and start the first dialogue
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false); // Deactivate all arrows
        }

        dialogueBox.SetActive(true); // Activate dialogue box at the start
        StartCoroutine(TypeDialogue());

        // Disable player movement at the start
        DisablePlayerMovement();
    }

    private void Update()
    {
        // Check for player input to continue through dialogue
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextDialogue();
        }

        // If the player has learned to move, activate arrows
        if (playerHasLearnedToMove && !arrows[0].activeSelf && dialogueEndedOnce)
        {
            ActivateArrows();
        }

        // If the player is inside a trigger zone and the dialogue box is hidden, show the next dialogue
        if (inTrigger && Input.GetMouseButtonDown(0) && !dialogueBox.activeSelf)
        {
            ContinueDialogue();
        }
    }

    // Function to display the next dialogue
    private void NextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length - 1)
        {
            currentDialogueIndex++;
            StartCoroutine(TypeDialogue()); // Type the next dialogue
        }
        else
        {
            dialogueBox.SetActive(false); // Hide the dialogue box once all dialogues are done
            PlayerLearnedToMove(); // This simulates the player learning to move after dialogues

            // Enable player movement only after all dialogues are done
            EnablePlayerMovement();

            // Mark that the dialogue has ended for the first time
            dialogueEndedOnce = true;
        }
    }

    // Coroutine to type out dialogue and stop for player input after each line
    private IEnumerator TypeDialogue()
    {
        isTyping = true;
        dialogueText.text = ""; // Clear the dialogue text

        foreach (char letter in dialogues[currentDialogueIndex].ToCharArray())
        {
            dialogueText.text += letter; // Add each letter one by one
            yield return new WaitForSeconds(typingSpeed); // Wait between each letter
        }

        isTyping = false; // Mark typing as finished, allowing the player to continue to the next line
    }

    // Display dialogue from where it left off, and stop player movement
    public void DisplayDialogue()
    {
        if (!dialogueBox.activeSelf)
        {
            dialogueBox.SetActive(true);
            StartCoroutine(TypeDialogue());
        }

        // Disable player movement whenever the dialogue box is active
        DisablePlayerMovement();
    }

    // Trigger for when the player learns to move
    public void PlayerLearnedToMove()
    {
        playerHasLearnedToMove = true; // This will allow the arrows to activate after the first dialogue
    }

    // Function to activate arrows on the floor
    public void ActivateArrows()
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(true); // Activate each arrow
        }
    }

    // Handle when the player enters a trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true; // Mark that the player is in the trigger zone
            DisplayDialogue(); // Show the dialogue box and continue from where it left off
        }
    }

    // Handle when the player exits a trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false; // Player left the trigger zone
        }
    }

    // Continue dialogue when the player is in the trigger zone
    public void ContinueDialogue()
    {
        dialogueBox.SetActive(true); // Reactivate the dialogue box
        StartCoroutine(TypeDialogue()); // Continue typing dialogue from the next line

        // Disable player movement when continuing dialogue
        DisablePlayerMovement();
    }

    // Disable player movement
    private void DisablePlayerMovement()
    {
        if (playerController != null)
        {
            playerController.canMove = false; // Set movement to false
        }
    }

    // Enable player movement
    private void EnablePlayerMovement()
    {
        if (playerController != null)
        {
            playerController.canMove = true; // Allow movement
        }
    }
}
