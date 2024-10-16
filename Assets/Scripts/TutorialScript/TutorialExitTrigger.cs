using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialExitTrigger : MonoBehaviour
{
    public GameObject tutorialCompletePanel; // Reference to the panel in the UI
    public Button continueButton;            // Reference to the continue button

    private void Start()
    {
        // Ensure the panel is hidden at the start
        tutorialCompletePanel.SetActive(false);

        // Set up the button's onClick listener
        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Show the completion panel
            tutorialCompletePanel.SetActive(true);
             Time.timeScale = 0f;
        }
    }

    // Method to handle the "Continue" button click
    private void OnContinueButtonClicked()
    {
        // Set the flag to indicate the tutorial is completed
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save();

        // Load the stage selection scene (replace with actual scene name)
        SceneManager.LoadScene("Category menu");
    }
}