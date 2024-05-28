using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionManager : MonoBehaviour
{
    public Button[] choiceButtons;
    public int correctAnswerIndex;
    public GameObject deactPanel;
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public float PanelDelay = 3f;

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
        }
        else
        {
            Debug.Log("Wrong Answer!");
            selectedButton.image.color = incorrectColor;
            // Perform any action for wrong answer
        }
        StartCoroutine(PanelDeactivate());
    }
    IEnumerator PanelDeactivate()
    {
        yield return new WaitForSeconds(PanelDelay);
        deactPanel.SetActive(false);
    }
}
