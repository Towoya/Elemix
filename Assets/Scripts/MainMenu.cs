using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    public NewSaveData NSD;

    public GameObject VideoPanel;
    public VideoPlayer VPlayer;

    Coroutine WaitCo;
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
            VideoPanel.SetActive(true);

            VPlayer.Play();
            // Load the tutorial scene if it hasn't been completed

            if (WaitCo != null)
            {
                StopCoroutine(WaitCo);
                WaitCo = null;
            }

            WaitCo = StartCoroutine(WaitIe());

        }
    }

    IEnumerator WaitIe()
    {
        yield return new WaitForSeconds(1f);

        while (VPlayer.isPlaying)
        {
            yield return null;
        }

        OpenTutorialScene();
        yield return null;

    }

    public void OpenTutorialScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
