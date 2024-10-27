using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Check if the player has completed the tutorial
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 1)
        {
            // Load the next scene if the tutorial was completed
            UnityEngine.SceneManagement.SceneManager.LoadScene("NextScene");
        }
        else
        {
            // Load the tutorial scene if it hasn't been completed
            UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
        }
    }
}
