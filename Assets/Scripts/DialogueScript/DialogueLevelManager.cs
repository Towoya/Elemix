using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueLevelManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;   // Reference to the UI Text component for dialogues
    public GameObject dialogueBox;         // Reference to the dialogue box UI
    public float typingSpeed = 0.05f;      // Default typing speed
    public PlayerMovement playerController; // Reference to the PlayerController script for movement control
    
    private string[] dialogues;            // Array of dialogues to display
    private int currentDialogueIndex = 0;  // Index of the current dialogue
    private bool isTyping = false;         // Is dialogue currently typing?

    private void Start()
    {
        // Initially hide the dialogue box
        dialogueBox.SetActive(false);
    }

    // Method to start a new dialogue sequence
    public void StartDialogue(string[] newDialogues, float newTypingSpeed)
    {
        // Set the dialogues and typing speed
        dialogues = newDialogues;
        typingSpeed = newTypingSpeed;
        
        // Reset index and show dialogue box
        currentDialogueIndex = 0;
        dialogueBox.SetActive(true);
        
        // Disable player movement
        DisablePlayerMovement();

        // Start typing the first dialogue
        StartCoroutine(TypeDialogue());
    }

    // Update is called once per frame
    private void Update()
    {
        // Check for player input to continue through dialogue
        if (Input.GetMouseButtonDown(0) && !isTyping && dialogueBox.activeSelf)
        {
            NextDialogue();
        }
    }

    // Display the next dialogue
    private void NextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length - 1)
        {
            currentDialogueIndex++;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            EndDialogue();
        }
    }

    // Coroutine to type out the dialogue letter by letter
    private IEnumerator TypeDialogue()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in dialogues[currentDialogueIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    // End the dialogue and enable player movement
    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        EnablePlayerMovement();
    }

    // Disable player movement
    private void DisablePlayerMovement()
    {
        if (playerController != null)
        {
            playerController.canMove = false;
        }
    }

    // Enable player movement
    private void EnablePlayerMovement()
    {
        if (playerController != null)
        {
            playerController.canMove = true;
        }
    }
}

