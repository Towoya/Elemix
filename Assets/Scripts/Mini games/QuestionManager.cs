using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class QuestionManager : MonoBehaviour
{
    public Button[] choiceButtons;
    public int correctAnswerIndex;
    public GameObject deactPanel;
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public float PanelDelay = 50f;

    void Start()
    {
        foreach (Button button in choiceButtons)
        {
            button.onClick.AddListener(delegate { CheckAnswer(button); });
        }
    }

    void CheckAnswer(Button selectedButton)
    {
        int selectedIndex = System.Array.IndexOf(choiceButtons, selectedButton);
        if (selectedIndex == 0)
        {
            Debug.Log("Correct Answer!");
            selectedButton.image.color = correctColor;
            // Perform any action for correct answer
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("Wrong Answer!");
            selectedButton.image.color = incorrectColor;
            // Perform any action for wrong answer
            Time.timeScale = 1;
        }
        StartCoroutine(PanelDeactivate());
        Destroy(deactPanel);
    }
    IEnumerator PanelDeactivate()
    {
        yield return new WaitForSeconds(PanelDelay);
    }
}
