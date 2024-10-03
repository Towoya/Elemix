using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(6); // 6 is Debug Level
    }
}
