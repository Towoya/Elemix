using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox; // The Panel
    public Text dialogueText; // The Text or TextMeshPro object
    public Button nextButton; // The invisible button to proceed

    private string[] dialogueLines; // Array of dialogues
    private int currentLineIndex = 0;
    
    void Start()
    {
        // Initially, hide the dialogue box
        dialogueBox.SetActive(false);
        
        // Add listener for next button click
        nextButton.onClick.AddListener(OnNextButtonClick);
    }

    public void StartDialogue(string[] lines)
    {
        // Initialize dialogue and show the first line
        dialogueLines = lines;
        currentLineIndex = 0;
        ShowDialogue();
    }

    void ShowDialogue()
    {
        // Show the dialogue box and set the first line
        dialogueBox.SetActive(true);
        dialogueText.text = dialogueLines[currentLineIndex];
    }

    void OnNextButtonClick()
    {
        // Move to the next dialogue line
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            // End of dialogue, hide the box
            dialogueBox.SetActive(false);
        }
    }
}
