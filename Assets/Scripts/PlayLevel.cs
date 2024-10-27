using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevel : MonoBehaviour
{
    // Method that takes the scene name or index as an argument
    public void Play(string levelName)
    {

         // Ensure the game is not paused when loading the new scene
        Time.timeScale = 1;

        // Load the scene using the scene name or index
        SceneManager.LoadScene(levelName);
    }
}
