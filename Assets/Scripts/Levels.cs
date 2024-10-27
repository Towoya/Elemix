using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    // Method to load a specific level menu based on scene name or index
    public void PlayCategory(string categoryLevelMenu)
    {
        // Load the category level menu using the scene name or index
        SceneManager.LoadScene(categoryLevelMenu);
    }
}
