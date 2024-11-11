using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public NewSaveData NSD;
    public void Play()
    {
        // Check if the player has completed the tutorial
        if (NSD.students[NSD.AccountNumber].LevelData.TutorialCompleted)
        {
            // Load the next scene if the tutorial was completed
            UnityEngine.SceneManagement.SceneManager.LoadScene("Category menu");
        }
        else
        {
            // Load the tutorial scene if it hasn't been completed
            UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
