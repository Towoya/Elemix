using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneValue;
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(sceneValue);
    }
}
