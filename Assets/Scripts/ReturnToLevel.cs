using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToLevel : MonoBehaviour
{
    public void ReturnLevel()
    {
        SceneManager.LoadScene(2);
    }
}
