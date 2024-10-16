using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevel : MonoBehaviour
{
    // Method that takes the scene name or index as an argument
    public void Play(string levelName)
    {
        // Load the scene using the scene name or index
        SceneManager.LoadScene(levelName);
    }
}
