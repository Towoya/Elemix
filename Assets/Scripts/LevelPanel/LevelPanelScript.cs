using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPanelScript : MonoBehaviour
{

    public void NextLevel()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void ReturntoLevelSelect()
    {
        SceneManager.LoadScene(2);
    }

    
}
