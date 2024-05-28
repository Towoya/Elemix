using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public GameObject panel; // Assign your panel object in the Unity Editor

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }
}

