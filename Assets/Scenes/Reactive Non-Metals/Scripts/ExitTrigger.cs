using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene transitions
using UnityEngine.UI;

public class ExitTrigger : MonoBehaviour
{
    [Header("Exit Panel Variables")]
    public GameObject exitPanel; // The panel that will be displayed at the end of the level
    public Button nextLevelButton;
    public Button retryButton;
    public Button exitButton;

    [Header("Level Information")]
    public string nextLevelName; // Name of the next level
    public string levelSelectionSceneName = "LevelSelection"; // The scene for level selection

    private void Start()
    {
        exitPanel.SetActive(false); // Ensure the exit panel is hidden at the start

        // Add listeners to buttons
        nextLevelButton.onClick.AddListener(() => LoadNextLevel());
        retryButton.onClick.AddListener(() => RetryLevel());
        exitButton.onClick.AddListener(() => ExitToLevelSelection());
    }

    // Trigger event when the player reaches the exit point
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it triggers only when the player interacts
        {
            ShowExitPanel();
        }
    }

    // Shows the exit panel with the options
    private void ShowExitPanel()
    {
        Time.timeScale = 0f; // Pause the game when the exit panel shows up
        exitPanel.SetActive(true); // Show the exit panel
    }

    // Loads the next level
    private void LoadNextLevel()
    {
        Time.timeScale = 1f; // Resume time before loading the next scene
        SceneManager.LoadScene(nextLevelName); // Load the next level scene
    }

    // Restarts the current level
    private void RetryLevel()
    {
        Time.timeScale = 1f; // Resume time before restarting the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Exits to the level selection scene
    private void ExitToLevelSelection()
    {
        Time.timeScale = 1f; // Resume time before loading the level selection scene
        SceneManager.LoadScene(levelSelectionSceneName); // Load the level selection scene
    }
}

